using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public AnimationStateController animationController;
    public MovementController movementController;
    private Vector3 startPos;
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
        animationController.OnDeath();
        movementController.canMove = false;
        StartCoroutine(Respawn(3f));
    }

    IEnumerator Respawn(float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = startPos;
        animationController.ChangeState(animationController.idleState);
        movementController.canMove = true;
    }
}
