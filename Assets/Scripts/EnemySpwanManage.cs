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
    [SerializeField] private WavesDetails currentWave;
    [SerializeField] private Transform respwan;
    [SerializeField] private float spawncooldown;
    private float spawanTime;

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
       List<GameObject> newEnemyList = new List<GameObject>();

       for(int i = 0; i < currentWave.basicEnemy; i++)
       {
            newEnemyList.Add(basicEnemy);
       }

        for(int i = 0; i < currentWave.fastEnemy; i++)
        {
            newEnemyList.Add(fastEnemy);
        }

        return newEnemyList;
    }
}
