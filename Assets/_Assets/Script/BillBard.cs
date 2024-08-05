using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBard : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        LookTowardCamera();
    }

    private void Update()
    {
        LookTowardCamera();
    }

    private void LookTowardCamera()
    {
        transform.forward = -mainCamera.transform.forward;
    }
}
