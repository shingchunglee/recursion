using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTriggerController : MonoBehaviour
{
    public UnityEvent OnTrigger;
    public UnityEvent OnTriggerOnce;
    public UnityEvent OnRelease;
    public AudioClip keySound;
    [SerializeField] DisableButtonController disableButtonController;

    // Start is called before the first frame update
    void Start()
    {
        disableButtonController = GetComponent<DisableButtonController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Trigger()
    {
        if (disableButtonController.isDisabled) return;
        OnTrigger.Invoke();
    }

    public void TriggerOnce()
    {
        if (disableButtonController.isDisabled) return;
        GameManager.Instance.playSoundController.PlayClipOnce(keySound);
        OnTriggerOnce.Invoke();
    }

    public void Release()
    {
        if (disableButtonController.isDisabled) return;
        OnRelease.Invoke();
    }
}
