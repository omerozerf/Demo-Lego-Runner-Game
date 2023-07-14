using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover playerMover;
    [SerializeField] private PlayerJumper playerJumper;


    public PlayerMover GetPlayerMover()
    {
        return playerMover;
    }


    public PlayerJumper GetPlayerJumper()
    {
        return playerJumper;
    }
}