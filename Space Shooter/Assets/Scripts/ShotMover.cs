﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMover : MonoBehaviour
{
    public float speed;
    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.velocity = transform.up * speed;
    }
}
