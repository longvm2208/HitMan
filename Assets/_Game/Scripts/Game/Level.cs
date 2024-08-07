using UltEvents;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] UltEvent OnStart;
    [SerializeField] UltEvent[] OnSelect;

    private void Start()
    {
        OnStart?.Invoke();
    }

    public void Select(int i)
    {
        OnSelect[i].Invoke();
    }

    public void Win()
    {
        UIManager.Instance.OpenPopup(PopupId.Win);
    }

    public void Lose()
    {
        UIManager.Instance.OpenPopup(PopupId.Lose);
    }
}
