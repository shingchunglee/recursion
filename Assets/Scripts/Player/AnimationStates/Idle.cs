using System.Collections;
using UnityEngine;

public class Idle : BaseAnimationState
{
    private Coroutine coroutine;
    public override void OnEnterState(AnimationStateController controller)
    {
        controller.animator.Play("idle");
        coroutine = controller.StartCoroutine(Sit(controller));
    }

    public override void OnExitState(AnimationStateController controller)
    {
        controller.StopCoroutine(coroutine);
    }

    public override void Update(AnimationStateController controller)
    {
    }

    IEnumerator Sit(AnimationStateController controller)
    {
        yield return new WaitForSeconds(5f);
        controller.ChangeState(controller.idleSit);
    }
}