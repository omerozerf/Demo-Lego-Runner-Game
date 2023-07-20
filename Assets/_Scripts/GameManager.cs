using System;
using _Scripts.Legos;
using _Scripts.Players;
using General;
using TMPro;
using UnityEngine;

namespace _Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private LevelDataSO[] levelDataSOArray;
        [SerializeField] private TextMeshProUGUI[] textArray;

        private int m_TotalSmallLego;
        private int m_TotalMediumLego;
        private int m_TotalLargeLego;


        private void Start()
        {
            PlayerLegoPicker.OnLegoPicked += OnLegoPicked;
            PlayerLegoBreaker.OnLegoBroken += OnLegoBroken;
            
            var levelData = levelDataSOArray[0];

            m_TotalSmallLego = levelData.totalSmallLego;
            m_TotalMediumLego = levelData.totalMediumLego;
            m_TotalLargeLego = levelData.totalLargeLego;


            LegoCount();
        }

        
        // ReSharper disable Unity.PerformanceAnalysis
        private void OnLegoBroken(object sender, EventArgs e)
        {
            LazyCoroutines.WaitForFrame(LegoCount);
        }

        
        private void OnLegoPicked(object sender, EventArgs e)
        {
            LazyCoroutines.WaitForFrame(LegoCount);
        }


        private void LegoCount()
        {
            var legoList = PlayerLegoPicker.Instance.GetLegoList();

            var currentSmall = 0;
            var currentMedium = 0;
            var currentLarge = 0;

            
            textArray[0].text = $"S: {currentSmall}/{m_TotalSmallLego}";
            textArray[1].text = $"M: {currentMedium}/{m_TotalMediumLego}";
            textArray[2].text = $"L: {currentLarge}/{m_TotalLargeLego}";

            foreach (var lego in legoList)
            {
                switch (lego.GetLegoType())
                {
                    case LegoType.Small:
                        currentSmall++;
                        textArray[0].text = $"S: {currentSmall}/{m_TotalSmallLego}";

                        break;
                    case LegoType.Medium:
                        currentMedium++;
                        textArray[1].text = $"M: {currentMedium}/{m_TotalMediumLego}";

                        break;
                    case LegoType.Large:
                        currentLarge++;
                        textArray[2].text = $"L: {currentLarge}/{m_TotalLargeLego}";

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        

        private void OnDestroy()
        {
            PlayerLegoPicker.OnLegoPicked -= OnLegoPicked;
        }
    }
}
