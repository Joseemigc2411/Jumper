using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorController : MonoBehaviour
{
    public Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "OrientationZone1")
            player.onZone1 = true;
        else
            player.onZone1 = false;
    }
}
