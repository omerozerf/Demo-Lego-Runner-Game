using System.Collections.Generic;
using _Scripts.Legos;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Players
{
    public class PlayerLegoPicker : MonoBehaviour
    {
        [SerializeField] private Transform legoTransformParent;

        private List<Lego> m_LegoList = new List<Lego>();


        public void Pick(Lego lego, Vector3 targetPos, float time)
        {
            Transform legoTransform;
            (legoTransform = lego.transform).DOMove(targetPos, time);
            
            legoTransform.parent = legoTransformParent;
            m_LegoList.Add(lego);
        }
    }
}
