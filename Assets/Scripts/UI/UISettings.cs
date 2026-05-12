using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISettings : MonoBehaviour
{
    private CameraControl CamController;

    [Header("Keyboard Sensitivity")]
    [SerializeField] private Slider KeyboardSens;
    [SerializeField] private TextMeshProUGUI KeyBoardSensNumber;
    [SerializeField] private string KeyboardSensParameter = "KeyBoardSens";
    [SerializeField] private float MinKeyBoardSens = 0;
    [SerializeField] private float MaxKeyBoardSens = 100;

    [Header("Mouse Sensitivity")]
    [SerializeField] private Slider MouseSens;
    [SerializeField] private TextMeshProUGUI MouseSensNumber;
    [SerializeField] private string MouseSnesParameter = "MouseSens";
    [SerializeField] private float MinMouseSens = 0;
    [SerializeField] private float MaxMouseSens = 10;

    private void Awake()
    {
        CamController = FindFirstObjectByType<CameraControl>();
    }

    public void KeyboardSensetivity(float value)
    {
        float NewSens = Mathf.Lerp(MinKeyBoardSens, MaxKeyBoardSens, value);
        CamController.AdjustKeyBoardSens(NewSens);

        KeyBoardSensNumber.text = Mathf.RoundToInt(value * 100) + "%";
    }

    public void MouseSensetivity(float value)
    {
        float NewSens = Mathf.Lerp(MinMouseSens, MaxMouseSens, value);
        CamController.AdjustMouseSens(NewSens);

        MouseSensNumber.text = Mathf.RoundToInt(value * 100) + "%";
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(KeyboardSensParameter, KeyboardSens.value);
        PlayerPrefs.SetFloat(MouseSnesParameter, MouseSens.value);
    }

    private void OnEnable()
    {
        KeyboardSens.value = PlayerPrefs.GetFloat(KeyboardSensParameter, .3f);
        MouseSens.value = PlayerPrefs.GetFloat(MouseSnesParameter, .3f);
    }
}
