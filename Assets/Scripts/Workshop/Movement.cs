using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // Hold a reference to the player's Rigibody2D
    public Rigidbody2D PlayerRB;

    // Hold a reference to the speed 
    public float Speed = 2.0f;

    // Hold a reference to the jump strength
    public float JumpStrength = 10.0f;

    // Hold a boolean that determines if the player can jump
    public bool CanJump = true;

    // Hold the respawn point GameObject
    public GameObject RespawnPoint;

    void Start()
    { }

    /*
     * @brief Every frame listen for key codes to apply the correct movement
     * @param none
     * @return void
     */
    void Update()
    {

        // Check if the user is pressing the right arrow
        if (Input.GetKey(KeyCode.RightArrow))
        {

            // Move the sprite to the right
            MoveSideways(Vector2.right);
        }

        // Else check if the user is pressing the left arrow
        else if (Input.GetKey(KeyCode.LeftArrow))
        {

            // Move the sprite to the left
            MoveSideways(Vector2.left);
        }

        // Else the sprite is not moving & will stand still
        else
        {

            // Move the sprite nowhere
            MoveSideways(Vector2.zero);
        }

        // Check if the user pressing the up arrow
        if(Input.GetKey(KeyCode.UpArrow) && CanJump)
        {

            // Set the velocity of the player's Rigidbody2D to jump
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, JumpStrength);

            // Set the jump boolean flag to false
            CanJump = false;
        }
    }

    /*
     * @brief Apply the direction vector to the player's Rigidbody2D velocity
     * @param Vector2 direction
     * @return void
     */
    private void MoveSideways(Vector2 direction)
    {

        // Set the velocity of the player's Rigidbody2D to move
        PlayerRB.velocity = new Vector2(direction.x * Speed, PlayerRB.velocity.y);
    }

    /*
     * @brief Handle collision cases by checking the collision GameObject's tag 
     * Case "floor" Allow the user to jump
     * Case "danger" Respawn the user
     * @param Collision2D collision the collision event 
     * @return void
     */
    void OnCollisionEnter2D(Collision2D collision)
    {

        // Check if the collider GameObject has the "floor" tag
        if(collision.collider.gameObject.tag == "floor")
        {

            // Set the jump boolean flag to true
            CanJump = true;
        }

        // Check if the collider GameObject has the "danger" tag
        if (collision.collider.gameObject.tag == "danger")
        {

            // Set the position of the game object to the respawn point
            transform.position = RespawnPoint.transform.position;

            // Set the playerRB velocity to zero
            PlayerRB.velocity = Vector2.zero;
        }
    }
}
