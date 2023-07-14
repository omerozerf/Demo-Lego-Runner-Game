using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float verticalSpeed;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveHorizontal = joystick.Horizontal;

        Vector3 movement = new Vector3(moveHorizontal * horizontalSpeed, rigidbody.velocity.y, verticalSpeed);

        rigidbody.velocity = movement;
    }
}