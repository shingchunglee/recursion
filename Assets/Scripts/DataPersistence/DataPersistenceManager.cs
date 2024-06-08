using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System;

using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
  [Header("File Storage Config")]
  [SerializeField] private string fileName;

  private static DataPersistenceManager _instance;
  public static DataPersistenceManager Instance
  {
    get
    {
      if (_instance == null)
      {
        _instance = FindObjectOfType<DataPersistenceManager>();
        if (_instance == null)
        {
          GameObject obj = new GameObject("DataPersistenceManager");
          _instance = obj.AddComponent<DataPersistenceManager>();
        }

        DontDestroyOnLoad(_instance.gameObject);
      }
      return _instance;
    }
  }

  private void Awake()
  {
    if (_instance != null && _instance != this)
    {
      Destroy(this.gameObject);
    }
    else
    {
      _instance = this;
    }
    DontDestroyOnLoad(gameObject);
    SceneManager.sceneLoaded += OnSceneLoaded;
  }

  private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
  {
    Start();
  }

  public GameData gameData;
  private List<IDataPersistance> dataPersistanceObjects;
  private FileDataHandler fileDataHandler;

  private void Start()
  {
    Debug.Log(Application.persistentDataPath);
    this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    dataPersistanceObjects = FindAllDataPersistanceObjects();
    LoadGame();
  }

  private List<IDataPersistance> FindAllDataPersistanceObjects()
  {
    IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

    return new List<IDataPersistance>(dataPersistanceObjects);
  }

  public void ClearGame()
  {
    gameData = new GameData();
    SaveGame();
    LoadGame();
  }

  public void NewGame()
  {
    gameData = new GameData();

    foreach (IDataPersistance dataPersistance in dataPersistanceObjects)
    {
      dataPersistance.Load(gameData);
    }
  }

  public void LoadGame()
  {
    // TODO load any save data from the file
    this.gameData = this.fileDataHandler.Load();

    if (gameData == null)
    {
      NewGame();
    }
    // TODO - push loaded data to other scripts

    foreach (IDataPersistance dataPersistance in dataPersistanceObjects)
    {
      dataPersistance.Load(gameData);
    }
  }

  public void SaveGame()
  {
    // TODO pass the data to other scripts so they can update it
    foreach (IDataPersistance dataPersistance in dataPersistanceObjects)
    {
      dataPersistance.Save(ref this.gameData);
    }

    // TODO save the data to a file
    this.fileDataHandler.Save(this.gameData);
  }
}
