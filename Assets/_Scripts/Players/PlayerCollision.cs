using System;
using _Scripts.Legos;
using UnityEngine;

namespace _Scripts.Players
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private CapsuleCollider capsuleCollider;
        [SerializeField] private LayerMask groundLayerMask;
        [SerializeField] private LayerMask legoLayerMask;
        [SerializeField] private LayerMask obstacleLayerMask;
        [SerializeField] private LayerMask airPlaneLayerMask;
        
        private bool m_IsPlayerTouchGround;
        private bool m_IsPlayerTouchObstacle;


        private void Update()
        {
            var position = transform.position;
            var height = capsuleCollider.height;
            var radius = capsuleCollider.radius;
            var startPos = new Vector3(position.x, position.y - radius + height, position.z);
            var endPos = new Vector3(position.x, position.y + radius, position.z);
        
            CheckGround(startPos, endPos);
            CheckObstacle(startPos, endPos);
            
            OverlapLego(startPos, endPos);
            OverlapAirplane(startPos, endPos);
        }

        
        private void OverlapAirplane(Vector3 startPos, Vector3 endPos)
        {
            Collider[] airplaneColliderArray =
                Physics.OverlapCapsule(startPos, endPos, capsuleCollider.radius, airPlaneLayerMask);

            if (!(airplaneColliderArray.Length > 0)) return;

            foreach (var airplaneCollider in airplaneColliderArray)
            {
                player.GetPlayerMover().SetPlayerMoveType(PlayerMoveType.Fly);
                player.GetPlayerMover().GetOnAirPlane(airplaneCollider.transform.position);
            }
        }


        private void CheckObstacle(Vector3 startPos, Vector3 endPos)
        {
            bool isTouchObstacle = Physics.CheckCapsule(startPos, endPos, capsuleCollider.radius, obstacleLayerMask);

            m_IsPlayerTouchObstacle = isTouchObstacle;
        }
        

        private void CheckGround(Vector3 startPos, Vector3 endPos)
        {
            bool isTouchGround = Physics.CheckCapsule(startPos, endPos, capsuleCollider.radius, groundLayerMask);

            m_IsPlayerTouchGround = isTouchGround;
        }

        
        private void OverlapLego(Vector3 startPos, Vector3 endPos)
        {
            Collider[] legoColliderArray =
                Physics.OverlapCapsule(startPos, endPos, capsuleCollider.radius, legoLayerMask);

            if (!(legoColliderArray.Length > 0)) return;
            
            foreach (var legoCollider in legoColliderArray)
            {
                player.GetPlayerLegoPicker().Pick(legoCollider);
            }
        }

        
        public bool IsPlayerTouchGround()
        {
            return m_IsPlayerTouchGround;
        }


        public bool IsPlayerTouchObstacle()
        {
            return m_IsPlayerTouchObstacle;
        }
    }
}