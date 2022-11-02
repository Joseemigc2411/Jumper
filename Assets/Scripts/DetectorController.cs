using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorController : MonoBehaviour
{
    public Player player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "OrientationZone1")
        {
            player.onZone1 = true;
        }
        else
        {
            player.onZone1 = false;
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "OrientationZone1")
        {
            Vector3 newRotation = new Vector3(0, 0, 0);
            player.transform.eulerAngles = newRotation;
        }
        else
        {
            Vector3 newRotation = new Vector3(0, 0, 180);
            player.transform.eulerAngles = newRotation;
        }
    }
}
