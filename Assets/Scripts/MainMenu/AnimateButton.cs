using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AnimateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 largeScale = Vector3.one * 1.1f;
    private Vector3 smallScale = Vector3.one * 0.9f;
    private Vector3 originalScale = Vector3.one;

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(largeScale, 0.05f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(originalScale, 0.05f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(smallScale, 0.05f);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(originalScale, 0.05f);
    }

}
