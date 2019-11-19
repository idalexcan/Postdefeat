using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    public GameObject bulletPos, bullet;
    public int[] movingLapses, shotLapses;
    Vector2 randomFollow;

    int timerA, timerB, timerALimit = 15, timerBLimit = 1;
    float herospeed;
    void Awake()
    {
        herospeed=heroship.GetComponent<Heroship>().speed;
    }

    void Update()
    {
        timerB++;
        if (timerB==timerBLimit)
        {
            randomFollow=new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
            velocity = Random.Range(herospeed*0.2f, herospeed * 1.8f);
            timerB = 0;
            timerBLimit = Random.Range(movingLapses[0], movingLapses[1]);
            
        }

        timerA++;
        if (timerA==timerALimit)
        {
           GameObject droped=Instantiate(bullet);
           droped.transform.position=bulletPos.transform.position;
           droped.GetComponent<Rigidbody>().AddForce(transform.up*(-100));
           droped.AddComponent<CollManager>().agent=Agent.Bullet;
           timerA=0;
           timerALimit=Random.Range(shotLapses[0], shotLapses[1]);
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(randomFollow.x, randomFollow.y, transform.position.z), 0.1f);
        GetComponent<Rigidbody>().velocity = transform.up * velocity;
        
        
    }
}
