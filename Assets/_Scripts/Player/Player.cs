using System;
using UnityEngine;

namespace _Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMover playerMover;
        [SerializeField] private PlayerJumper playerJumper;
        [SerializeField] private PlayerCollision playerCollision;
        [SerializeField] private PlayerLegoPicker playerLegoPicker;


        public PlayerLegoPicker GetPlayerLegoPicker()
        {
            return playerLegoPicker;
        }


        public PlayerMover GetPlayerMover()
        {
            return playerMover;
        }


        public PlayerJumper GetPlayerJumper()
        {
            return playerJumper;
        }


        public PlayerCollision GetPlayerCollision()
        {
            return playerCollision;
        }
    }
}