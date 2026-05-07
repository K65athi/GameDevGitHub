using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform Current_Enemy;

    [SerializeField] protected float AttackCooldown = 1;
    protected float AttackCooldownTimer;

    [Header("Tower Setup")]
    [SerializeField] protected Transform TowerHead;
    [SerializeField] protected float rotationspeed = 10;
    private bool CanRotate;
    [SerializeField] protected float AttackRange = 2.5f;
    [SerializeField] protected LayerMask EnemyLayer;

    protected virtual void Awake()
    {
        
    }

    protected virtual void Update()
    {
        if(Current_Enemy == null)
        {
            Current_Enemy = FindRandomEnemyInRange();
            return;
        }

        if(CanAttack())
            Attack();

        if(Vector3.Distance(Current_Enemy.position, transform.position) > AttackRange)
            Current_Enemy = null;
        

        RotateTowerTowardsEnemy();
    }

    protected virtual void Attack()
    {
        //Debug.Log("Attacking Enemy at " + Time.time);
    }

    protected bool CanAttack()
    {
        if(Time.time > AttackCooldownTimer + AttackCooldown)
        {
            AttackCooldownTimer = Time.time;
            return true;
        }
        
        return false;
    }

    protected virtual Transform FindRandomEnemyInRange()
    {
        List<Transform> possibleTargets = new List<Transform>();
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, AttackRange,EnemyLayer);
        
        foreach (Collider enemy in enemiesInRange)
        {
            possibleTargets.Add(enemy.transform);
        }

        int randomIndex = Random.Range(0,possibleTargets.Count);

        if(possibleTargets.Count <= 0)
            return null;

        return possibleTargets[randomIndex];
    }

    public void EnableRotation(bool enable)
    {
        CanRotate = enable;
    }
    

    protected virtual void RotateTowerTowardsEnemy()
    {
       if(CanRotate == false)
           return;
       if (Current_Enemy == null)
           return;
       // Calculate the direction from the tower head to the current enemy 
       Vector3 directionTowardsEnemy = Current_Enemy.position - TowerHead.position; 
       // Creates a rotation that looks in the direction of the enemy
       Quaternion lookRotation = Quaternion.LookRotation(directionTowardsEnemy);
       // Smoothly rotate the tower head towards the enemy using Lerp
       Vector3 rotation = Quaternion.Lerp(TowerHead.rotation, lookRotation, rotationspeed * Time.deltaTime).eulerAngles;
       TowerHead.rotation = Quaternion.Euler(rotation);
    }

    protected Vector3 DirectionTowardsEnemy(Transform StartPoint)
    {
        return (Current_Enemy.position - StartPoint.position).normalized;
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}

