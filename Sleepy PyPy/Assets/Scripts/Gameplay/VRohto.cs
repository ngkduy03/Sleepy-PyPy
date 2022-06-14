using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRohto : MonoBehaviour
{
    [SerializeField]
    private float value = 10f;

    // This is called when the item is hitted by player
    // Player has one collider and the tag of player is Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision.CompareTag is called when 2 object interact with each other
        if(collision.CompareTag("Player"))
        {
            GameplayController.instance.IncreaseConscious(value);
            gameObject.SetActive(false);
        }
    }
}
