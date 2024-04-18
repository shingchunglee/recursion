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

  public bool canMove = true;
  public GameObject winCanvas;

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
}
