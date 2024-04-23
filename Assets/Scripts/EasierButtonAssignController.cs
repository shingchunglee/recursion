using System;
using UnityEngine;
using UnityEngine.Events;

public class EasierButtonAssignController : MonoBehaviour
{
  [Serializable]
  public struct ButtonAssign
  {
    public ButtonAssignerController buttonAssignerController;
    public ButtonAction[] buttonAction;
  }

  [Serializable]
  public struct ButtonAction
  {
    public UnityEvent unityEvent;
    public ButtonAssignerController.TriggerType triggerType;
  }

  [SerializeField] ButtonAssign[] buttonAssigns;

  private void Start()
  {
  }

  public void Assign()
  {
    foreach (var buttonAssign in buttonAssigns)
    {
      buttonAssign.buttonAssignerController.Assign(buttonAssign.buttonAction);
    }
  }
}