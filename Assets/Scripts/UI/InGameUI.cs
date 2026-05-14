using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScrapsNumber;
    [SerializeField] private TextMeshProUGUI HealthPointNumber;
    [SerializeField] private TextMeshProUGUI WaveTimerNumber;
    [SerializeField] private float WaveTimerOffset;
    
    private UIAnimation UiAnimator;

    private void Awake()
    {
        UiAnimator = GetComponentInParent<UIAnimation>();
    }

    public void UpdateHealthPoint(int value, int maxValue)
    {
        HealthPointNumber.text = "Health - " + value + "/" + maxValue;
    }

    public void UpdateScrapsUI(int value)
    {
        ScrapsNumber.text = "Scraps - " + value;
    }

    public void UpdateTimerUI(float value)
    {
        WaveTimerNumber.text = "Next Wave - " + Mathf.RoundToInt(value);
    }

    public void ShowWaveTimer(bool value)
    {
        WaveTimerNumber.gameObject.SetActive(value);
    }


    /// Change this
    private bool timerVisible = false;

    public void EnableWaveTimer(bool enable)
    {
        // Stops repeated movement
        if (timerVisible == enable)
            return;

        timerVisible = enable;

        Transform waveTimerTransform = WaveTimerNumber.transform.parent;

        Vector3 offset;

        // Show timer
        if (enable)
        {
            // Move DOWN into screen
            offset = new Vector3(0, WaveTimerOffset);
        }
        else
        {
            // Move UP out of screen
            offset = new Vector3(0, -WaveTimerOffset);
        }

        UiAnimator.ChangePosition(waveTimerTransform, offset);
}
}    