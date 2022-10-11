using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundPoint;
    public LayerMask whatisGround;
    private float radius = .2f;

    private bool canDoubleJump;

    private Animator anim;
    private SpriteRenderer theSR;

    public float knockbackLength, knockbackForce;
    private float knockbackCounter;

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(knockbackCounter <= 0)
        {
            // Movement
            theRB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), theRB.velocity.y);

            // Landing 
            if(isGrounded)
            {
                canDoubleJump = true;
            }

            /* Jump Action */
            isGrounded = Physics2D.OverlapCircle(groundPoint.position, radius, whatisGround);

            if(Input.GetButtonDown("Jump"))
            {
                if(isGrounded)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                }
                else if(canDoubleJump)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }

            // Animator Controller
            anim.SetBool("isGrounded", isGrounded);
            anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));

            // Sprite Renderer Controller
            if(theRB.velocity.x < 0)
            {
                theSR.flipX = true;
            }
            else if (theRB.velocity.x > 0)
            {
                theSR.flipX = false;
            }
        }
        else
        {
            knockbackCounter -= Time.deltaTime;
            theRB.velocity = new Vector2(theSR.flipX ? knockbackForce : -knockbackForce, theRB.velocity.y);
        }
    }

    public void Knockback()
    {
        knockbackCounter = knockbackLength;
        theRB.velocity = new Vector2(0f, knockbackForce);
        anim.SetTrigger("hit");
    }
}
