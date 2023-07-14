using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private LayerMask groundLayerMask;


    private void Update()
    {
        // Collider[] colliderArray = Physics.OverlapCapsule();
    }
}