using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private CapsuleCollider capsuleCollider;


    private bool m_IsPlayerTouchGround;
    

    private void Update()
    {
        var position = transform.position;
        var localScale = capsuleCollider.transform.localScale;
        var startPos = new Vector3(position.x, position.y + (localScale.y * 0.5f) + 0.01f, position.z);
        var endPos = new Vector3(position.x, (position.y - localScale.y * 0.5f) - 0.5f, position.z);
        
        bool isTouchGround = Physics.CheckCapsule(startPos, endPos, capsuleCollider.radius, groundLayerMask);

        m_IsPlayerTouchGround = isTouchGround;
    }


    public bool IsPlayerTouchGround()
    {
        return m_IsPlayerTouchGround;
    }
}