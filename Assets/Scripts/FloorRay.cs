using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRay : MonoBehaviour
{

    SpriteRenderer sr;
   [SerializeField] bool IsRay;

    public Player1vs1 player;
    [SerializeField] Color color1, color2; //1 = blanco | 2 = amarillo

    [SerializeField] float timer = 4 , probability = 3; //probabilidad no puede ser mayor de 9

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ColorControl();
        RestarTimer();
        if (timer <= 0)
        {
            RayOrFloor();
            timer = 4;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && IsRay)
        {    
            player.Respawn();
            Debug.Log("Zap!");        //choca con player && estado Ray = player "muere"
        }
    }

    void RestarTimer()      //resta tiempo al timer de la plataforma
    {
        timer -= Time.deltaTime;
    }

    void SwitchRay()     //cambia el estado de la plataforma
    {
        IsRay = !IsRay;
    }
    void ColorControl()      //cambia el color de la plataforma según su estado
    {
        if (IsRay)
        {
            sr.color = color2;
        }
        else
        {
            sr.color = color1;
        }
    }
    void RayOrFloor()
    {
       int dado = Random.Range(0, 10);
        
        Debug.Log(dado);                  //tiro un dado, si el resultado es menor que probability cambia estado del suelo
        if (dado <= probability)
        {           
            SwitchRay();
            Debug.Log("CAMBIANDO");
        }
    }
}
