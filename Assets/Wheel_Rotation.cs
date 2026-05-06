using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel_Rotation : MonoBehaviour
{
   [SerializeField] private Vector3 rotationVector;
   [SerializeField] private float rotationSpeed;

   private void Update()
   {   
      float newRotationSpeed = rotationSpeed * 100;
      transform.Rotate(rotationVector * newRotationSpeed * Time.deltaTime);
   }
}
 