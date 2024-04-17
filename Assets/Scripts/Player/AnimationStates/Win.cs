public class Win : BaseAnimationState
{
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