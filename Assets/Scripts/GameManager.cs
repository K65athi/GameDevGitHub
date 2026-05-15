using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int Scraps;
    public int CurrentScraps => Scraps;

    [SerializeField] private int MaxHp;
    [SerializeField] private int CurrentHp;

    private InGameUI UI_InGame;

    private void Awake()
    {
        UI_InGame = FindFirstObjectByType<InGameUI>(FindObjectsInactive.Include);
    }

    private void Start()
    {
        CurrentHp = MaxHp;
        UI_InGame.UpdateHealthPoint(CurrentHp, MaxHp);
        UI_InGame.UpdateScrapsUI(Scraps);
    }

    public void UpdateHp(int value)
    {
        CurrentHp += value;
        UI_InGame.UpdateHealthPoint(CurrentHp, MaxHp);

        if(CurrentHp <= 0)
        {
            CurrentHp = 0;
            UI_InGame.ShowGameOverUI();

            Time.timeScale = 0f;
        }

    }

    public void UpdateScraps(int value)
    {
        Scraps = Scraps + value;
        UI_InGame.UpdateScrapsUI(Scraps);
    }
}
