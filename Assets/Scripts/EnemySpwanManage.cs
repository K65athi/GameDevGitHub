using System.Collections;
using System.Collections.Generic;
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
    private int waveIndex;
    [SerializeField] private Transform respwan;
    [SerializeField] private float spawncooldown;
    private float spawanTime;
    [SerializeField] private float nextWaveTime = 5f;
    private bool waveFinished;

    private List<GameObject> enemyList;
    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject basicEnemy;
    [SerializeField] private GameObject fastEnemy;

    private void Start()
    {
        enemyList = NewEnemy();
    }

    private void Update()
    {
       spawanTime -= Time.deltaTime;
         if(spawanTime <= 0 && enemyList.Count > 0)
          {
                CreateEnemy();
                spawanTime = spawncooldown;
          }

          if(enemyList.Count <= 0 && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 && !waveFinished)
        {
            waveFinished = true;
            StartCoroutine(NewWave());
        }
    }
    private void CreateEnemy()
    {
        GameObject randomEnemy = RandomEnemy();
         GameObject newEnemy = Instantiate(randomEnemy, respwan.position, Quaternion.identity);
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
       if (waveIndex >= Waves.Length)
       {
            Debug.Log("Waves Completed");
            return new List<GameObject>();
       }

       List<GameObject> newEnemyList = new List<GameObject>();

       for(int i = 0; i < Waves[waveIndex].basicEnemy; i++)
       {
            newEnemyList.Add(basicEnemy);
       }

        for(int i = 0; i < Waves[waveIndex].fastEnemy; i++)
        {
            newEnemyList.Add(fastEnemy);
        }

        waveIndex = waveIndex + 1;

        return newEnemyList;
    }

    private IEnumerator NewWave()
    {
        yield return new WaitForSeconds(nextWaveTime);
        enemyList = NewEnemy();
        waveFinished = false;
    }

    [ContextMenu("Next Wave")]
    private void NextWave()
    {
        enemyList = NewEnemy();
    }
    
}
