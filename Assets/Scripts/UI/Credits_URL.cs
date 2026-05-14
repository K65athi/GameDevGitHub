using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits_Link : MonoBehaviour
{
    [SerializeField] private string url;

    public void OpenURL() => Application.OpenURL(url);
}
