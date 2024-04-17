using UnityEngine;

public class CollideButtonController : MonoBehaviour
{
    ButtonTriggerController CurrentButtonTrigger;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CurrentButtonTrigger != null)
        {
            CurrentButtonTrigger.Trigger();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ButtonTriggerController buttonTrigger))
        {
            CurrentButtonTrigger = buttonTrigger;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out ButtonTriggerController buttonTrigger))
        {
            if (CurrentButtonTrigger == buttonTrigger)
            {
                CurrentButtonTrigger.Release();
                CurrentButtonTrigger = null;
            }
        }
    }
}
