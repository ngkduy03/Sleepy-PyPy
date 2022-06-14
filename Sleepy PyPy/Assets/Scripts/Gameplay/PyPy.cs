using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyPy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private LayerMask groundLayer;

    bool isJump, isMove;
    float x;
    private CapsuleCollider2D capCol;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Vector3 tempos;

    private void Awake()
    {
        // Get the Component of Player GameObject
        myBody = GetComponent<Rigidbody2D>();
        capCol = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        // SimpleInput.GetAxisRaw("Horizontal") return 1 when arrow right is press
        // SimpleInput.GetAxisRaw("Horizontal") return -1 when arrow left is pressed
        x = SimpleInput.GetAxisRaw("Horizontal");
        if ( x != 0)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }

        // SimpleInput.GetAxisRaw("Vertical") return 1 when arrow up is pressed
        // When button jump is pressed and player is on ground, allow player to jump
        if (SimpleInput.GetAxisRaw("Vertical") == 1 && IsGrounded())
        {
            isJump = true;
        }
    }
    // Fixed Update is call after 0.02s
    private void FixedUpdate()
    {
        Moving(10f);
        Jumping(14f);

    }

    void Moving(float Speed)
    {
        Speed = moveSpeed;
        if (isMove)
        {
            if(myBody.velocity.x < maxSpeed && myBody.velocity.x > -maxSpeed)
            {
                //Add force when the speed is less than max speed
                myBody.AddForce(new Vector2(x * Speed, 0f), ForceMode2D.Impulse);
            }
        }
        else
        {
            if(x == 1)
            {
                //Add left force
                myBody.AddForce(new Vector2(-Speed / 2, 0), ForceMode2D.Impulse);
            }
            if(x == -1)
            {
                //Add right force
                myBody.AddForce(new Vector2(Speed / 2, 0), ForceMode2D.Impulse);
            }
        }
     
    }
    bool IsGrounded()
    {
        return Physics2D.CapsuleCast(capCol.bounds.center, capCol.bounds.size,CapsuleDirection2D.Vertical, 0f, Vector2.down,0.1f,groundLayer);
    }
    void Jumping(float force)
    {
        force = jumpForce;
        if(isJump)
        {
            //Jump press
            myBody.velocity = new Vector2(myBody.velocity.x, force);
            isJump = false;
        }
    }

    void Dead()
    {

    }
}

