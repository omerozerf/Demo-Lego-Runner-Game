using UnityEngine;

namespace _Scripts.Legos
{
    public class Lego : MonoBehaviour
    {
        [SerializeField] private LegoFollower legoFollower;
        [SerializeField] private Transform legoPrefab;


        public LegoFollower GetLegoFollower()
        {
            return legoFollower;
        }


        public Transform GetLegoPrefab()
        {
            return legoPrefab;
        }
    }
}