using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyPy : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 12f;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private LayerMask groundLayer;
    private bool isMoveSlowly;
    private bool isStuned;
    private CapsuleCollider2D capCol;
    private Rigidbody2D myBody;
    private Animator anim;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        capCol = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        
    }
    // Update is called once per frame
    void Update()
    {
        Jumping(14f);
        AnimatePlayer();
    }
    private void FixedUpdate()
    {
        Moving();

    }

    void Moving()
    {
        if (isStuned)
        {
            moveSpeed = 0;
        }
        else if(isMoveSlowly)
        {
            moveSpeed = maxSpeed * 2f / 3f;
        }
        else
        {
            moveSpeed = maxSpeed;
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            myBody.velocity = new Vector2( moveSpeed, myBody.velocity.y);
        }
        else
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
        }
     
    }
    bool IsGrounded()
    {
        return Physics2D.CapsuleCast(capCol.bounds.center, capCol.bounds.size,CapsuleDirection2D.Vertical, 0f, Vector2.down,0.1f,groundLayer);
    }
    void Jumping(float force)
    {
        force = jumpForce;
        if(isStuned)
        {
            force = 0;
        }
        IsGrounded();
        if(Input.GetButton("Jump"))
        {
            if (IsGrounded())
            {
                SoundController.instance.P_pJump();
                myBody.velocity = new Vector2(myBody.velocity.x, force);
            }
        }
    }

    public void setStunned(bool i_isStuned)
    {
        isStuned = i_isStuned;
    }

    public void setMoveSlowly(bool i_isMoveSlowly)
    {
        isMoveSlowly = i_isMoveSlowly;
    }

    private void AnimatePlayer()
    {
        if (isStuned)
        {
            anim.SetBool("stun", true);
        }
        else if (isMoveSlowly)
        {
            anim.SetBool("sleepy", true);
        }
        else
        {
            anim.SetBool("stun", false);
            anim.SetBool("sleepy", false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            GameplayController.instance.GameOver(false);

        if (collision.CompareTag("Goal"))
            GameplayController.instance.GameOver(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            GameplayController.instance.GameOver(false);
    }
}

