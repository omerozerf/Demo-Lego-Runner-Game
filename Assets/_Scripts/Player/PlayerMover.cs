using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private FloatingJoystick joystick;
        [SerializeField] private float verticalSpeed;
    

        private void Update()
        {
            Move();
        }

    
        private void Move()
        {
            float moveHorizontal = joystick.Horizontal;

            Vector3 movement = new Vector3(moveHorizontal * horizontalSpeed, rigidbody.velocity.y, verticalSpeed);

            if (player.GetPlayerCollision().IsPlayerTouchGround())
            {
                // TODO -> movement.y = 0;
            }
            
            rigidbody.velocity = movement;
        }
    }
}