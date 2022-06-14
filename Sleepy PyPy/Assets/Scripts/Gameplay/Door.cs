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
        // Play animation open door
        anim.Play("open");
    }

    public void RegisterDiamond()
    {
        // Amount of diamond this level has
        diamondCount++;
    }

    public void DiamondCollected()
    {
        // Reduce diamond in this level
        diamondCount--;
        if(diamondCount==0)
        {
            OpenDoor();
        }
    }

    void RemoveColider()
    {
        // Open the door 
        boxCol.enabled = false;
    }
}
