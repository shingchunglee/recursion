using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTriggerController : MonoBehaviour
{
    [SerializeField] UnityEvent OnTrigger;
    [SerializeField] UnityEvent OnTriggerOnce;
    [SerializeField] UnityEvent OnRelease;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
