using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to each coin
public class DemoCoin : MonoBehaviour
{
    public Collider2D CoinCollider;
    public Rigidbody2D CoinRB;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "player")
        {
            Collect();
        }
    }

    private void Collect()
    {
        // Launch the coin into the air
        CoinRB.velocity = Vector2.up * 8f;
        CoinRB.gravityScale = 2f;

        // Destroy its collider
        // This prevents it from hitting the floor when it lands
        // It also makes it so you can't pick up the same coin twice
        Destroy(CoinCollider);
    }

    void Update()
    {
        // Destroy itself when it falls out of the screen
        if(transform.position.y < -10) Destroy(gameObject);
    }
}
