public class IdleSit : BaseAnimationState
{
    public override string GetName()
    {
        return "IdleSit";
    }

    public override void OnEnterState(AnimationStateController controller)
    {
        controller.animator.Play("sit");
    }

    public override void OnExitState(AnimationStateController controller)
    {
    }

    public override void Update(AnimationStateController controller)
    {
    }
}