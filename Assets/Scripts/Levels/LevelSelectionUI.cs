using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionUI : MonoBehaviour
{
    [SerializeField] private Button level2button;

    private void Start()
    {
        LevelProgress.LoadProgress();

        level2button.interactable = LevelProgress.level1Completed;
    }
}

