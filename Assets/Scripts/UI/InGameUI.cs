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
    
}    