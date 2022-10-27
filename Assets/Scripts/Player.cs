using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool onFloor, onZone1;
    public float jumpPressure, minJump, maxJumpPressure, Xmovement;
    private Rigidbody2D rb;
    

   
    void Start()
    {
        onFloor = true;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPressure = 10f;
        Xmovement = 3f;
        rb = GetComponent<Rigidbody2D>();
       
    }

    
    void Update()
    { 
        if (onFloor)
        {
            
            if (Input.GetButton("Jump"))
            {
                if (jumpPressure < maxJumpPressure)
                {
                    jumpPressure += Time.deltaTime * 10f;
                }
                else
                {
                    jumpPressure = maxJumpPressure;
                }

            }
            else
            {
                if (jumpPressure > 0)
                {
                    jumpPressure = jumpPressure + minJump;
                    if (onZone1 == true)
                    {
                        rb.velocity = new Vector3(jumpPressure / Xmovement, jumpPressure, 0f);
                    }
                    else
                    {
                        rb.velocity = new Vector3(-1 * jumpPressure / Xmovement, jumpPressure, 0f);
                    }
                    jumpPressure = 0f;
                    onFloor = false;
                }
            }
        }
        else
        {

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onFloor = true;
        }
    }
}
