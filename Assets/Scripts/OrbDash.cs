using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AGDDPlatformer;

public class OrbDash : MonoBehaviour
{

    PlayerController player;
    public float dashSpeed = 2;
    bool isDashing = false;

    public void Start()
    {
        player = GameManager.instance.players[0];
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject && player.canDash && !isDashing)
        {
            player.inOrbRange = true;
            player.dashDirection = (transform.position - player.transform.position).normalized;
            player.dashSpeed = dashSpeed * player.dashSpeedOriginal;
        }
        if (player.isDashing)
            isDashing = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        isDashing = false;
        player.inOrbRange = false;
    }

}
