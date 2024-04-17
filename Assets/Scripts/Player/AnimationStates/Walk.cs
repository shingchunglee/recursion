public class Walk : BaseAnimationState
{
    public override void OnEnterState(AnimationStateController controller)
    {
        controller.animator.Play("walk");
    }

    public override void OnExitState(AnimationStateController controller)
    {
    }

    public override void Update(AnimationStateController controller)
    {
    }
}