using Spine;
using Spine.Unity;
using UltEvents;
using UnityEngine;

public class AnimationStateEventHandler : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeletonAnimation;
    [SerializeField, SpineEvent(dataField: "skeletonAnimation", fallbackToTextField: true)]
    string eventName;
    [SerializeField] UltEvent OnTriggerEvent;

    EventData eventData;

    private void Start()
    {
        eventData = skeletonAnimation.Skeleton.Data.FindEvent(eventName);
        skeletonAnimation.AnimationState.Event += HandleAnimationStateEvent;
    }

    void HandleAnimationStateEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (eventData == e.Data)
        {
            OnTriggerEvent?.Invoke();
        }
    }
}
