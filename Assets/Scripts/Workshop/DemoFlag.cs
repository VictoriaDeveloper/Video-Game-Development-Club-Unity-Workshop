using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to the flag prefab
public class DemoFlag : MonoBehaviour
{
    // The Confetti GameObject has a particle system which automatically
    // plays when Confetti is set to active
    public GameObject Confetti;
    public Collider2D FlagCollider;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "player")
        {
            Confetti.SetActive(true);
            Destroy(FlagCollider);
        }
    }
}
