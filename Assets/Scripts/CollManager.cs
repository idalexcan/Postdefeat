﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Agent
{
    heroshipFocus,
    EnemyA_Bullet
}

public class CollManager : MonoBehaviour
{
    public Agent agent;
    public GameObject gameObjectA;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (agent)
        {
            case Agent.EnemyA_Bullet:
                BulletEnemA();
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch (agent)
        {
            case Agent.heroshipFocus:
                if (Input.GetMouseButton(1))
                {
                    if (other.GetComponent<Heroship>()==false)
                    {
                        Destroy(other.gameObject);
                    }
                }
                if (Input.GetKey(KeyCode.Space))
                {
                    gameObjectA.GetComponent<Heroship>().caught=other.gameObject;
                }
                
                break;
            case Agent.EnemyA_Bullet:
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

    int timer=0;
    void BulletEnemA()
    {
        timer++;
        if (timer>5)
        {
            if (timer>300)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.localScale+=new Vector3(1,1,1)*0.002f;
            }
        }
    }
    


    
}
