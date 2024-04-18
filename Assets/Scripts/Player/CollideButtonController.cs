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
            buttonTrigger.TriggerOnce();
            if (!CurrentButtonTriggers.Contains(buttonTrigger))
            {
                CurrentButtonTriggers.Add(buttonTrigger);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out ButtonTriggerController buttonTrigger))
        {
            if (CurrentButtonTriggers.Contains(buttonTrigger))
            {
                buttonTrigger.Release();
                CurrentButtonTriggers.Remove(buttonTrigger);
            }
        }
    }
}
