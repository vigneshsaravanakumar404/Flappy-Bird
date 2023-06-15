using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{

    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-5.5f, 0);
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale *= 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -11.59)
        {
            transform.position = new Vector3(transform.position.x + (2 * (12.0f - 0.1f)), transform.position.y, transform.position.z);
        }
    }

}


// To Do

// add poles
// death 
// score
// Better movement
// Tilt down when velocity is something 
