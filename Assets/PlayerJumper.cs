using System;
using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private DoubleClickListener doubleClickListener;


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
        print("Jump!");
    }


    private void OnDestroy()
    {
        doubleClickListener.OnDoubleClick -= OnDoubleClick;
    }
}