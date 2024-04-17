using UnityEngine;

public class AnimationState : MonoBehaviour
{
    private enum States
    {
        Idle,
        Win,
        Run,
        Dead
    }
    private States currentState;

    private void Start()
    {
        currentState = States.Idle;
    }

    private void Update()
    {
        switch (currentState)
        {
            case States.Idle:
                IdleUpdate();
                break;
            case States.Win:
                WinUpdate();
                break;
            case States.Run:
                RunUpdate();
                break;
            case States.Dead:
                DeadUpdate();
                break;
        }
    }

    private void IdleUpdate()
    {
        // idle animation
    }

    private void WinUpdate()
    {
        // win animation
    }

    private void RunUpdate()
    {
        // run animation
    }

    private void DeadUpdate()
    {
        // dead animation
    }

    public void ChangeState(States newState)
    {
        currentState = newState;
    }
}
