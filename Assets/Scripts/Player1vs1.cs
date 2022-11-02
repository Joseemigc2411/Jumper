using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1vs1 : MonoBehaviour
{
    public bool onFloor;
    public float jumpPressure, minJump, maxJumpPressure, Xmovement;
    private Rigidbody2D rb;
    
  [SerializeField]  Vector2 spawnPoint1 = new Vector2() , spawnPoint2 = new Vector2();
  [SerializeField] int score = 0;
  [SerializeField] bool IsPlayer1 = true;

    void Start()
    {
        onFloor = true;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPressure = 10f;
        Xmovement = 3f;
        rb = GetComponent<Rigidbody2D>();
        if (IsPlayer1)
            spawnPoint1 = gameObject.transform.position;
        else
            spawnPoint2 = gameObject.transform.position;
    }

    
    void Update()
    { 
        if (onFloor)
        {
            
            if (Input.GetButton("Jump") && IsPlayer1 || Input.GetKey(KeyCode.UpArrow) && !IsPlayer1 )
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
           
            if (Input.GetButtonUp("Jump") || Input.GetKeyUp(KeyCode.UpArrow))
            {
                if (jumpPressure > 0)
                {
                    jumpPressure = jumpPressure + minJump;
                    if (IsPlayer1)
                        rb.velocity = new Vector3(jumpPressure / Xmovement, jumpPressure, 0);
                    else
                        rb.velocity = new Vector3(-jumpPressure / Xmovement, jumpPressure, 0);

                    onFloor = false;
                    jumpPressure = 0;
                }
            }
        }        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onFloor = true;
        }
        if (collision.gameObject.tag == "abyss")
        {
            Respawn();
        }
        if (collision.gameObject.tag == "wall")
        {
            Respawn();
            score++;
        }
    }

    public void Respawn()
    {
        if(IsPlayer1)
        {
            gameObject.transform.position = spawnPoint1;
            onFloor = true;
        }
        else
        {
            gameObject.transform.position = spawnPoint2;
            onFloor = true;
        }
        
    }

}
