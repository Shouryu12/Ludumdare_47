using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x,player.position.y, -10);
        if(player.position.x >= -7.5 && player.position.x <= -1.5)
        {
            transform.position = new Vector3(0,0.32f,-10);
        }
        if(player.position.x <= -30)
        {
            transform.position = new Vector3(-30.85f,0.32f,-10);
        }
        if(player.position.x >= 63.27)
        {
            transform.position = new Vector3(63.27f, 1.32f, -10);
        }
    }
}
