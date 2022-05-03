using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField] public Vector3 offsetCamera;
    [SerializeField] public Transform myPlayer;
    [SerializeField] public float translateSpeed;
    [SerializeField] public float rotationSpeed;

    private Vector3 targetPos;

    private Vector3 direction;
    private Quaternion rotation;

    void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    private void HandleRotation()
    {
        targetPos = myPlayer.TransformPoint(offsetCamera);
        transform.position = Vector3.Lerp(transform.position, targetPos, translateSpeed * Time.deltaTime);
    }

    private void HandleTranslation()
    {
        direction = myPlayer.position = transform.position;
        rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

    }

}
