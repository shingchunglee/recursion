using UnityEngine;

public class InputAssignerController : MonoBehaviour
{
  public enum TriggerType
  {
    MoveLeft,
    MoveRight,
    MoveUp,
    MoveDown,
    ReleaseLeft,
    ReleaseRight,
    ReleaseUp,
    ReleaseDown,
    ReleaseAll,
    DeleteDown
  }
  private NewInputManager inputManager;

  private void Awake()
  {
    inputManager = GetComponentInChildren<NewInputManager>();
  }

  public void Assign(EasierInputAssignController.InputAction[] actions)
  {
    inputManager = GetComponentInChildren<NewInputManager>();
    foreach (var action in actions)
    {
      switch (action.triggerType)
      {
        case TriggerType.MoveLeft:
          inputManager.MoveLeft.AddListener(() => action.unityEvent.Invoke());
          break;
        case TriggerType.MoveRight:
          inputManager.MoveRight.AddListener(() => action.unityEvent.Invoke());
          break;
        case TriggerType.MoveUp:
          inputManager.MoveUp.AddListener(() => action.unityEvent.Invoke());
          break;
        case TriggerType.MoveDown:
          inputManager.MoveDown.AddListener(() => action.unityEvent.Invoke());
          break;
        case TriggerType.ReleaseLeft:
          inputManager.ReleaseLeft.AddListener(() => action.unityEvent.Invoke());
          break;
        case TriggerType.ReleaseRight:
          inputManager.ReleaseRight.AddListener(() => action.unityEvent.Invoke());
          break;
        case TriggerType.ReleaseUp:
          inputManager.ReleaseUp.AddListener(() => action.unityEvent.Invoke());
          break;
        case TriggerType.ReleaseDown:
          inputManager.ReleaseDown.AddListener(() => action.unityEvent.Invoke());
          break;
        case TriggerType.ReleaseAll:
          inputManager.ReleaseAll.AddListener(() => action.unityEvent.Invoke());
          break;
        case TriggerType.DeleteDown:
          inputManager.DeleteDown.AddListener(() => action.unityEvent.Invoke());
          break;
      }
    }
  }
}