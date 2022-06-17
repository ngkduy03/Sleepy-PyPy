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
    [SerializeField]
    private float distance;

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
        if (!right)
            return;

        MoveSpikeTo(targetRightPos, Vector2.right);
    }

    private void MoveSpikeTo(Transform target, Vector2 direction)
    {
        if (playerDetected)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                moveSpeed * Time.deltaTime
            );
        }
        else
        {
            playerHit = Physics2D.Raycast(transform.position, direction, distance, playerLayer);
            Debug.DrawRay(transform.position, direction * distance, Color.red);

            if (playerHit)
            {
                playerDetected = true;
            }
        }
    }

    private void DetectPlayerFormLeftSide()
    {
        if (right)
            return;

        MoveSpikeTo(targetLeftPos, Vector2.left);
    }
}
