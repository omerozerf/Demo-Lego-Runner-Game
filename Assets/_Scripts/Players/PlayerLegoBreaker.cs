using System;
using _Scripts.Legos;
using UnityEngine;

namespace _Scripts.Players
{
    public class PlayerLegoBreaker : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Transform smallBrokenLegoPrefab;
        [SerializeField] private Transform mediumBrokenLegoPrefab;
        [SerializeField] private Transform largeBrokenLegoPrefab;


        private void Update()
        {
            if (player.GetPlayerLegoPicker().GetLegoList().Count > 0 &&
                player.GetPlayerCollision().IsPlayerTouchObstacle())
            {
                var legoList = player.GetPlayerLegoPicker().GetLegoList();
                var lastLego = legoList[^1];
                
                lastLego.gameObject.SetActive(false);
                legoList.Remove(lastLego);

                switch (lastLego.GetLegoType())
                {
                    case LegoType.Small:
                    {
                        Instantiate(smallBrokenLegoPrefab, lastLego.transform.position, Quaternion.identity);
                        break;
                    }
                        
                    case LegoType.Medium:
                    {
                        Instantiate(mediumBrokenLegoPrefab, lastLego.transform.position, Quaternion.identity);
                        break;
                    }
                        
                    case LegoType.Large:
                    {
                        Instantiate(largeBrokenLegoPrefab, lastLego.transform.position, Quaternion.identity);
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}