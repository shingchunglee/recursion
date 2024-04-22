using System;
using UnityEngine;
using UnityEngine.Events;

public class EasierInputAssignController : MonoBehaviour
{
  [Serializable]
  public struct InputAssign
  {
    public InputAssignerController inputAssignerController;
    public InputAction[] inputAction;
  }

  [Serializable]
  public struct InputAction
  {
    public UnityEvent unityEvent;
    public InputAssignerController.TriggerType triggerType;
  }

  [SerializeField] InputAssign inputAssign;

  private void Start()
  {
    Assign();
  }

  public void Assign()
  {
    inputAssign.inputAssignerController.Assign(inputAssign.inputAction);
  }
}