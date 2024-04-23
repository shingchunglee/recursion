using UnityEngine;

public class NewMovementController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public float leftMovement;
    public float rightMovement;
    public float upMovement;
    public float downMovement;
    public float horizontalMovement;
    public float verticalMovement;
    public bool canMove = true;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    void FixedUpdate()
    {
        if (!GameManager.Instance.canMove || !canMove) return;
        horizontalMovement = rightMovement - leftMovement;
        verticalMovement = upMovement - downMovement;
        Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0);

        transform.Translate(movement * speed * transform.localScale.x * Time.deltaTime);
    }

    public void MoveLeft()
    {
        leftMovement += 1f;
        spriteRenderer.flipX = true;
    }

    public void MoveRight()
    {
        rightMovement += 1f;
        spriteRenderer.flipX = false;
    }

    public void MoveUp()
    {
        upMovement += 1f;
    }

    public void MoveDown()
    {
        downMovement += 1f;
    }

    public void StopLeft()
    {
        leftMovement -= 1f;
        if (leftMovement < 0f) leftMovement = 0f;
    }

    public void StopRight()
    {
        rightMovement -= 1f;
        if (rightMovement < 0f) rightMovement = 0f;
    }

    public void StopUp()
    {
        upMovement -= 1f;
        if (upMovement < 0f) upMovement = 0f;
    }

    public void StopDown()
    {
        downMovement -= 1f;
        if (downMovement < 0f) downMovement = 0f;
    }
}
