using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public AnimationStateController animationController;
    public MovementController movementController;
    public NewMovementController newMovementController;
    private Vector3 startPos;
    private bool canDie = true;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Die()
    {
        if (!canDie) return;
        canDie = false;
        animationController.OnDeath();
        movementController.canMove = false;
        newMovementController.canMove = false;
        StartCoroutine(Respawn(3f));
    }

    IEnumerator Respawn(float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = startPos;
        animationController.ChangeState(animationController.idleState);
        movementController.canMove = true;
        newMovementController.canMove = true;
        canDie = true;
    }
}
