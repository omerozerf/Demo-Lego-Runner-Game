using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Players
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMover playerMover;
        [SerializeField] private PlayerJumper playerJumper;
        [SerializeField] private PlayerCollision playerCollision;
        [SerializeField] private PlayerLegoPicker playerLegoPicker;
        [SerializeField] private PlayerLegoBreaker playerLegoBreaker;
        [SerializeField] private new Rigidbody rigidbody;


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


        public PlayerLegoBreaker GetPlayerLegoBreaker()
        {
            return playerLegoBreaker;
        }


        public Rigidbody GetPlayerRigidbody()
        {
            return rigidbody;
        }
    }
}