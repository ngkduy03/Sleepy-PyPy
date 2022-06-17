using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private float distance;
    private BoxCollider2D boxCol;
    private RaycastHit2D playerHit;
    private Rigidbody2D myBody;
    
    void Awake()
    {
        boxCol = GetComponent<BoxCollider2D>();
        myBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }

    private void DetectPlayer()
    {


        playerHit = Physics2D.Raycast(transform.position, Vector2.up, distance, playerLayer);
        Debug.DrawRay(transform.position, Vector2.up * distance, Color.red);

        if (playerHit)
        {
           Invoke("Falling",0.8f);
           Invoke("DeactivateObj", 3f);
        }
    }

    private void DeactivateObj()
    {
        gameObject.SetActive(false);
    }
    private void Falling()
    {
        myBody.isKinematic = false;
        myBody.gravityScale = 8f;
        boxCol.isTrigger=true;
    }
}
