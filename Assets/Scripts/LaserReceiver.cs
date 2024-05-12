using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserReceiver : MonoBehaviour
{
    public UnityEvent OnTrigger;
    public UnityEvent OnTriggerOnce;
    public UnityEvent OnRelease;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Trigger()
    {
        OnTrigger.Invoke();
    }

    public void TriggerOnce()
    {
        OnTriggerOnce.Invoke();
    }

    public void Release()
    {
        OnRelease.Invoke();
    }
}
