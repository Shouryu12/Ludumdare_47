using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Rino : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    public float speed;
    public Transform rightCol;
    public Transform leftCol;
    public Transform attackRightCol;
    public Transform attackLeftCol;
    public Transform headPoint;

    private bool colliding;
    private bool attackRange;
    private bool isAttack = false;

    public LayerMask layer;
    public LayerMask layer2;

    public BoxCollider2D boxCollider2D;
    //public CircleCollider2D circleCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttack)
        {
            rig.velocity = new Vector2(-speed, rig.velocity.y);
        }
        attackRange = Physics2D.Linecast(attackRightCol.position, attackLeftCol.position, layer2);
        if(attackRange)
        {
            anim.SetBool("attack", true);
            isAttack = true;
        }

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);
    
        if (colliding)
        {
            isAttack = false;
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            anim.SetBool("attack", false);
            speed *= -1;
        }
    }


    bool playerDestroyed = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float height = collision.contacts[0].point.y - headPoint.position.y;
            if (height > 0 && !playerDestroyed)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                speed = 0f;
                anim.SetTrigger("die");
                boxCollider2D.enabled = false;
                //circleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.33f);
            }
            else
            {
                anim.SetBool("attack", false);
                playerDestroyed = true;
                Destroy(collision.gameObject);
            }
        }
    }
}
