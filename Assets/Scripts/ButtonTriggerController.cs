using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTriggerController : MonoBehaviour
{
    [SerializeField] UnityEvent OnTrigger;
    [SerializeField] UnityEvent OnTriggerOnce;
    [SerializeField] UnityEvent OnRelease;
    public AudioClip keySound;
    public bool released = true;

    private void OnDisable()
    {
        released = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (released)
        {
            OnRelease.Invoke();
        }
    }

    public void Trigger()
    {
        released = false;
        OnTrigger.Invoke();
    }

    public void TriggerOnce()
    {
        GameManager.Instance.playSoundController.PlayClipOnce(keySound);
        OnTriggerOnce.Invoke();
    }

    public void Release()
    {
        released = true;
        // OnRelease.Invoke();
    }
}
