using UltEvents;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] UltEvent OnStart;

    private void Start()
    {
        OnStart?.Invoke();
    }
}
