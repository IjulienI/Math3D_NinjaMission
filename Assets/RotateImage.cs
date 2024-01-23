using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagesRotation : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    private void Update()
    {
        transform.LookAt(mainCam.transform.position);
    }
}