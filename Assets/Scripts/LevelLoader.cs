using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class LevelLoader : MonoBehaviour
{
    Animator sceneTransition;
    Coroutine load;
    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        sceneTransition = GameObject.Find("SceneTransition").GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel(string levelName)
    {
        if (load != null) return;
        // Debug.Break();
        Debug.Log(gameObject.activeSelf);
        load = StartCoroutine(Animate(levelName));
    }

    IEnumerator Animate(string levelName)
    {
        sceneTransition.SetBool("Start", true);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
        sceneTransition.SetBool("Start", false);
    }

    public void LoadLevel00()
    {
        LoadLevel("Level0-0");
    }

    public void LoadLevel01()
    {
        LoadLevel("Level0-1");
    }

    public void LoadLevel10()
    {
        LoadLevel("Level1-0");
    }

    public void LoadLevel20()
    {
        LoadLevel("Level2-0");
    }

    public void LoadLevelSelect()
    {
        LoadLevel("LevelSelect");
    }

    public void ReloadLevel()
    {
        LoadLevel(SceneManager.GetActiveScene().name);
    }
}
