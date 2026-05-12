using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[System.Serializable]
public class WavesDetails
{
    public int basicEnemy;
    public int fastEnemy;
}

public class EnemySpwanManage : MonoBehaviour
{
    [SerializeField] private WavesDetails[] Waves;
    private int WaveIndex;
    [SerializeField] private Transform Respwan;
    [SerializeField] private float SpawnCooldown;
    private float spawanTime;
    [SerializeField] private float NextWaveTime = 5f;
    private bool WaveFinished;

    private List<GameObject> enemyList;
    private InGameUI ui_InGame;

    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject basicEnemy;
    [SerializeField] private GameObject fastEnemy;

    private void Start()
    {
        ui_InGame = FindFirstObjectByType<InGameUI>();

        enemyList = NewEnemy();
    }

    private void Update()
    {
       spawanTime -= Time.deltaTime;
         if(spawanTime <= 0 && enemyList.Count > 0)
          {
                CreateEnemy();
                spawanTime = SpawnCooldown;
          }

          if(enemyList.Count <= 0 && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 && !WaveFinished)
        {
            WaveFinished = true;
            StartCoroutine(NewWave());
        }
    }
    private void CreateEnemy()
    {
        GameObject randomEnemy = RandomEnemy();
         GameObject newEnemy = Instantiate(randomEnemy, Respwan.position, Quaternion.identity);
    }

    private GameObject RandomEnemy()
    {
        int randomIndex = Random.Range(0, enemyList.Count);
        GameObject ChosenEnemy = enemyList[randomIndex];
        enemyList.Remove(ChosenEnemy);
        return ChosenEnemy;
    }

    private List<GameObject> NewEnemy()
    {
       if (WaveIndex >= Waves.Length)
       {
            Debug.Log("Waves Completed");
            return new List<GameObject>();
       }

       List<GameObject> newEnemyList = new List<GameObject>();

       for(int i = 0; i < Waves[WaveIndex].basicEnemy; i++)
       {
            newEnemyList.Add(basicEnemy);
       }

        for(int i = 0; i < Waves[WaveIndex].fastEnemy; i++)
        {
            newEnemyList.Add(fastEnemy);
        }

        WaveIndex = WaveIndex + 1;

        return newEnemyList;
    }

    private IEnumerator NewWave()
    {
        float countdown = NextWaveTime;
        while(countdown > 0)
        {
            ui_InGame.UpdateTimerUI(countdown);
            countdown = countdown - Time.deltaTime;
            yield return null;
        }

        enemyList = NewEnemy();
        WaveFinished = false;
    }

    [ContextMenu("Next Wave")]
    private void NextWave()
    {
        enemyList = NewEnemy();
    }
    
}
