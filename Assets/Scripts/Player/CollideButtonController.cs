using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollideButtonController : MonoBehaviour
{
    List<ButtonTriggerController> CurrentButtonTriggers = new();

    void FixedUpdate()
    {
        if (CurrentButtonTriggers.Count() > 0)
        {
            foreach (var trigger in CurrentButtonTriggers)
            {
                trigger.Trigger();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ButtonTriggerController buttonTrigger))
        {
            ReliableOnTriggerExit2D.NotifyTriggerEnter(other, gameObject, OnTriggerExit2D);
            if (!CurrentButtonTriggers.Contains(buttonTrigger))
            {
                CurrentButtonTriggers.Add(buttonTrigger);
            }
            buttonTrigger.TriggerOnce();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out ButtonTriggerController buttonTrigger))
        {
            ReliableOnTriggerExit2D.NotifyTriggerExit(other, gameObject);
            if (CurrentButtonTriggers.Contains(buttonTrigger))
            {
                CurrentButtonTriggers.Remove(buttonTrigger);
                buttonTrigger.Release();
            }
        }
    }
}
