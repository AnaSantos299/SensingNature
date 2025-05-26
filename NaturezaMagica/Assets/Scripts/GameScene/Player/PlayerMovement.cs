using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;         // Player's movement speed.

    public Transform orientation;   // Transform used for player orientation.

    public TextMeshProUGUI Oxygen;  // Reference to a TextMeshProUGUI component for oxygen display.

    float horizontalInput;          // Horizontal input from the player.
    float verticalInput;            // Vertical input from the player.

    Vector3 moveDirection;          // The direction the player should move towards.

    Rigidbody rb;                   // Reference to the player's Rigidbody component.

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;   // Prevent the Rigidbody from rotating due to physics.
    }

    // Update is called once per frame
    void Update()
    {

        MyInput();                   // Read player input.
        SpeedControl();              // Control player speed based on input and other factors.

    }

    // FixedUpdate is used for physics calculations
    private void FixedUpdate()
    {
        MovePlayer();                // Move the player based on input.
    }

    // Read player input
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); // Read horizontal input (left/right).
        verticalInput = Input.GetAxisRaw("Vertical");     // Read vertical input (forward/backward).
    }

    // Move the player based on input
    private void MovePlayer()
    {
        // Calculate movement direction based on player orientation and input.
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Apply force to move the player.
        rb.AddForce(moveDirection.normalized * moveSpeed * 10);

        // Adjust movement speed based on oxygen level.
        if (Oxygen.color == Color.red)
        {
            moveSpeed = 2;  // Reduced speed when oxygen is low.
        }
        else if (Oxygen.color == Color.black)
        {
            moveSpeed = 0;  // Player can't move when oxygen is depleted.
        }
    }

    // Control player speed and prevent it from exceeding the maximum speed.
   private void SpeedControl()
    {
        
       Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // Limit velocity if needed.
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }
}
