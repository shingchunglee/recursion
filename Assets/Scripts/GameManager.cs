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
  public PlaySoundController playSoundController;

  public void OnWin()
  {
    canMove = false;
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
    UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
  }
}
