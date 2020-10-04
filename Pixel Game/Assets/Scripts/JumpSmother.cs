using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSmother : MonoBehaviour
{
    private Rigidbody2D playerRig;
    private Player playerVar;

    private void Start() 
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerRig = player.GetComponent<Rigidbody2D>();
        playerVar = player.GetComponent<Player>();    
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 10 && playerVar.isJumping)
        {
            float newVel = ((playerRig.velocity.y*99.9f)/100);
            playerRig.velocity = new Vector2(playerRig.velocity.x, 0.8f);
        }
    }
}
