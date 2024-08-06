using Sirenix.OdinInspector;
using Spine.Unity;
using UnityEngine;

public class SkeletonAnimationController : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeletonAnimation;

    Spine.AnimationState animationState;

    private void OnValidate()
    {
        if (skeletonAnimation == null)
        {
            skeletonAnimation = GetComponent<SkeletonAnimation>();
        }
    }

    private void Awake()
    {
        animationState = skeletonAnimation.AnimationState;
    }

    [Button(ButtonStyle.FoldoutButton)]
    public void SetAnimation(int trackIndex, string animationName, bool loop)
    {
        animationState.SetAnimation(trackIndex, animationName, loop);
    }

    [Button(ButtonStyle.FoldoutButton)]
    public void SetAnimation(int trackIndex, string animationName, bool loop, float speed)
    {
        animationState.SetAnimation(trackIndex, animationName, loop).TimeScale = speed;
    }

    [Button(ButtonStyle.FoldoutButton)]
    public void AddAnimation(int trackIndex, string animationName, bool loop, float delay)
    {
        animationState.AddAnimation(trackIndex, animationName, loop, delay);
    }
}
