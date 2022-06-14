using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    [SerializeField]
    private float deactivateTimer = 2f;
    private void OnEnable()
    {
        Invoke(nameof(DeactivateGameObj), deactivateTimer);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(DeactivateGameObj));
    }
    private void DeactivateGameObj ()
    {
        //Destroy(gameObject);
        //CancelInvoke(nameof(DeactivateGameObj));
        // Set this bullet is Deactive
        gameObject.SetActive(false);
        
    }
}
