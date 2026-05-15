using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    public static bool level1Completed;

    public static void CompleteLevel1()
    {
        level1Completed = true;
        PlayerPrefs.SetInt("Level1Completed",1);
        PlayerPrefs.Save();
    }

    public static void LoadProgress()
    {
        level1Completed = PlayerPrefs.GetInt("Level1completed", 0) == 1;
    }
}
