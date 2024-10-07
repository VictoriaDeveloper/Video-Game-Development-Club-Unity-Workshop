using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPlayerMovement : MonoBehaviour
{
    public Rigidbody2D PlayerRB;
    public SpriteRenderer PlayerSR;
    public float Speed;
    public float JumpStrength;
    public GameObject RespawnPoint;
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            MoveSideways(Vector2.right);
            PlayerSR.flipX = true;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            MoveSideways(Vector2.left);
            PlayerSR.flipX = false;
        }
        else 
        {
            MoveSideways(Vector2.zero);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, JumpStrength);
            canJump = false;
        }
    }

    // Sets the player's veolicty only in the sideways direction
    private void MoveSideways(Vector2 direction)
    {
        PlayerRB.velocity = new Vector2(direction.x * Speed, PlayerRB.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "floor")
        {
            // Allow the player to jump again once they reach the ground
            canJump = true;
        }
        else if(collision.collider.gameObject.tag == "danger")
        {
            Respawn();
        }
    }

    // Move the player back to the respawn point and reset their velocity
    private void Respawn()
    {
        transform.position = RespawnPoint.transform.position;
        PlayerRB.velocity = Vector2.zero;
    }
}
