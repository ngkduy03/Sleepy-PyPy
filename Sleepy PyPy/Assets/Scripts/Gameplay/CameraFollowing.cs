using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    private Transform target;
    [SerializeField]
    private float offsetX = -5f;
    [SerializeField]
    private float minX, maxX;

    private Vector3 tempPos;
    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // LateUpdate is called once per frame when the frame is finished
    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        // Target is Player
        if(!target)
            return;
        tempPos = transform.position;
        tempPos.x = target.position.x - offsetX;

        // tempPos is position we use compute
        if(tempPos.x < minX)
            tempPos.x = minX;
        if(tempPos.x > maxX)
            tempPos.x = maxX;

        transform.position = tempPos;   
    }
}
