using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Door.instance.RegisterDiamond();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Door.instance.DiamondCollected();
            gameObject.SetActive(false);
        }
    }
}
