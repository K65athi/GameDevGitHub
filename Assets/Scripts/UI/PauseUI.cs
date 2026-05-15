using UnityEngine;

public class PauseUI : MonoBehaviour
{
    private UI ui;
    private InGameUI UiInGame;
    [SerializeField] private GameObject[] PauseUiFeatures;

    void Awake()
    {
        ui = GetComponentInParent<UI>();
        UiInGame = ui.GetComponentInChildren<InGameUI>(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ui.SwitchTo(UiInGame.gameObject);
    }

    public void SwitchPauseUIFeatures(GameObject elementToEnable)
    {
        foreach (GameObject obj in PauseUiFeatures)
        {
            obj.SetActive(false);
        }

        elementToEnable.SetActive(true);
    }
    void OnEnable()
    {
        Time.timeScale = 0;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }
}
