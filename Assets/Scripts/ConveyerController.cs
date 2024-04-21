using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConveyerController : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    [SerializeField] Direction direction;

    private void Start()
    {
        switch (direction)
        {
            case Direction.Up:
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case Direction.Down:
                transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            case Direction.Left:
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case Direction.Right:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
    }

    public void Move(NewMovementController movementController)
    {
        switch (direction)
        {
            case Direction.Up:
                movementController.MoveUp();
                break;
            case Direction.Down:
                movementController.MoveDown();
                break;
            case Direction.Left:
                movementController.MoveLeft();
                break;
            case Direction.Right:
                movementController.MoveRight();
                break;
        }
    }

    public void Stop(NewMovementController movementController)
    {
        switch (direction)
        {
            case Direction.Up:
                movementController.StopUp();
                break;
            case Direction.Down:
                movementController.StopDown();
                break;
            case Direction.Left:
                movementController.StopLeft();
                break;
            case Direction.Right:
                movementController.StopRight();
                break;
        }
    }
}
