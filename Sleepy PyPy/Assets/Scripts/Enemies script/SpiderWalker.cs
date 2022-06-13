using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour
{
    private SpriteRenderer spriteRend;
    private Transform groundCheckpos;

    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private bool useGroundChecked;
    [SerializeField]
    private float walkDistance;
    private float minWalk,maxWalk;
    private bool moveLeft;
    private float scaleX;
    private RaycastHit2D groundHit;
    private Vector3 tempPos;
    private Vector3 tempScale;

    
    private void Awake()
    {
        //walk with ground check
        spriteRend = GetComponent<SpriteRenderer>();
        groundCheckpos = transform.GetChild(0);
        moveLeft = Random.RandomRange(0,2) > 0 ? true : false;
        scaleX = transform.localScale.x;
        //walk with min max distance
        maxWalk = transform.position.x + walkDistance;
        minWalk = transform.position.x - walkDistance;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WalkingWithGroundChecked(moveSpeed);
        CheckForGround();
        WalkingWithDistance(moveSpeed);      
    }

    void CheckForGround()
    {
        groundHit = Physics2D.Raycast(groundCheckpos.position, Vector2.down, 0.1f, groundLayer);
        if(!groundHit)
        {
            moveLeft = !moveLeft;
        }
    }

    void WalkingWithGroundChecked(float speed)
    {
        if (!useGroundChecked)
            return;

        speed = moveSpeed;
        tempPos = transform.position;
        tempScale = transform.localScale;

        if(moveLeft)
        {
            tempPos.x -= speed*Time.deltaTime;
            tempScale.x = -scaleX;
        }
        else
        {
            tempPos.x += speed * Time.deltaTime;
            tempScale.x = scaleX;
        }
        transform.position = tempPos;
        transform.localScale = tempScale;
    }

    void WalkingWithDistance(float speed)
    {
        if (useGroundChecked)
            return;


        tempPos=transform.position;
        speed = moveSpeed;

        if (moveLeft)
        {
            tempPos.x -= speed * Time.deltaTime;
        }
        if (!moveLeft)
        {
            tempPos.x += speed * Time.deltaTime;
        }
        transform.position=tempPos;
        spriteRend.flipX = moveLeft;

        if (tempPos.x < minWalk)
            moveLeft = false;
        if(tempPos.x> maxWalk)
            moveLeft = true;
    }
}
