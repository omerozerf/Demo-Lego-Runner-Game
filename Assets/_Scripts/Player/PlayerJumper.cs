using _Scripts.UI;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerJumper : MonoBehaviour
    {
        [SerializeField] private new Rigidbody rigidbody;
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
}