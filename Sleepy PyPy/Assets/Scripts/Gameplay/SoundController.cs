using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    [SerializeField]
    private AudioClip pJump, collectable, gameOver, victory, door;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    public void P_pJump()
    {
        AudioSource.PlayClipAtPoint(pJump, transform.position);
    }
    public void P_collectable()
    {
        AudioSource.PlayClipAtPoint(collectable, transform.position);
    }
    public void P_gameOver()
    {
        AudioSource.PlayClipAtPoint(gameOver, transform.position);
    }
    public void P_victory()
    {
        AudioSource.PlayClipAtPoint(victory, transform.position);
    }
    public void P_door()
    {
        AudioSource.PlayClipAtPoint(door, transform.position);
    }
}
