using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel00()
    {
        SceneManager.LoadScene("Level0-0");
    }

    public void LoadLevel01()
    {
        SceneManager.LoadScene("Level0-1");
    }

    public void LoadLevel10()
    {
        SceneManager.LoadScene("Level1-0");
    }

    public void LoadLevel20()
    {
        SceneManager.LoadScene("Level2-0");
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

}
