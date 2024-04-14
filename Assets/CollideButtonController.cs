using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideButtonController : MonoBehaviour
{
    ButtonTriggerController CurrentButtonTrigger;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CurrentButtonTrigger != null)
        {
            // Debug.Log(CurrentButtonTrigger);
            CurrentButtonTrigger.Trigger();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.TryGetComponent<ButtonTriggerController>(out ButtonTriggerController buttonTrigger))
        {
            // buttonTrigger.Trigger();
            CurrentButtonTrigger = buttonTrigger;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.TryGetComponent<ButtonTriggerController>(out ButtonTriggerController buttonTrigger))
        {
            if (CurrentButtonTrigger == buttonTrigger)
            {
                CurrentButtonTrigger = null;
            }
        }
    }
}
