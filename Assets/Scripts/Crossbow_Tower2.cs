using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEngine;

public class Crossbow_Tower2 : Tower
{
    private Tower2AttackVisuals visuals;

    [Header("Crossbow Tower Setup")]
    [SerializeField] private Transform gunBarrel;

    protected override void Awake()
    {
        base.Awake();
        visuals = GetComponent<Tower2AttackVisuals>();
    }

    protected override void Attack()
    {
        Vector3 directionTowardsEnemy = DirectionTowardsEnemy(gunBarrel);
        if(Physics.Raycast(gunBarrel.position, directionTowardsEnemy,out RaycastHit hitInfo, Mathf.Infinity))
        {
            TowerHead.forward = directionTowardsEnemy;

            Debug.Log(hitInfo.collider.gameObject.name + " Attackerd ");
            Debug.DrawLine(gunBarrel.position, hitInfo.point);

            visuals.ShowsAttackVisuals(gunBarrel.position, hitInfo.point);
        }
    }
}
