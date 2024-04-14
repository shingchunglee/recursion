using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTriggerController : MonoBehaviour
{
    [SerializeField] UnityEvent OnTrigger;
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
}
