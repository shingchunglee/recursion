using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

  public void OnWin(Action invoke)
  {
    if (win) return;
    win = true;
    canMove = false;
    invoke();
    winCanvas.SetActive(true);
  }

  public void UnlockAchievementDeathByDeletion()
  {
    AchievementManager.instance.Unlock("DeathByDeletion");
  }

  public void UnlockAchievementBabySteps()
  {
    AchievementManager.instance.Unlock("BabySteps");
  }

  public void ReloadScene()
  {
    levelLoader.ReloadLevel();
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
