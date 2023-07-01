using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform following;

    [SerializeField] private float followSpeed = 0.5f;

    private float startZ;

    void Start()
    {
        startZ = transform.position.z;
    }

    void Update()
    {
        float blend = Mathf.Pow(0.5f, Time.deltaTime * followSpeed);
        Vector3 targetPosition = following.position;
        targetPosition.z = startZ;
        Vector3 nextPosition = Vector3.Lerp(targetPosition, transform.position, blend);
        transform.position = nextPosition;
    }
}
