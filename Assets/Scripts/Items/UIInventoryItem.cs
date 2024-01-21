using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class UIInventoryItem : MonoBehaviour
{
    [SerializeField] Image image_item;
    [SerializeField] TMP_Text item_quantity;
    [SerializeField] Image image_border;

    public event Action<UIInventoryItem> OnItemClicked, OnItemBeginDrag, OnItemEndDrag, OnItemDroppedOn, OnRightMouseBtnClicked;

    private bool empty = true;

    public void Awake()
    {
        ResetData();
        DeSelect();
    }

    public void ResetData()
    {
        this.image_item.gameObject.SetActive(false);
        empty = true;
    }

    public void DeSelect()
    {
        image_border.enabled = false;
    }

    public void SetData(Sprite sprite, int quantity)
    {
        this.image_item.gameObject.SetActive(true);
        this.image_item.sprite = sprite;
        this.item_quantity.text += quantity + "";
        empty = false;
    }

    public void Select()
    {
        image_border.enabled = true;
    }

    public void OnBeginDrag()
    {
        if (empty)
            return;
        OnItemBeginDrag?.Invoke(this);
    }

    public void OnDrop()
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OneEndDrag()
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnPointerClick(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        if (pointerData.button == PointerEventData.InputButton.Right )
        {
            OnRightMouseBtnClicked?.Invoke(this);
        }
        else
        {
            OnItemClicked?.Invoke(this);
        }
    }
}
