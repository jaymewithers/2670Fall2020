﻿using System.Collections;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}