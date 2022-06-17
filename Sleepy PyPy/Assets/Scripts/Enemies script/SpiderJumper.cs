using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;
    [SerializeField]
    private float minJumpForce = 8f, maxJumpForce = 13f;
    [SerializeField]
    private float minWaitTime = 3f, maxWaitTime = 20f;
    private string jumpAnimation = "Jump";
    private float jumpTimer;
    private bool jumpAllowed;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        jumpTimer = Time.time + Random.Range(minWaitTime,maxWaitTime);
    }

    private void Update()
    {
        TimeToJump();
        Jump();
        JumpAnimation();
    }
    private void Jump()
    {
        if(jumpAllowed)
        {
            
            jumpAllowed = false;
            myBody.velocity = new Vector2 (0f,Random.Range(minJumpForce,maxJumpForce));
        }
    }

    private void TimeToJump()
    {
        if (Time.time > jumpTimer)
        {
            Jump();
            
            jumpTimer = Time.time + Random.Range(minWaitTime, maxWaitTime);
        }
        if(myBody.velocity.magnitude==0)
            jumpAllowed = true;
    }

    void JumpAnimation()
    {
        if (myBody.velocity.magnitude == 0)
            anim.SetBool(jumpAnimation, false);
        else
            anim.SetBool(jumpAnimation, true);
    }
}
