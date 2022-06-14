using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Every time create a dimond, it will be register to RegisterDiamond
        Door.instance.RegisterDiamond();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Is called when this object hit player object
        if(collision.CompareTag("Player"))
        {
            Door.instance.DiamondCollected();
            gameObject.SetActive(false);
        }
    }
}
