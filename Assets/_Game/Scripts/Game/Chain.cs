using Sirenix.OdinInspector;
using UltEvents;
using UnityEngine;

public class Chain : MonoBehaviour
{
    [SerializeField] float interval;
    [SerializeField] UltEvent main;
    [SerializeField] UltEvent next;

    [Button]
    public void PlayMain()
    {
        main?.Invoke();

        ScheduleUtils.DelayTask(interval, () =>
        {
            next?.Invoke();
        });
    }
}
