using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    private UI ui;
    private PauseUI UiPause;

    [SerializeField] private GameObject NotEnoughScraps;
    [SerializeField] private GameObject VictoryUI;
    [SerializeField] private GameObject GameOverUI;

    [SerializeField] private TextMeshProUGUI ScrapsNumber;
    [SerializeField] private TextMeshProUGUI HealthPointNumber;
    [SerializeField] private TextMeshProUGUI WaveTimerNumber;
    [SerializeField] private float WaveTimerOffset;
    
    private UIAnimation UiAnimator;

    private void Awake()
    {
        UiAnimator = GetComponentInParent<UIAnimation>();
        ui = GetComponentInParent<UI>();
        UiPause = ui.GetComponentInChildren<PauseUI>(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            ui.SwitchTo(UiPause.gameObject);
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

    public void ShowWarningText()
    {
        StopAllCoroutines();
        StartCoroutine(WarningCoroutine());
    }

    private IEnumerator WarningCoroutine()
    {
        NotEnoughScraps.SetActive(true);
        yield return new WaitForSeconds(1f);
        NotEnoughScraps.SetActive(false);
    }
    /// Change this
    private bool timerVisible = false;

    public void EnableWaveTimer(bool enable)
    {
        if (timerVisible == enable)
            return;

        timerVisible = enable;

        Transform waveTimerTransform = WaveTimerNumber.transform.parent;

        Vector3 offset;

        if (enable)
        {
            offset = new Vector3(0, WaveTimerOffset);
        }
        else
        {
            offset = new Vector3(0, -WaveTimerOffset);
        }

        UiAnimator.ChangePosition(waveTimerTransform, offset);
    }

    public void ShowVictoryText()
    {
        VictoryUI.SetActive(true);
    }

    public void ShowGameOverUI()
    {
        GameOverUI.SetActive(true);
    }

    
}    