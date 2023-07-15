using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private global::_Scripts.Player.Player player;
        [SerializeField] private CapsuleCollider capsuleCollider;
        [SerializeField] private LayerMask groundLayerMask;
        [SerializeField] private LayerMask legoLayerMask;
    
        private bool m_IsPlayerTouchGround;
        private bool m_IsPlayerTouchLego;
    

        private void Update()
        {
            var position = transform.position;
            var height = capsuleCollider.height;
            var startPos = new Vector3(position.x, position.y + height * 0.5f, position.z);
            var endPos = new Vector3(position.x, position.y - height * 0.5f, position.z);
        
            CheckGround(startPos, endPos);
            CheckLego(startPos, endPos);
        }

        private void CheckLego(Vector3 startPos, Vector3 endPos)
        {
            bool isTouchLego = Physics.CheckCapsule(startPos, endPos, capsuleCollider.radius, legoLayerMask);

            m_IsPlayerTouchLego = isTouchLego;

            print(m_IsPlayerTouchLego);
        }


        private void CheckGround(Vector3 startPos, Vector3 endPos)
        {
            bool isTouchGround = Physics.CheckCapsule(startPos, endPos, capsuleCollider.radius, groundLayerMask);

            m_IsPlayerTouchGround = isTouchGround;
        }


        public bool IsPlayerTouchGround()
        {
            return m_IsPlayerTouchGround;
        }
    }
}