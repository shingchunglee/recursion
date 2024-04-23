using UnityEngine;

public class Clone : MonoBehaviour
{
  NewMovementController newMovementController;
  WinTriggerController winTriggerController;
  CollideButtonController collideButtonController;
  AnimationStateController animationStateController;
  DeathController deathController;
  CollideConveyerController collideConveyerController;
  TeleportableController teleportableController;

  private void Awake()
  {
    newMovementController = GetComponent<NewMovementController>();
    winTriggerController = GetComponent<WinTriggerController>();
    collideButtonController = GetComponent<CollideButtonController>();
    animationStateController = GetComponent<AnimationStateController>();
    deathController = GetComponent<DeathController>();
    collideConveyerController = GetComponent<CollideConveyerController>();
    teleportableController = GetComponent<TeleportableController>();
  }

  public void ClonePlayer(Clone original)
  {
    newMovementController.upMovement = original.newMovementController.upMovement;
    newMovementController.downMovement = original.newMovementController.downMovement;
    newMovementController.leftMovement = original.newMovementController.leftMovement;
    newMovementController.rightMovement = original.newMovementController.rightMovement;

    deathController.startPos = original.deathController.startPos;

    EasierButtonAssignController easierButtonAssignController = GetComponent<EasierButtonAssignController>();
    if (easierButtonAssignController != null) easierButtonAssignController.Assign();
    EasierInputAssignController easierInputAssignController = GetComponent<EasierInputAssignController>();
    if (easierInputAssignController != null) easierInputAssignController.Assign();


  }
}