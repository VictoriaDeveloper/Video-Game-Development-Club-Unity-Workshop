using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to the camera GameObject in the demo scene
public class DemoCameraFollow : MonoBehaviour
{
    // Reference to the player GameObject
    // Remember to set this in the inspector!
    public GameObject Player;
    
    // Shifts the camera slightly to the left and right
    // Try changing the value in the inspector to see what happens
    public float Offset;

    void Update()
    {
        // Follow the player's x position
        // Keep the current y and z position the same (don't follow the player)
        transform.position = new Vector3
        (
            Player.transform.position.x + Offset,
            transform.position.y, 
            transform.position.z
        );
    }
}
