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

    public Direction direction;
    public bool setRotation = true;

    private void Start()
    {
        if (setRotation)
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
    }

    public void Move(NewMovementController movementController)
    {
        if (Mathf.RoundToInt(movementController.transform.rotation.eulerAngles.z % 360f) == 0)
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
        else if (Mathf.RoundToInt(movementController.transform.rotation.eulerAngles.z) % 360 == 90)
        {
            switch (direction)
            {
                case Direction.Up:
                    movementController.MoveRight();
                    break;
                case Direction.Down:
                    movementController.MoveLeft();
                    break;
                case Direction.Left:
                    movementController.MoveUp();
                    break;
                case Direction.Right:
                    movementController.MoveDown();
                    break;
            }
        }
        else if (Mathf.RoundToInt(movementController.transform.rotation.eulerAngles.z) % 360 == 180)
        {
            switch (direction)
            {
                case Direction.Up:
                    movementController.MoveDown();
                    break;
                case Direction.Down:
                    movementController.MoveUp();
                    break;
                case Direction.Left:
                    movementController.MoveRight();
                    break;
                case Direction.Right:
                    movementController.MoveLeft();
                    break;
            }
        }
        else if (Mathf.RoundToInt(movementController.transform.rotation.eulerAngles.z) % 360 == 270)
        {
            switch (direction)
            {
                case Direction.Up:
                    movementController.MoveLeft();
                    break;
                case Direction.Down:
                    movementController.MoveRight();
                    break;
                case Direction.Left:
                    movementController.MoveDown();
                    break;
                case Direction.Right:
                    movementController.MoveUp();
                    break;
            }
        }
    }

    public void Stop(NewMovementController movementController)
    {
        if (Mathf.RoundToInt(movementController.transform.rotation.eulerAngles.z) % 360f == 0)
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
        else if (Mathf.RoundToInt(movementController.transform.rotation.eulerAngles.z) % 360 == 90)
        {
            switch (direction)
            {
                case Direction.Up:
                    movementController.StopRight();
                    break;
                case Direction.Down:
                    movementController.StopLeft();
                    break;
                case Direction.Left:
                    movementController.StopUp();
                    break;
                case Direction.Right:
                    movementController.StopDown();
                    break;
            }
        }
        else if (Mathf.RoundToInt(movementController.transform.rotation.eulerAngles.z) % 360 == 180)
        {
            switch (direction)
            {
                case Direction.Up:
                    movementController.StopDown();
                    break;
                case Direction.Down:
                    movementController.StopUp();
                    break;
                case Direction.Left:
                    movementController.StopRight();
                    break;
                case Direction.Right:
                    movementController.StopLeft();
                    break;
            }
        }
        else if (Mathf.RoundToInt(movementController.transform.rotation.eulerAngles.z) % 360 == 270)
        {
            switch (direction)
            {
                case Direction.Up:
                    movementController.StopLeft();
                    break;
                case Direction.Down:
                    movementController.StopRight();
                    break;
                case Direction.Left:
                    movementController.StopDown();
                    break;
                case Direction.Right:
                    movementController.StopUp();
                    break;
            }
        }
    }
}
