using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooterPool : MonoBehaviour
{
    [SerializeField]
    private GameObject wBullet;
    [SerializeField]
    private Transform wBulletSpawn;
    private  List<GameObject> BulletStorage = new List<GameObject>();
    private int initialBullets = 4; 
    private float minShootWaitTime = 1f, maxShootWaitTime = 3f;
    private float waitTime;

    private void Awake()
    {
        CreatBullets();
    }
    private void Start()
    {
        waitTime = Time.time + Random.Range(minShootWaitTime, maxShootWaitTime);
    }
    private void Update()
    {
        if (Time.time > waitTime)
        {
            waitTime = Time.time + Random.Range(minShootWaitTime, maxShootWaitTime);
            Shoot();
        }
    }
    void CreatBullets ()
    {
        for(int i = 0; i < initialBullets; i++)
        {
            GameObject newBullet = Instantiate(wBullet);
            newBullet.SetActive(false);
            newBullet.transform.parent = wBulletSpawn;
            BulletStorage.Add(newBullet);
        }
    }

    void Shoot()
    { 
        foreach (GameObject bull in BulletStorage)
        {
            if (!bull.activeInHierarchy)
            {
                bull.SetActive(true);
                bull.transform.position = wBulletSpawn.position;
                break;
            }
        }
    }    
}
