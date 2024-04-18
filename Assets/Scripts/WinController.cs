using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    [SerializeField] UnityEvent OnWin;
    public Animator animator;
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
        OnWin.Invoke();
    }
}
