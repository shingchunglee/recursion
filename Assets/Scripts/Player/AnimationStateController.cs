using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    public Animator animator;
    private BaseAnimationState currentState;
    public Idle idleState = new Idle();
    public IdleSit idleSit = new IdleSit();
    public Walk runState = new Walk();
    public Dead deadState = new Dead();
    public Win winState = new Win();

    private void Start()
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
        if (currentState == runState) return;
        ChangeState(runState);
    }

    public void OnIdle()
    {
        if (currentState == idleState || currentState == idleSit) return;
        ChangeState(idleState);
    }

    public void OnWin()
    {
        if (currentState == winState) return;
        ChangeState(winState);
    }

    public void OnDeath()
    {
        if (currentState == deadState) return;
        ChangeState(deadState);
    }
}
