using System;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent MoveLeft;
    public UnityEvent MoveRight;
    public UnityEvent MoveUp;
    public UnityEvent MoveDown;
    public UnityEvent ReleaseHorizontal;
    public UnityEvent ReleaseVertical;
    public UnityEvent ReleaseAll;
    public UnityEvent DeleteDown;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            DeleteDown.Invoke();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput < 0)
        {
            MoveLeft.Invoke();
        }
        if (horizontalInput > 0)
        {
            MoveRight.Invoke();
        }
        if (verticalInput < 0)
        {
            MoveDown.Invoke();
        }
        if (verticalInput > 0)
        {
            MoveUp.Invoke();
        }
        if (horizontalInput == 0)
        {
            ReleaseHorizontal.Invoke();
        }
        if (verticalInput == 0)
        {
            ReleaseVertical.Invoke();
        }
        if (horizontalInput == 0 && verticalInput == 0)
        {
            ReleaseAll.Invoke();
        }
    }
}
