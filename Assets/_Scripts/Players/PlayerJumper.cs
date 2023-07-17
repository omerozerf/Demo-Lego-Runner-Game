using _Scripts.UIs;
using UnityEngine;

namespace _Scripts.Players
{
    public class PlayerJumper : MonoBehaviour
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
            if (player.GetPlayerCollision().IsPlayerTouchGround())
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
}