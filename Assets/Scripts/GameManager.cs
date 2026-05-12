using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int Scraps;
    [SerializeField] private int MaxHp;
    [SerializeField] private int CurrentHp;

    private InGameUI UI_InGame;

    private void Awake()
    {
        UI_InGame = FindFirstObjectByType<InGameUI>();
    }

    private void Start()
    {
        CurrentHp = MaxHp;
        UI_InGame.UpdateHealthPoint(CurrentHp, MaxHp);
    }

    public void UpdateHp(int value)
    {
        CurrentHp += value;
        UI_InGame.UpdateHealthPoint(CurrentHp, MaxHp);

    }

    public void UpdateScraps(int value)
    {
        Scraps = Scraps + value;
        UI_InGame.UpdateScrapsUI(Scraps);
    }
}
