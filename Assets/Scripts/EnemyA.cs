using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour
{
    public GameObject bulletPos, bullet;
    Vector2 randomFollow;

    int timer, timerLimit=15;
    void Awake()
    {
        
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            randomFollow=new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
            transform.position=new Vector3(randomFollow.x, randomFollow.y, transform.position.z);
        }

        timer++;
        if (timer==timerLimit)
        {
            GameObject droped=Instantiate(bullet);
            droped.transform.position=bulletPos.transform.position;
            droped.GetComponent<Rigidbody>().AddForce(transform.up*(-100));
            droped.AddComponent<CollManager>().agent=Agent.EnemyA_Bullet;
            timer=0;
            timerLimit=Random.Range(10, 50);
        }

        transform.position+=transform.up*0.1f;
    }
}
