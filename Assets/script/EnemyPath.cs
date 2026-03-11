using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    public Transform[] nodes;
    public float speed = 3f;

    private int currentNode = 0;

    void Update()
    {
        if (currentNode >= nodes.Length) return;

        Transform target = nodes[currentNode];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        transform.LookAt(target);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentNode++;
        }
    }
}