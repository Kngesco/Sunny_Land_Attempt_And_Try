using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enenmy_Frog_Controller : MonoBehaviour
{
    public float moveSpeed;

    public Transform leftTarget, rightTarget;

    bool rightSide;

    Rigidbody2D rb;

    public SpriteRenderer sr;

    public float moveTime, waitTime;

    float moveCounter, waitCounter;

    Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        leftTarget.parent = null;
        rightTarget.parent = null;

        rightSide = true;

        moveCounter = moveTime;
    }

    private void Update()
    {
        if (moveCounter > 0)

            
        {
            moveCounter -= Time.deltaTime;
            if (rightSide)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

                sr.flipX = true;

                if (transform.position.x > rightTarget.position.x)
                {
                    rightSide = false;
                }

            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                sr.flipX = false;

                if (transform.position.x < leftTarget.position.x)
                {
                    rightSide = true;
                }
            }
            if (moveCounter <= 0)
            {
                waitCounter = Random.Range(waitTime * 0.7f, waitTime * 1.2f);
            }
            anim.SetBool("mover", true);
        } else if(waitCounter > 0)
        {
            waitCounter -= Time.deltaTime;
            rb.velocity = new Vector2(0, rb.velocity.y);

            if (waitCounter <= 0)
            {
                moveCounter = Random.Range(moveTime * 0.7f, moveTime * 1.2f);
            }
            anim.SetBool("mover", false);
        }
    }
}
