using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    public GameObject bulletPos, bullet;
    Vector2 randomFollow;

    int timerA, timerB, timerALimit = 15, timerBLimit = 100;
    void Awake()
    {
        
    }

    void Update()
    {
        timerB++;
        if (timerB==timerBLimit)
        {
            randomFollow=new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
            //transform.position=new Vector3(randomFollow.x, randomFollow.y, transform.position.z);
            timerB = 0;
            timerBLimit = Random.Range(20, 250);
            float heroVelocity= heroship.GetComponent<Rigidbody>().velocity.z;
            velocity = Random.Range(heroVelocity, heroVelocity * 1.8f);
            
        }

        //timerA++;
        //if (timerA==timerALimit)
        //{
        //    GameObject droped=Instantiate(bullet);
        //    droped.transform.position=bulletPos.transform.position;
        //    droped.GetComponent<Rigidbody>().AddForce(transform.up*(-100));
        //    droped.AddComponent<CollManager>().agent=Agent.EnemyA_Bullet;
        //    timerA=0;
        //    timerALimit=Random.Range(10, 50);
        //}

        //transform.position = Vector3.Lerp(transform.position, new Vector3(randomFollow.x, randomFollow.y, transform.position.z), 0.1f);
        GetComponent<Rigidbody>().velocity = transform.up;// * velocity;
        
    }
}
