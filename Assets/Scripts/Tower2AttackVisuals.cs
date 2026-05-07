using System.Collections;
using UnityEngine;

public class Tower2AttackVisuals : MonoBehaviour
{
    private Crossbow_Tower2 tower2;
    
    [SerializeField] private LineRenderer TowerAttackVisuals;
    [SerializeField] private float AttackVisualDuration = 0.1f;

    private void Awake()
    {
        tower2 = GetComponent<Crossbow_Tower2>();
    }
    public void ShowsAttackVisuals(Vector3 startPoint, Vector3 endPoint)
    {
        StartCoroutine(Coroutine(startPoint, endPoint));
    }

    private IEnumerator Coroutine(Vector3 startPoint, Vector3 endPoint)
    {
        tower2.EnableRotation(false);

        TowerAttackVisuals.enabled = true;
        TowerAttackVisuals.SetPosition(0, startPoint);
        TowerAttackVisuals.SetPosition(1, endPoint);    

        yield return new WaitForSeconds(AttackVisualDuration);
        TowerAttackVisuals.enabled = false;

        tower2.EnableRotation(true);
    }
}
