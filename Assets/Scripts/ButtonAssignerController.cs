using UnityEngine;

public class ButtonAssignerController : MonoBehaviour
{
  public enum TriggerType
  {
    OnTrigger,
    OnTriggerOnce,
    OnRelease
  }
  private ButtonTriggerController[] buttonTriggerControllers;

  private void Start()
  {
    buttonTriggerControllers = GetComponentsInChildren<ButtonTriggerController>();
  }

  public void Assign(EasierButtonAssignController.ButtonAction[] actions)
  {
    foreach (var action in actions)
    {
      switch (action.triggerType)
      {
        case TriggerType.OnTrigger:
          foreach (ButtonTriggerController triggerController in buttonTriggerControllers)
          {
            triggerController.OnTrigger.AddListener(() => action.unityEvent.Invoke());
          }
          break;
        case TriggerType.OnTriggerOnce:
          foreach (ButtonTriggerController triggerController in buttonTriggerControllers)
          {
            triggerController.OnTriggerOnce.AddListener(() => action.unityEvent.Invoke());
          }
          break;
        case TriggerType.OnRelease:
          foreach (ButtonTriggerController triggerController in buttonTriggerControllers)
          {
            triggerController.OnRelease.AddListener(() => action.unityEvent.Invoke());
          }
          break;
      }
    }
  }
}