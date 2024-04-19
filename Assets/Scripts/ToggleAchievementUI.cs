using UnityEngine;

public class ToggleAchievementUI : MonoBehaviour
{

    public void ToggleAchievementsUI()
    {
        GameObject.Find("Achievement Manager").GetComponent<AchievenmentListIngame>().ToggleWindow();
    }

    public void OpenAchievementsUI()
    {
        GameObject.Find("Achievement Manager").GetComponent<AchievenmentListIngame>().OpenWindow();
    }

    public void CloseAchievementsUI()
    {
        GameObject.Find("Achievement Manager").GetComponent<AchievenmentListIngame>().CloseWindow();
    }
}