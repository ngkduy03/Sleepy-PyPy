using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door instance;

    private BoxCollider2D boxCol;

    private Animator anim;

    private int diamondCount;

    private void Awake()
    {
        if(!instance)
            instance = this;
        boxCol = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    void OpenDoor()
    {
        anim.Play("open");
    }

    public void RegisterDiamond()
    {
        diamondCount++;
    }

    public void DiamondCollected()
    {
        diamondCount--;
        if(diamondCount==0)
        {
            OpenDoor();
        }
    }

    void RemoveColider()
    {
        boxCol.enabled = false;
    }
}
