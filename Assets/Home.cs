using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }

}
   