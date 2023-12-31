using System;
using System.Collections.Generic;
using _Scripts.Legos;
using UnityEngine;

namespace _Scripts.Players
{
    public class PlayerLegoPicker : MonoBehaviour
    {
        public static PlayerLegoPicker Instance { get; private set; }
        
        public static event EventHandler OnLegoPicked;

        private float m_XMove;
        private float m_ZMove;
        private Vector3 m_FirstLegoPos;
        private Vector3 m_CurrentLegoPos;
        private List<Lego> m_LegoList = new List<Lego>();
        private int m_LegoListIndexCounter = 0;


        private void Awake()
        {
            Instance = this;
        }


        private void Update()
        {
            if (m_LegoList.Count > 0)
            {
                m_LegoListIndexCounter = GetLegoList().Count - 1;
            }
        }


        // ReSharper disable Unity.PerformanceAnalysis
        public void Pick(Collider legoCollider)
        {
            Lego lego = legoCollider.GetComponentInParent<Lego>();

            if (!lego.CanPickable()) return;
            
            m_LegoList.Add(lego);
            lego.SetCanPickable(false);
            
            switch (m_LegoList.Count)
            {
                case 1:
                {
                    m_FirstLegoPos = m_LegoList[0].GetComponentInChildren<MeshRenderer>().bounds.max;

                    var legoPosition = lego.transform.position;
                    m_CurrentLegoPos = new Vector3(legoPosition.x, transform.position.y, legoPosition.z);
                    
                    m_CurrentLegoPos = new Vector3(legoPosition.x, transform.position.y,
                        legoPosition.z);

                    lego.gameObject.GetComponentInParent<Lego>().GetLegoFollower()
                        .UpdateLegoPosition(transform, true);

                    OnLegoPicked?.Invoke(this, EventArgs.Empty);
                    break;
                }

                case > 1:
                {
                    var legoPosition = lego.transform.position;
                    m_CurrentLegoPos = new Vector3(legoPosition.x, lego.gameObject.transform.position.y,
                        legoPosition.z);

                    lego.gameObject.GetComponentInParent<Lego>().GetLegoFollower()
                        .UpdateLegoPosition(m_LegoList[m_LegoListIndexCounter].transform, true);

                    OnLegoPicked?.Invoke(this, EventArgs.Empty);
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
