using System;
using UnityEngine;

namespace _Scripts
{
    [CreateAssetMenu]
    public class LegoSO : ScriptableObject
    {
        public MyLego legoA;
        
        
        [Serializable]
            public struct MyLego
            {
                public Transform legoPrefab;
                public LegoType type;
            }
    }
}