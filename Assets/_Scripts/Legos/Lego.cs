using UnityEngine;

namespace _Scripts.Legos
{
    public class Lego : MonoBehaviour
    {
        [SerializeField] private LegoType legoType;
        [SerializeField] private LegoFollower legoFollower;
        [SerializeField] private Transform legoPrefab;

        private bool m_CanPickable = true;
        

        public LegoFollower GetLegoFollower()
        {
            return legoFollower;
        }


        public Transform GetLegoPrefab()
        {
            return legoPrefab;
        }

        public LegoType GetLegoType()
        {
            return legoType;
        }


        public bool CanPickable()
        {
            return m_CanPickable;
        }


        public void SetCanPickable(bool canPickable)
        {
            m_CanPickable = canPickable;
        }
    }
}