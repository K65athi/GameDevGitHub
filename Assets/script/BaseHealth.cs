using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public int health = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            health -= 1;
            Debug.Log("Base Health: " + health);

            Destroy(other.gameObject);
        }
    }
}
