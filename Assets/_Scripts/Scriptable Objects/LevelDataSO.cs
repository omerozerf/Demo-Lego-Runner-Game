using _Scripts.Legos;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    [CreateAssetMenu]
    public class LevelDataSO : ScriptableObject
    {
        public LegoType smallLego;
        public int totalSmallLego;

        public LegoType mediumLego;
        public int totalMediumLego;

        
        public LegoType largeLego;
        public int totalLargeLego;

    }
}
