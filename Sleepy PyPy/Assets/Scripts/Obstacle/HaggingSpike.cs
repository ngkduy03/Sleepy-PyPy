using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaggingSpike : MonoBehaviour
{
    private Rigidbody2D myBody;

    [SerializeField]
    private LayerMask playerLayer;

    [SerializeField]
    private float distance;


    private RaycastHit2D playerHit;
    private bool playerDetected;
    void Awake()
    {
        myBody=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }

    private void DetectPlayer()
    {
       

        playerHit = Physics2D.Raycast(transform.position, Vector2.down, distance, playerLayer);
        Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);

        if (playerHit)
        {
            
            myBody.gravityScale = 8f;
            Invoke("DeactivateObj", 2f);
        }
    }

    private void DeactivateObj()
    {
        gameObject.SetActive(false);
    }
}
