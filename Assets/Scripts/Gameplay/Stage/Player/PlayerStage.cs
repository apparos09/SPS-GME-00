using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Sources:
 * - https://docs.unity3d.com/Packages/com.unity.inputsystem@1.3/api/UnityEngine.InputSystem.PlayerInput.html
 * - https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/ActionBindings.html
 */

namespace RM_SPS_GME_00
{
    // The player on the game stage.
    public class PlayerStage : MonoBehaviour
    {
        // The player's rigidbody.
        public new Rigidbody2D rigidbody2D;

        // The player's collider.
        public new Collider2D collider2D;

        // The sprite renderer.
        public SpriteRenderer spriteRenderer;

        // The player input, which contains the input map.
        public PlayerInput playerInput;

        // The player's movement speed.
        public float moveSpeed = 5.0F;

        // The maximum speed of the player.
        public float maxSpeed = 5.0F;

        // If 'true', the player's inputs are enabled.
        public bool inputsEnabled = true;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // If the rigidbody is not set, try to set it.
            if(rigidbody2D == null)
                rigidbody2D = GetComponent<Rigidbody2D>();

            // If the collider is not set, try to set it.
            if(collider2D == null)
                collider2D = GetComponent<Collider2D>();

            // If the playerInput is not set, try to set it.
            if(playerInput == null)
                playerInput = GetComponent<PlayerInput>();
        }

        // Moves in the provided direction multiplied by speed.
        public void Move(Vector2 direc)
        {
            // Uses the normalized vector for direction and calculates with move speed.
            Vector2 force = direc.normalized * moveSpeed;
            rigidbody2D.AddForce(force, ForceMode2D.Impulse);
        }

        // Stops the movement of the player.
        public void StopMovement()
        {
            rigidbody2D.linearVelocity = Vector2.zero;
        }

        // If the move input has been triggered.
        public void MoveInput(InputAction.CallbackContext context)
        {
            // Debug.Log("Move Input!");
            // Debug.Log(playerInput.currentControlScheme);

            // If inputs are enabled.
            if(inputsEnabled)
            {
                // If the context has been performed.
                if (context.performed)
                {
                    // Gets the direction vector and calls the move function.
                    Vector2 direc = context.ReadValue<Vector2>();

                    Move(direc);
                }
                // Context has been cancelled.
                else if(context.canceled)
                {
                    // Debug.Log("Move Stop");
                    StopMovement();
                }
            }
        }

        // Player shoot function.
        public void Shoot()
        {
            // ...
        }

        // If the shoot input has been triggered.
        public void ShootInput(InputAction.CallbackContext context)
        {
            // Debug.Log("Shoot!");

            // If inputs are enabled.
            if (inputsEnabled)
            {
                // If the context has been started (button down)
                if (context.started)
                {
                    Shoot();
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            // If the player is moving, cap the top speed.
            if(rigidbody2D.linearVelocity != Vector2.zero)
            {
                // Clamps the magnitude and sets the linear velocity.
                Vector2 velocity = Vector2.ClampMagnitude(rigidbody2D.linearVelocity, maxSpeed);
                rigidbody2D.linearVelocity = velocity;
            }
        }
    }
}