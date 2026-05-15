using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonsUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private UIAnimation UiAnim;
    private RectTransform RectTransform;

    [SerializeField] private float ShowCaseScale = 1.5f;
    [SerializeField] private float ScaleUpDuration = .3f;

    private Coroutine ScaleCoroutine;

    private void Awake()
    {
        UiAnim = GetComponentInParent<UIAnimation>();
        RectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(ScaleCoroutine != null)
            StopCoroutine(ScaleCoroutine);
        ScaleCoroutine = StartCoroutine(UiAnim.ChangeScaleCoroutine(RectTransform, ShowCaseScale, ScaleUpDuration));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(ScaleCoroutine != null)
            StopCoroutine(ScaleCoroutine);
       ScaleCoroutine = StartCoroutine(UiAnim.ChangeScaleCoroutine(RectTransform, 1 , ScaleUpDuration));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransform.localScale = new Vector3(1, 1, 1);
    }
}
