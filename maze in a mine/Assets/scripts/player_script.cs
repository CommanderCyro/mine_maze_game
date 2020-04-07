using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
    //variables

    float moveForward;
    float moveSide;
    float jump;

    public float speed = 5f;
    public float jumpspeed = 10f;

    Rigidbody rig;

   
    bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //input
        moveForward = Input.GetAxis("Vertical") * speed;

        moveSide = Input.GetAxis("Horizontal") * speed;
        jump = Input.GetAxis("Jump") * jumpspeed;
        //player movement
        rig.velocity=(transform.forward * moveForward) + (transform.right * moveSide)+(transform.up*rig.velocity.y);
        //make player jump
        if(isGrounded && jump != 0)
        {
            rig.AddForce(transform.up * jump, ForceMode.VelocityChange);
            isGrounded = false;
        }

    }
    //checking if player is on ground

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;

    }

}

