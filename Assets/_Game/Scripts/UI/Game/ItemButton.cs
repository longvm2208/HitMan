using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] Image itemImage;
	[SerializeField] RectTransform itemRt;

	[SerializeField] int index;
	[SerializeField] ItemBar bar;

    private void OnValidate()
    {
        if (itemImage != null && itemRt == null)
		{
			itemRt = itemImage.transform as RectTransform;
		}
    }

    public void Init(int index, ItemBar bar, Sprite itemSprite)
	{
		this.index = index;
		this.bar = bar;

        float max = itemRt.sizeDelta.x;
        itemImage.sprite = itemSprite;
		itemImage.SetNativeSize();

		if (Mathf.Max(itemRt.sizeDelta.x, itemRt.sizeDelta.y) > max)
		{
			if (itemRt.sizeDelta.x > itemRt.sizeDelta.y)
			{
				itemRt.sizeDelta = new Vector2(max, itemRt.sizeDelta.y * itemRt.sizeDelta.x / max);
			}
			else
			{
				itemRt.sizeDelta = new Vector2(itemRt.sizeDelta.x * itemRt.sizeDelta.y / max, max);
			}
		}
	}

	#region UI Events
	public void OnClick()
	{
		bar.OnItemSelected(index);
	}
	#endregion
}
