using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    [SerializeField] UnityEvent OnWin;
    public Animator animator;
    public bool goalReached = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void win()
    {
        animator.Play("win");
        goalReached = true;
        GameObject[] goals = GameObject.FindGameObjectsWithTag("Goal");
        foreach (GameObject goal in goals)
        {
            if (!goal.GetComponent<WinController>().goalReached) { return; }
        }
        GameManager.Instance.OnWin(OnWin.Invoke);
    }

    public void UnWin()
    {
        goalReached = false;
        animator.Play("idle");
    }
}
