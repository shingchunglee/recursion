public class Dead : BaseAnimationState
{
    public override string GetName()
    {
        return "Dead";
    }

    public override void OnEnterState(AnimationStateController controller)
    {
        controller.animator.Play("die");
    }

    public override void OnExitState(AnimationStateController controller)
    {
    }

    public override void Update(AnimationStateController controller)
    {
    }
}