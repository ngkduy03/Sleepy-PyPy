using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    [SerializeField]
    private float deactivateTimer = 3f;
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
        {
            CancelInvoke(nameof(DeactivateGameObj));
            gameObject.SetActive(false);
        }
    }
}
