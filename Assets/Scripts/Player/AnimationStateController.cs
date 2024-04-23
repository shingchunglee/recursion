using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    public Animator animator;
    public BaseAnimationState currentState;
    public Idle idleState = new Idle();
    public IdleSit idleSit = new IdleSit();
    public Walk walkState = new Walk();
    public Dead deadState = new Dead();
    public Win winState = new Win();

    private void Awake()
    {
        ChangeState(idleState);
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.Update(this);
        }
    }

    public void ChangeState(BaseAnimationState state)
    {
        if (currentState != null) { currentState.OnExitState(this); }
        currentState = state;
        currentState.OnEnterState(this);
    }

    public void OnRun()
    {
        if (currentState == walkState || currentState == winState || currentState == deadState) return;
        ChangeState(walkState);
    }

    public void OnIdle()
    {
        if (currentState == idleState || currentState == idleSit || currentState == winState || currentState == deadState) return;
        ChangeState(idleState);
    }

    public void OnWin()
    {
        if (currentState == winState || currentState == deadState) return;
        ChangeState(winState);
    }

    public void OnDeath()
    {
        if (currentState == winState || currentState == deadState) return;
        ChangeState(deadState);
    }

    public BaseAnimationState GetStateByName(string name)
    {
        switch (name)
        {
            case "Idle":
                return idleState;
            case "IdleSit":
                return idleSit;
            case "Walk":
                return walkState;
            case "Win":
                return winState;
            case "Dead":
                return deadState;
            default:
                return null;
        }
    }
}
