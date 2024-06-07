using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public string nextLevel;
  private static GameManager instance;
  public static GameManager Instance
  {
    get
    {
      if (instance == null)
      {
        instance = FindObjectOfType<GameManager>();
        if (instance == null)
        {
          Debug.LogError("Could not find GameManager instance!");
        }
      }
      return instance;
    }
  }

  private void Awake()
  {
    if (instance != null && instance != this)
    {
      Destroy(gameObject);
    }
    instance = this;

    canMove = true;

    levelLoader = GetComponent<LevelLoader>();
  }

  private void Start()
  {
    foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
    {
      player.GetComponent<EasierInputAssignController>()?.Assign();
      player.GetComponent<EasierButtonAssignController>()?.Assign();
    }
  }

  public bool canMove = true;
  public GameObject winCanvas;
  public GameObject pauseCanvas;
  public PlaySoundController playSoundController;
  public LevelLoader levelLoader;

  public bool paused = false;

  public bool win = false;

  private void Update()
  {

    if (Input.GetKeyDown(KeyCode.R))
    {
      ReloadScene();
    }
    if (Input.GetKeyDown(KeyCode.P) && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "LevelSelect")
    {
      if (!paused)
      {
        Instance.Pause();
      }
      else
      {
        Instance.Resume();
      }
    }
  }

  public void OnWin(Action invoke)
  {
    if (win) return;
    win = true;
    canMove = false;
    invoke();
    winCanvas.SetActive(true);
  }

  public void UnlockAchievementBehindTheScenes()
  {
    AchievementManager.instance.Unlock("BehindTheScenes");
  }

  public void UnlockAchievementDeathByDeletion()
  {
    AchievementManager.instance.Unlock("DeathByDeletion");
  }

  public void UnlockAchievementBabySteps()
  {
    AchievementManager.instance.Unlock("BabySteps");
  }

  public void UnlockAchievementQuitter()
  {
    AchievementManager.instance.Unlock("Quitter");
  }

  public void UnlockAchievementStackOverflow()
  {
    AchievementManager.instance.Unlock("StackOverflow");
  }

  public void UnlockAchievementWorld0Completionist()
  {
    AchievementManager.instance.Unlock("World0Completionist");
  }

  public void UnlockAchievementWorld1Completionist()
  {
    AchievementManager.instance.Unlock("World1Completionist");
  }

  public void UnlockAchievementWorld2Completionist()
  {
    AchievementManager.instance.Unlock("World2Completionist");
  }

  public void UnlockAchievementWorld3Completionist()
  {
    AchievementManager.instance.Unlock("World3Completionist");
  }

  public void ReloadScene()
  {
    levelLoader.ReloadLevel();
  }

  public void LoadNextLevel()
  {
    if (nextLevel != null) levelLoader.LoadLevel(nextLevel);
  }

  public void Pause()
  {
    paused = true;
    canMove = false;
    pauseCanvas.SetActive(true);
  }

  public void Resume()
  {
    paused = false;
    canMove = true;
    pauseCanvas.SetActive(false);
  }
}
