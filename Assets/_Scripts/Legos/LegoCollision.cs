using System;
using UnityEngine;

namespace _Scripts.Legos
{
    public class LegoCollision : MonoBehaviour
    {
        [SerializeField] private LayerMask obstacleLayerMask;
        [SerializeField] private BoxCollider boxCollider;

        private bool m_IsLegoTouchObstacle;


        private void Update()
        {
            var center = transform.position;
            var halfSize = boxCollider.size * 0.5f;

            CheckObstacle(center, halfSize);
        }

        private void CheckObstacle(Vector3 center, Vector3 halfSize)
        {
            bool isTouchObstacle =
                Physics.CheckBox(center, halfSize, boxCollider.transform.rotation, obstacleLayerMask);

            m_IsLegoTouchObstacle = isTouchObstacle;
        }


        public bool IsLegoTouchObstacle()
        {
            return m_IsLegoTouchObstacle;
        }
    }
}