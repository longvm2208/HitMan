using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class Throwable : MonoBehaviour
{
    [SerializeField] Transform myTransform;
    [SerializeField] Transform destination;
    [SerializeField] float jumpPower;
    [SerializeField] float duration;
    [SerializeField] float rotationZStart;
    [SerializeField] float rotationZEnd;
    [SerializeField] Ease ease;
    [SerializeField] UnityEvent OnComplete;

    private void OnValidate()
    {
        if (myTransform == null)
        {
            myTransform = transform;
        }
    }

    [Button]
    public void Throw()
    {
        myTransform.DOJump(destination.position, jumpPower, 1, duration).SetEase(ease);

        DOVirtual.Float(rotationZStart, rotationZEnd, duration, value =>
        {
            myTransform.ChangeRotationZ(value);
        })
            .SetEase(ease)
            .OnComplete(() =>
            {
                OnComplete?.Invoke();
            });
    }
}
