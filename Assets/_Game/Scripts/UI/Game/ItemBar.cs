using UnityEngine;
using UnityEngine.Events;

public class ItemBar : MonoBehaviour
{
    [SerializeField] ItemButton itemButtonPrefab;

    [SerializeField] UnityEvent<int> onItemSelected;

    public void Init()
    {

    }

    public void OnItemSelected(int index)
    {
        Debug.Log("select " + index);

        onItemSelected?.Invoke(index);
    }
}
