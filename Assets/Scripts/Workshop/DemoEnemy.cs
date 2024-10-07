using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to each enemy
public class DemoEnemy : MonoBehaviour
{
    public SpriteRenderer EnemySprite;
    public float MoveSpeed;
    public float MoveTime; // The amount of time, in seconds, between when the enemy changes direction
    private float timer;
    private bool facingLeft;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        facingLeft = true;
        EnemySprite.flipX = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Enemy movement is on a timer
        timer += Time.deltaTime; // deltaTime keeps track of how much time has passed since the last frame
        if(timer >= MoveTime)
        {
            Flip();
        }
        else
        {
            float movement = MoveSpeed * Time.deltaTime;
            if(facingLeft) movement *= -1; // Multiplying by -1 changes the direction!

            transform.position = new Vector3
            (
                transform.position.x + movement,
                transform.position.y,
                transform.position.z
            );
        }
    }

    private void Flip()
    {
        // Reset the timer
        timer = 0;

        // Set the opposite direction for the facingLeft variable and flip the sprite
        facingLeft = !facingLeft;
        EnemySprite.flipX = !EnemySprite.flipX;
    }
}
