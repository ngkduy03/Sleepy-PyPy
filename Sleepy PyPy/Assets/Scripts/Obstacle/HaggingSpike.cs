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

        playerHit = Physics2D.Raycast(transform.position, Vector2.down, 100f, playerLayer);
        Debug.DrawRay(transform.position, Vector2.down * 10f, Color.red);

        if (playerHit)
        {
            playerDetected = true;
            myBody.gravityScale = 1.5f;
            Invoke("DeactivateObj", 2f);
        }
    }

    private void DeactivateObj()
    {
        gameObject.SetActive(false);
    }
}
