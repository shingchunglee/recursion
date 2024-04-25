using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTriggerController : MonoBehaviour
{
    public AnimationStateController animationController;
    public NewMovementController newMovementController;
    // Start is called before the first frame update
    void Start()
    {
        animationController = GetComponent<AnimationStateController>();
        newMovementController = GetComponent<NewMovementController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out WinController winController))
        {
            animationController.OnWin();
            newMovementController.canMove = false;
            winController.win();
        }
    }
}
