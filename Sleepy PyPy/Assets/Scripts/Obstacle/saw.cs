using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw : MonoBehaviour
{
   [SerializeField]
   private Transform movePoint_1, movePoint_2;
   [SerializeField]
   private float moveSpeed = 5f;

   private Transform targetPos;
   private bool firstMovePoint;

    [SerializeField]
    private float rotationSpeed = 100f;

    private Vector3 tempRotation = Vector3.zero;
    private float zAngle;

    private void Awake()
    {
        if(Random.Range(0,2)>0) // Random between 0 and 1
        {
            //if 1, move from movePoint_1 to movePoint_2
            firstMovePoint = false;
            targetPos = movePoint_2;
        }
        else
        {
            //if 0, move from movePoint_2 to movePoint_1
            firstMovePoint = true;
            rotationSpeed *= -1;
            targetPos = movePoint_1;
        }
    }

    private void Update()
    {
        Movement();
        Rotation();
    }

    private void Movement()
    {
        // MoveTowards move from this.transform.postion to targetPos.position
        transform.position = Vector3.MoveTowards(transform.position, targetPos.position,
            moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, targetPos.position) < 0.1f)
        {
            // if distance of this game object and target is < 0.1f, move opposite direction
            if(firstMovePoint)
            {
                firstMovePoint=false;
                targetPos = movePoint_2;
            }
            else
            {
                firstMovePoint=true;
                targetPos = movePoint_1;
            }
        }
    }

    private void Rotation()
    {
        // Rotate the saw with rotaion speed
        zAngle = Time.deltaTime * rotationSpeed;
        tempRotation.z = zAngle;
        transform.Rotate(tempRotation);
    }



}
