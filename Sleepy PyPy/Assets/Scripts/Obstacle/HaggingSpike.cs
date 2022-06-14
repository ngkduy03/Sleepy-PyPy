using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaggingSpike : MonoBehaviour
{
    private Rigidbody2D myBody;

    [SerializeField]
    private LayerMask playerLayer;

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

        if (playerDetected)
            return;

        // Raycast method create a red line from this.transfrom.positon to Vector2.right with distance is 100
        // Layer interact with is Player
        playerHit = Physics2D.Raycast(transform.position, Vector2.down, 100f, playerLayer);
        Debug.DrawRay(transform.position, Vector2.down * 10f, Color.red);

        if (playerHit)
        {
            // if the line hit player this code block will run
            playerDetected = true;
            myBody.gravityScale = 1.5f; // Set gravity in order to make this gameObject fall
            Invoke("DeactivateObj", 2f);    // Run DeactivateObj after 2 second
        }
    }

    private void DeactivateObj()
    {
        // Set this gameObject is Deactive
        gameObject.SetActive(false);
    }
}
