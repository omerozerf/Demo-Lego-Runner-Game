using System.Collections.Generic;
using _Scripts.Legos;
using UnityEngine;

namespace _Scripts.Players
{
    public class PlayerLegoPicker : MonoBehaviour
    {
        private float m_XMove;
        private float m_ZMove;
        private Vector3 m_FirstLegoPos;
        private Vector3 m_CurrentLegoPos;
        private List<Lego> m_LegoList = new List<Lego>();
        private int m_LegoListIndexCounter = 0;


        // ReSharper disable Unity.PerformanceAnalysis
        public void Pick(Collider legoCollider)
        {
            Lego legoFollower = legoCollider.GetComponentInParent<Lego>();
            
            m_LegoList.Add(legoFollower);
            switch (m_LegoList.Count)
            {
                case 1:
                {
                    m_FirstLegoPos = m_LegoList[0].GetComponentInChildren<MeshRenderer>().bounds.max;

                    var legoPosition = legoFollower.transform.position;
                    m_CurrentLegoPos = new Vector3(legoPosition.x, transform.position.y, legoPosition.z);
                
                    legoFollower.gameObject.transform.position = m_CurrentLegoPos;
                
                    m_CurrentLegoPos = new Vector3(legoPosition.x, transform.position.y,
                        legoPosition.z);
                
                    legoFollower.gameObject.GetComponentInParent<Lego>().GetLegoFollower()
                        .UpdateLegoPosition(transform, true);
                    break;
                }
                
                case > 1:
                {
                    legoFollower.gameObject.transform.position = m_CurrentLegoPos;

                    var legoPosition = legoFollower.transform.position;
                    m_CurrentLegoPos = new Vector3(legoPosition.x, legoFollower.gameObject.transform.position.y,
                        legoPosition.z);
                
                    legoFollower.gameObject.GetComponentInParent<Lego>().GetLegoFollower()
                        .UpdateLegoPosition(m_LegoList[m_LegoListIndexCounter].transform, true);
                
                    m_LegoListIndexCounter++;
                    break;
                }
            }
        }


        public List<Lego> GetLegoList()
        {
            return m_LegoList;
        }
    }
}
