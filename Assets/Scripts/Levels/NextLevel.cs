using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void LoadLevel2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}

