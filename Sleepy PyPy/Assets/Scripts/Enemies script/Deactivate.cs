using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    [SerializeField]
    private float deactivateTimer = 0.010f;
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
        //if(gameObject.activeInHierarchy)
        {
            //Destroy(gameObject);
            CancelInvoke(nameof(DeactivateGameObj));
            gameObject.SetActive(false);
        }
    }
}
