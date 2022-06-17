using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRohto : MonoBehaviour
{
    [SerializeField]
    private float value = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SoundController.instance.P_collectable();
            GameplayController.instance.IncreaseConscious(value);
            gameObject.SetActive(false);
        }
    }
}
