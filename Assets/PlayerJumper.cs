using System;
using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private DoubleClickListener doubleClickListener;
    [SerializeField] private float jumpSpeed;

    private void Start()
    {
        doubleClickListener.OnDoubleClick += OnDoubleClick;
    }


    private void OnDoubleClick()
    {
        Jump();
    }


    private void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
    }


    private void OnDestroy()
    {
        doubleClickListener.OnDoubleClick -= OnDoubleClick;
    }
}