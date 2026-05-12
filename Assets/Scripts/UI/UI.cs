using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject[] uiFeatures;

    private UISettings UI_Settings;
    private MainMenuUI UI_MainMenu;

    private void Awake()
    {
        UI_Settings = GetComponentInChildren<UISettings>(true);
        UI_MainMenu = GetComponentInChildren<MainMenuUI>(true);

        SwitchTo(UI_Settings.gameObject);
        SwitchTo(UI_MainMenu.gameObject);
    }

    public void SwitchTo(GameObject uiToEnable)
    {
        foreach (GameObject ui in uiFeatures)
        {
            ui.SetActive(false);
        }

        uiToEnable.SetActive(true);
    }

    public void QuitButton()
    {
        if (EditorApplication.isPlaying)
            EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }
}
