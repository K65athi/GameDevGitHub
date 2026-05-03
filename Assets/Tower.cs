using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Transform towerHead;
    public Transform enemy;

    public float attackRange = 3;
    public GameObject bulletPrefab;
    public float bulletSpeed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = Instantiate(bulletPrefab, towerHead.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().linearVelocity = (enemy.position - towerHead.position).normalized * bulletSpeed;
        }

        
        if (Vector3.Distance(enemy.position, towerHead.position) < attackRange)
        {
            towerHead.LookAt(enemy);
        }
    }

    private void OnDrawGizmos()
    { 
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
