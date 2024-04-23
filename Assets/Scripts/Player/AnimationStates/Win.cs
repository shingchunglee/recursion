public class Win : BaseAnimationState
{
    public override string GetName()
    {
        return "Win";
    }

    public override void OnEnterState(AnimationStateController controller)
    {
        controller.animator.Play("win");
    }

    public override void OnExitState(AnimationStateController controller)
    {
    }

    public override void Update(AnimationStateController controller)
    {
    }
}