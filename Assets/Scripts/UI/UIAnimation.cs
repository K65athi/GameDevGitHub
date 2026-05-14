using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    public void ChangePosition(Transform transform, Vector3 offset, float duration = .1f)
    {
        RectTransform rectTransform = transform.GetComponent<RectTransform>();
        StartCoroutine(ChangePositionCoroutine(rectTransform, offset, duration));
    }


    private IEnumerator ChangePositionCoroutine(RectTransform rectTransform, Vector3 offset, float duration)
        {
            float time = 0;

            Vector3 initialPosition = rectTransform.anchoredPosition;
            Vector3 targetPosition = initialPosition + offset;

            while (time < duration)
            {
                rectTransform.anchoredPosition = Vector3.Lerp(initialPosition, targetPosition, time / duration);
                time = time + Time.deltaTime;

                yield return null;
            }

            rectTransform.anchoredPosition = targetPosition;
        }
}
