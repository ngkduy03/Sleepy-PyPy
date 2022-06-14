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
            // If groundHit false, mean Spider is near the edge
            // Set moveLeft = opposite (true -> false, false -> true)
            moveLeft = !moveLeft;
        }
    }

    void WalkingWithGroundChecked(float speed)
    {
        // This method is enable when useGroundChecked is enable
        if (!useGroundChecked)
            return;

        speed = moveSpeed;
        tempPos = transform.position;   // temPos is position use to compute postion
        tempScale = transform.localScale;   // tempScale is the direction the spider is face to (left, right)

        if(moveLeft)
        {
            // Spider move left
            tempPos.x -= speed * Time.deltaTime;
            // spider face turn left
            tempScale.x = -scaleX;
        }
        else
        {
            // Spider move right
            tempPos.x += speed * Time.deltaTime;
            // Spider face turn right
            tempScale.x = scaleX;
        }
        transform.position = tempPos;
        transform.localScale = tempScale;
    }

    void WalkingWithDistance(float speed)
    {
        // This method is enable when useGroundChecked is disable
        if (useGroundChecked)
            return;


        tempPos=transform.position;
        speed = moveSpeed;

        if (moveLeft)
        {
            // move left
            tempPos.x -= speed * Time.deltaTime;
        }
        if (!moveLeft)
        {
            // move right
            tempPos.x += speed * Time.deltaTime;
        }
        transform.position=tempPos;
        spriteRend.flipX = moveLeft;

        // spider will move between minWalk and maxWalk
        if (tempPos.x < minWalk)
            moveLeft = false;
        if(tempPos.x> maxWalk)
            moveLeft = true;
    }
}
