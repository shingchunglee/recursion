using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollideConveyerController : MonoBehaviour
{
    NewMovementController movementController;
    public bool[] moving = new bool[4]; // TOP, BOTTOM, LEFT, RIGHT

    private void Start()
    {
        movementController = GetComponent<NewMovementController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ConveyerController conveyer))
        {
            conveyer.Move(movementController);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out ConveyerController conveyer))
        {
            conveyer.Stop(movementController);
        }
    }
}
