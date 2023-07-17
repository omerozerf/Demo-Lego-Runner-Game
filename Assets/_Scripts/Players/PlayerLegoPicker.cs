using System.Collections.Generic;
using _Scripts.Legos;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Players
{
    public class PlayerLegoPicker : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float horizontalGap;
        
        private float m_XMove;
        private float m_ZMove;
        private Vector3 m_FirstLegoPos;
        private Vector3 m_CurrentLegoPos;
        private List<Lego> m_LegoList = new List<Lego>();
        private int m_LegoListIndexCounter = 0;


        public void Pick(Collider other)
        {
            Lego lego = other.GetComponentInParent<Lego>();
            m_LegoList.Add(lego);
            if (m_LegoList.Count == 1)
            {
                m_FirstLegoPos = m_LegoList[0].GetComponentInChildren<MeshRenderer>().bounds.max;

                var legoPosition = lego.transform.position;
                m_CurrentLegoPos = new Vector3(legoPosition.x, m_FirstLegoPos.y, legoPosition.z);
                
                lego.gameObject.transform.position = m_CurrentLegoPos;
                
                m_CurrentLegoPos = new Vector3(legoPosition.x, transform.position.y + horizontalGap,
                    legoPosition.z);
                
                lego.gameObject.GetComponentInParent<Lego>().UpdateLegoPosition(transform, true);
            }
            
            else if (m_LegoList.Count > 1)
            {
                lego.gameObject.transform.position = m_CurrentLegoPos;

                var legoPosition = lego.transform.position;
                m_CurrentLegoPos = new Vector3(legoPosition.x, lego.gameObject.transform.position.y + horizontalGap,
                    legoPosition.z);
                
                lego.gameObject.GetComponentInParent<Lego>()
                    .UpdateLegoPosition(m_LegoList[m_LegoListIndexCounter].transform, true);
                
                m_LegoListIndexCounter++;
            }
        }
    }
}
