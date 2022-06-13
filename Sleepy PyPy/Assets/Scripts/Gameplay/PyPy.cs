using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyPy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private LayerMask groundLayer;
 

    private CapsuleCollider2D capCol;
    private Rigidbody2D myBody;
    private Vector3 tempos;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        capCol = GetComponent<CapsuleCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Jumping(14f);
    }
    private void FixedUpdate()
    {
        Moving(10f);

    }

    void Moving(float Speed)
    {
        Speed = moveSpeed;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            myBody.velocity = new Vector2(-Speed, myBody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            myBody.velocity = new Vector2(Speed, myBody.velocity.y);
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
        IsGrounded();
        if(Input.GetButton("Jump"))
        {
            if (IsGrounded())
                myBody.velocity = new Vector2(myBody.velocity.x, force);
        }
    }

}

