using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

     public void ChangeScale(Transform transform, float TargetScale, float duration = .3f)
    {
        RectTransform rectTransform = transform.GetComponent<RectTransform>();
        StartCoroutine(ChangeScaleCoroutine(rectTransform, TargetScale, duration));
    }

    public IEnumerator ChangeScaleCoroutine(RectTransform rectTransform, float NewScale, float duration = .25f)
    {
        float time = 0;
        Vector3 InitialScale = rectTransform.localScale;
        Vector3 TargetScale = new Vector3(NewScale, NewScale, NewScale);

        while (time < duration)
        {
            rectTransform.localScale = Vector3.Lerp(InitialScale, TargetScale, time / duration);
            time = time + Time.deltaTime;
            yield return null;
        }
    }
}
