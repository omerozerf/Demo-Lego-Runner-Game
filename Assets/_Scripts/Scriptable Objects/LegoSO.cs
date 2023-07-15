using System;
using _Scripts.Legos;
using UnityEngine;

namespace _Scripts.Scriptable_Objects
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