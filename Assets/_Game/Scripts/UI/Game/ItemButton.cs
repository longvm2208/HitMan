using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
	[SerializeField] RectTransform myRt;
    [SerializeField] Image itemImage;
	[SerializeField] RectTransform itemRt;

	[SerializeField] int index;
	[SerializeField] ItemBar bar;

	bool selected;

    private void OnValidate()
    {
		if (myRt == null)
		{
			myRt = transform as RectTransform;
		}

        if (itemImage != null && itemRt == null)
		{
			itemRt = itemImage.transform as RectTransform;
		}
    }

    private void Start()
    {
		itemRt.DOScale(1.2f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
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

	public void OnSelect()
	{
		selected = true;
		myRt.DOAnchorPosX(0, 0.5f);
		itemRt.DOKill();
	}

	#region UI Events
	public void OnClick()
	{
		if (selected) return;

		bar.OnItemSelected(index);
	}
	#endregion
}
