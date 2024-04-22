using UnityEngine;
using UnityEngine.Events;

public class NewInputManager : MonoBehaviour
{
    public UnityEvent MoveLeft;
    public UnityEvent MoveRight;
    public UnityEvent MoveUp;
    public UnityEvent MoveDown;
    public UnityEvent ReleaseLeft;
    public UnityEvent ReleaseRight;
    public UnityEvent ReleaseUp;
    public UnityEvent ReleaseDown;
    public UnityEvent ReleaseAll;
    public UnityEvent DeleteDown;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            ReleaseLeft.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            MoveRight.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            ReleaseRight.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            MoveUp.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            ReleaseUp.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            MoveDown.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            ReleaseDown.Invoke();
        }

        if (
            !Input.GetKey(KeyCode.LeftArrow)
            && !Input.GetKey(KeyCode.RightArrow)
            && !Input.GetKey(KeyCode.UpArrow)
            && !Input.GetKey(KeyCode.DownArrow)
            && !Input.GetKey(KeyCode.W)
            && !Input.GetKey(KeyCode.A)
            && !Input.GetKey(KeyCode.S)
            && !Input.GetKey(KeyCode.D)
        )
        {
            ReleaseAll.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            DeleteDown.Invoke();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
