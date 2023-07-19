using System;
using UnityEngine;

namespace _Scripts.Players
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private FloatingJoystick joystick;
        [SerializeField] private float verticalSpeed;


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
            float moveHorizontal = joystick.Horizontal;

            Vector3 movement = new Vector3(moveHorizontal * horizontalSpeed, rigidbody.velocity.y, verticalSpeed);

            if (player.GetPlayerCollision().IsPlayerTouchGround())
            {
                // TODO -> movement.y = 0;
            }
            
            rigidbody.velocity = movement;
        }


        private void Fly()
        {
            print("Fly!");
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