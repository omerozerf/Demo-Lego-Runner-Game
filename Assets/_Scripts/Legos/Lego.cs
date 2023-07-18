using UnityEngine;

namespace _Scripts.Legos
{
    public class Lego : MonoBehaviour
    {
        [SerializeField] private LegoFollower legoFollower;


        public LegoFollower GetLegoFollower()
        {
            return legoFollower;
        }
    }
}