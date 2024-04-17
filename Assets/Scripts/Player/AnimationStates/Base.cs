public abstract class BaseAnimationState
{
    public abstract void OnEnterState(AnimationStateController controller);
    public abstract void OnExitState(AnimationStateController controller);
    public abstract void Update(AnimationStateController controller);
}