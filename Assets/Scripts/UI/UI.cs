using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UI : MonoBehaviour
{

    [SerializeField] private GameObject[] uiFeatures;
    [SerializeField] private GameObject gameplay;

    private UISettings UI_Settings;
    private MainMenuUI UI_MainMenu;
    private InGameUI UI_InGame;

    private void Awake()
    {
        UI_Settings = GetComponentInChildren<UISettings>(true);
        UI_MainMenu = GetComponentInChildren<MainMenuUI>(true);
        UI_InGame = GetComponentInChildren<InGameUI>(true);

        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        if(currentScene == "level1")
        {
            // Launch with MainMenu
            SwitchTo(UI_MainMenu.gameObject);

            gameplay.SetActive(false);
        }
        else
        {
            // Other Levels
            SwitchTo(UI_InGame.gameObject);
            gameplay.SetActive(true);
            EnemySpwanManage enemySpwan = FindFirstObjectByType<EnemySpwanManage>();

            if(enemySpwan != null)
            {
                enemySpwan.enabled = true;
            }
        }

        
    }

    public void SwitchTo(GameObject uiToEnable)
    {
        foreach (GameObject ui in uiFeatures)
        {
            ui.SetActive(false);
        }

        uiToEnable.SetActive(true);
    }

    public void StartGame()
    {
        SwitchTo(UI_InGame.gameObject);

        gameplay.SetActive(true);

        EnemySpwanManage enemySpawner = FindFirstObjectByType<EnemySpwanManage>();

        if(enemySpawner != null)
        {
            enemySpawner.enabled = true;
        }

    }

    public void QuitButton()
    {
        if (EditorApplication.isPlaying)
            EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }
}
