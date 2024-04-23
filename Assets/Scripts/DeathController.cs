using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public AnimationStateController animationController;
    public NewMovementController newMovementController;
    public Vector3 startPos;
    private bool canDie = true;

    public bool original = true;
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
        newMovementController.canMove = false;
        if (original)
        {
            StartCoroutine(Respawn(3f));
        }
        else
        {
            StartCoroutine(RemoveIn(3f));
        }
    }

    IEnumerator Respawn(float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = startPos;
        animationController.ChangeState(animationController.idleState);
        newMovementController.canMove = true;
        canDie = true;
    }

    IEnumerator RemoveIn(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
