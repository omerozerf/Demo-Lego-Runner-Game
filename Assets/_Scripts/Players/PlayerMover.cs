using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Players
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private FloatingJoystick joystick;
        [SerializeField] private float horizontalRunSpeed;
        [SerializeField] private float verticalRunSpeed;
        [SerializeField] private float moveFlySpeed;
        [SerializeField] private float verticalFlySpeed;
        [SerializeField] private float horizontalFlySpeed;

        private PlayerMoveType m_PlayerMoveType;


        private void Start()
        {
            m_PlayerMoveType = PlayerMoveType.Run;
        }


        private void Update()
        {
            switch (GetPlayerMoveType())
            {
                case PlayerMoveType.Run:
                {
                    Run();
                    
                    break;
                }
                case PlayerMoveType.Fly:
                {
                    Fly();
                    
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private void Run()
        {
            float horizontalDirection = joystick.Horizontal;

            Vector3 movement = new Vector3(horizontalDirection * horizontalRunSpeed, rigidbody.velocity.y, verticalRunSpeed);

            if (player.GetPlayerCollision().IsPlayerTouchGround())
            {
                // TODO -> movement.y = 0;
            }
            
            rigidbody.velocity = movement;
        }


        private void Fly()
        {
            float horizontalDirection = joystick.Horizontal;
            float verticalDirection = joystick.Vertical;
            var movement = new Vector3(horizontalDirection * horizontalFlySpeed, verticalDirection * verticalFlySpeed,
                moveFlySpeed);

            rigidbody.velocity = movement;
        }


        public void GetOnAirPlane(Vector3 targetPos)
        {
            // player.transform.DOMove(targetPos, 0.5f);
            player.transform.DOJump(targetPos, 5f, 1, 1f);
            player.GetPlayerRigidbody().useGravity = false;
        }


        public PlayerMoveType GetPlayerMoveType()
        {
            return m_PlayerMoveType;
        }


        public void SetPlayerMoveType(PlayerMoveType playerMoveType)
        {
            m_PlayerMoveType = playerMoveType;
        }
    }
}