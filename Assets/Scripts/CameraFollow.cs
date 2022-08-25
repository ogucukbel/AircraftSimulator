using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform aircraft;
    private Vector3 offset;

    private void Start() 
    {
        offset = transform.position - aircraft.position;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = aircraft.position + offset;
        transform.position = targetPosition;
    }
}
