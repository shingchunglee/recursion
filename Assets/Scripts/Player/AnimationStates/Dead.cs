public class Dead : BaseAnimationState
{
    public override void OnEnterState(AnimationStateController controller)
    {
        controller.animator.Play("dead");
    }

    public override void OnExitState(AnimationStateController controller)
    {
    }

    public override void Update(AnimationStateController controller)
    {
    }
}