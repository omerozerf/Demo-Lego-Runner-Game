using System.Collections.Generic;
using _Scripts.Legos;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Players
{
    public class PlayerLegoPicker : MonoBehaviour
    {
        private List<Lego> m_LegoList = new List<Lego>();


        public void Pick(Lego lego, Vector3 targetPos, float time)
        {
            Transform legoTransform;
            (legoTransform = lego.transform).DOMove(targetPos, time);
            
            legoTransform.parent = transform.parent;
            m_LegoList.Add(lego);
        }


        public List<Lego> GetLegoList()
        {
            return m_LegoList;
        }
    }
}
