using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemBar : MonoBehaviour
{
    [SerializeField] ItemButton itemButtonPrefab;
    [SerializeField] UnityEvent<int> onItemSelected;
    [SerializeField] List<ItemButton> itemButtons;

    public void Init()
    {

    }

    public void OnItemSelected(int index)
    {
        itemButtons[index].OnSelect();

        for (int i = 0; i < itemButtons.Count; i++)
        {
            if (i != index)
            {
                itemButtons[i].gameObject.SetActive(false);
            }
        }

        onItemSelected?.Invoke(index);
    }
}
