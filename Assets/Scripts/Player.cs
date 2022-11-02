using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool onFloor, onZone1;
    public float jumpPressure, minJump, maxJumpPressure, Xmovement;
    private Rigidbody2D rb;
    public GameObject wololo;
    

   
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
        if (rb.velocity.magnitude==0)
        {
            
            if ((Input.GetButton("Player1")&&gameObject.name=="Player1")||(Input.GetButton("Player2")&&gameObject.name=="Player2"))
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
            if ((Input.GetButton("Player1") && gameObject.name == "Player1") || (Input.GetButton("Player2") && gameObject.name == "Player2"))
            {
                wololo.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(rb.velocity.magnitude > 0 && (Input.GetButton("Player1") && gameObject.name == "Player1") || (Input.GetButton("Player2") && gameObject.name == "Player2"))
        {
            wololo.SetActive(true);
        }
    }
    
}
