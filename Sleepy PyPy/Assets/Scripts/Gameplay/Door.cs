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
        SoundController.instance.P_door();
        anim.Play("open");
        boxCol.enabled = false;
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
}
