using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointManage : MonoBehaviour
{
    [SerializeField] private Transform[] Endpoints;

    public Transform[] GetEndPoints() => Endpoints;

}