using UltEvents;
using UnityEngine;

public class Banana : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] Transform myTransform;
    [SerializeField] SkeletonAnimationController animationController;
    [SerializeField] UltEvent OnComplete;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            myTransform.localScale = enemy.MyTransform.localScale;

            animationController.SetAnimation(0, "Action_01", false);
            enemy.AnimationController.SetAnimation(0, "Die_01", false);
            enemy.StopPatrol();

            ScheduleUtils.DelayTask(delay, () =>
            {
                OnComplete?.Invoke();
            });
        }
    }
}
