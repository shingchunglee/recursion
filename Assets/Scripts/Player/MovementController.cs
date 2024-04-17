using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    private float horizontalMovement;
    private float verticalMovement;
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0).normalized;
        Debug.Log(movement);
        transform.Translate(movement * 2f * Time.deltaTime);
    }

    public void MoveLeft()
    {
        horizontalMovement = -1f;
        spriteRenderer.flipX = true;
    }

    public void MoveRight()
    {
        horizontalMovement = 1f;
        spriteRenderer.flipX = false;
    }

    public void MoveUp()
    {
        verticalMovement = 1f;
    }

    public void MoveDown()
    {
        verticalMovement = -1f;
    }

    public void StopHorizontal()
    {
        horizontalMovement = 0f;
    }

    public void StopVertical()
    {
        verticalMovement = 0f;
    }
}
