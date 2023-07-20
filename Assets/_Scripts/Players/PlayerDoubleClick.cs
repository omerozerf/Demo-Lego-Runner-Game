using System;
using _Scripts.UIs;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Players
{
    public class PlayerDoubleClick : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private DoubleClickListener doubleClickListener;
        [SerializeField] private float jumpSpeed;

        private void Start()
        {
            doubleClickListener.OnDoubleClick += OnDoubleClick;
        }


        private void OnDoubleClick()
        {
            switch (player.GetPlayerMover().GetPlayerMoveType())
            {
                case PlayerMoveType.Run:
                {
                    if (player.GetPlayerCollision().IsPlayerTouchGround())
                        Jump();
                }
                    break;
                case PlayerMoveType.Fly:
                {
                    player.transform.DORotate(new Vector3(0, 0, 179f), 0.5f).OnComplete((() =>
                    {
                        player.transform.DORotate(new Vector3(0, 0, 359f), 0.5f).OnComplete((() =>
                        {
                            player.transform.rotation = Quaternion.Euler(Vector3.zero);
                        }));
                    }));
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
}