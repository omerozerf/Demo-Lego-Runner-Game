using System;
using System.Collections;
using _Scripts.Legos;
using UnityEngine;

namespace _Scripts.Players
{
    public class PlayerLegoBreaker : MonoBehaviour
    {
        public static PlayerLegoBreaker Instance;
        
        [SerializeField] private Player player;
        [SerializeField] private Transform smallBrokenLegoPrefab;
        [SerializeField] private Transform mediumBrokenLegoPrefab;
        [SerializeField] private Transform largeBrokenLegoPrefab;
        [SerializeField] private Transform brokenLegosParent;


        private void Awake()
        {
            Instance = this;
        }


        private void Update()
        {
            TryBreakLego();
        }

        
        private void TryBreakLego()
        {
            if (player.GetPlayerLegoPicker().GetLegoList().Count <= 0 ||
                !player.GetPlayerCollision().IsPlayerTouchObstacle())
                return;

            BreakLego();
        }

        
        public void BreakLego()
        {
            var legoList = player.GetPlayerLegoPicker().GetLegoList();
            var lastLego = legoList[^1];

            lastLego.gameObject.SetActive(false);
            legoList.Remove(lastLego);
            
            
            switch (lastLego.GetLegoType())
            {
                case LegoType.Small:
                {
                    Destroy(
                        Instantiate(smallBrokenLegoPrefab, lastLego.transform.position, Quaternion.identity,
                            brokenLegosParent).gameObject, 5f);
                    break;
                }

                case LegoType.Medium:
                {
                    Destroy(
                        Instantiate(mediumBrokenLegoPrefab, lastLego.transform.position, Quaternion.identity,
                            brokenLegosParent).gameObject, 5f);
                    break;
                }

                case LegoType.Large:
                {
                    Destroy(
                        Instantiate(largeBrokenLegoPrefab, lastLego.transform.position, Quaternion.identity,
                            brokenLegosParent).gameObject, 5f);
                    break;
                }
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private void InstantiateDelay()
        {
            StartCoroutine(InstantiateDelayCoroutine());
        }
        

        private IEnumerator InstantiateDelayCoroutine()
        {
            yield return new WaitForSeconds(10f);
        }
    }
}