using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardSpike : MonoBehaviour
{
    [SerializeField]
    private Transform targetRightPos;
    [SerializeField]
    private Transform targetLeftPos;
    [SerializeField]
    private float moveSpeed = 5;
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private bool right;

    private RaycastHit2D playerHit;
    private bool playerDetected;

   

    // Update is called once per frame
    void Update()
    {
        DetectPlayerFormRightSide();
        DetectPlayerFormLeftSide();
    }

    private void DetectPlayerFormRightSide()
    {
        if(!right)
            return;

        // Raycast method create a red line from this.transfrom.positon to Vector2.right with distance is 100
        // Layer interact with is Player
        playerHit = Physics2D.Raycast(transform.position, Vector2.right, 100f, playerLayer);
        Debug.DrawRay(transform.position, Vector2.right * 10f, Color.red);

        if (playerHit)
        {
            playerDetected = true;
        }

        //When the line interact with player, it will move forward
        if(playerDetected)
            transform.position = Vector3.MoveTowards(transform.position, targetRightPos.position,
            moveSpeed * Time.deltaTime);
    }

    private void DetectPlayerFormLeftSide()
    {
        if (right)
            return;
        
        playerHit = Physics2D.Raycast(transform.position, Vector2.left, 100f, playerLayer);
        Debug.DrawRay(transform.position, Vector2.left * 10f, Color.red);

        if (playerHit)
        {
            playerDetected = true;
        }
        if (playerDetected)
            transform.position = Vector3.MoveTowards(transform.position, targetLeftPos.position,
            moveSpeed * Time.deltaTime);
    }
}
