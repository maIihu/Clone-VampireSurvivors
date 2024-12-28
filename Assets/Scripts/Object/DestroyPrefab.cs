using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{
    public float destroyTime;

    private void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }
}
