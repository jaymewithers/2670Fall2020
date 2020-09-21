﻿using UnityEngine;

public class InstancerBehaviour : MonoBehaviour
{
    public GameObject prefab;
    public Vector3Data rotationDirection;

    public void Instance()
    {
        var location = transform.position;
        Instantiate(prefab, location, Quaternion.Euler(rotationDirection.value));
    }
}