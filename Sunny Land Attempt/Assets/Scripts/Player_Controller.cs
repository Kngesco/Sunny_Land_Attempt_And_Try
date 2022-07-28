using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;

    Rigidbody2D rb;

    [SerializeField]
    float jumpPower;

    bool theGround;
    public Transform groundController;
    public LayerMask groundLayer;

    bool twoJump;

    Animator anim;

    public float reboundTime, recoilStrength;

    float recoilCounter;

    bool right;

    public float jumpFnc;

    public bool moveYesOrNo;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        moveYesOrNo = true;
    }
    private void Update()
    {

        if (moveYesOrNo)
        {
            if (recoilCounter <= 0)
            {
                Move();
                Jump();
                ChangeDirection();
            }
            else
            {
                recoilCounter -= Time.deltaTime;
                if (right)
                {
                    rb.velocity = new Vector2(-recoilStrength, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(recoilStrength, rb.velocity.y);
                }
            }
            anim.SetFloat("MoveSpeed", Mathf.Abs(rb.velocity.x));
            anim.SetBool("TheGround", theGround);
        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetFloat("MoveSpeed", Mathf.Abs(rb.velocity.x));
        }
        
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float speed = h * movementSpeed;

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void Jump ()
    {
        theGround = Physics2D.OverlapCircle(groundController.position, .2f, groundLayer);

        if (theGround)
        {
            twoJump = true;
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            if (theGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                Sound_Controller.instance.SoundEffectUp(3);
            }
            else
            {
                if (twoJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                    twoJump = false;
                    Sound_Controller.instance.SoundEffectUp(3);
                }

                
            }
            
        }
        
    }

    void ChangeDirection()
    {
        Vector2 TemporaryScale = transform.localScale;

        if (rb.velocity.x > 0)
        {
            right = true;
            TemporaryScale.x = 1f;
        }
        else if (rb.velocity.x < 0)
        {
            right = false;
            TemporaryScale.x = -1f;
        }
        transform.localScale = TemporaryScale;
    }
    public void RecoilFunction()
    {
        recoilCounter = reboundTime;
        rb.velocity = new Vector2(0, rb.velocity.y);

        anim.SetTrigger("Damage");
    }
    public void JumpFNC()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpFnc);
        Sound_Controller.instance.SoundEffectUp(3);
    }
}
