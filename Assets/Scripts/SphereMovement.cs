using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1

        float Horizontaltranslation = Input.GetAxis("Horizontal") * moveSpeed;
        float Verticaltranslation = Input.GetAxis("Vertical") * jumpSpeed;

        ////Move horizontal
        // Make it move 10 meters per second instead of 10 meters per frame...
        Horizontaltranslation *= Time.deltaTime;
        // Move translation along the object's x-axis
        transform.Translate(Horizontaltranslation, 0, 0);

        ////Move vertical
        // Make it move 5 meters per second instead of 5 meters per frame...
        Verticaltranslation *= Time.deltaTime;
        // Move translation along the object's z-axis
        transform.Translate(0, Verticaltranslation, 0);

    }
}
