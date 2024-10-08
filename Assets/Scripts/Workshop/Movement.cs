using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody2D PlayerRB;
    public float Speed = 2.0f;
    public float JumpStrength = 1000.0f;
    public bool CanJump = true;
    public GameObject RespawnPoint;
    // Freeze Rotation to prevent rotation when sprite falls down

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveSideways(Vector2.right);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveSideways(Vector2.left);
        }
        else
        {
            MoveSideways(Vector2.zero);
        }
        if(Input.GetKey(KeyCode.UpArrow) && CanJump)
        {
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, JumpStrength);
            CanJump = false;
        }
    }

    private void MoveSideways(Vector2 direction)
    {
        PlayerRB.velocity = new Vector2(direction.x * Speed, PlayerRB.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "floor")
        {
            CanJump = true;
        }
        if (collision.collider.gameObject.tag == "danger")
        {
            transform.position = RespawnPoint.transform.position;
            PlayerRB.velocity = Vector2.zero;
        }
    }
}
