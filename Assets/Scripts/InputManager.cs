using System;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField] UnityEvent MoveLeft;
    [SerializeField] UnityEvent MoveRight;
    [SerializeField] UnityEvent MoveUp;
    [SerializeField] UnityEvent MoveDown;
    [SerializeField] UnityEvent ReleaseHorizontal;
    [SerializeField] UnityEvent ReleaseVertical;
    [SerializeField] UnityEvent ReleaseAll;
    // Start is called before the first frame update
    void Start()
    {

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
