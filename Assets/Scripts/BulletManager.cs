using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Heroship,
    EnemyA,
    EnemyB
}
public class BulletManager : MonoBehaviour
{
    public BulletType type;
    int timer;
    void Start()
    {
        
    }

    void Update()
    {
        switch (type)
        {
            case BulletType.Heroship:
                Heroship();
                break;
            case BulletType.EnemyA:

                break;
            case BulletType.EnemyB:
                EnemyB();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (type)
        {
            case BulletType.Heroship:
                if (other.tag=="CanDamage")
                {
                    Destroy(other.gameObject);
                }
                break;
            case BulletType.EnemyA:

                break;
            case BulletType.EnemyB:
                if (other.gameObject.GetComponent<Heroship>())
                {
                    Vector3 tempVel=GetComponent<Rigidbody>().velocity;
                    other.gameObject.GetComponent<Rigidbody>().AddForce(tempVel*500);
                    other.gameObject.GetComponent<Heroship>().stroke=true;
                    Destroy(gameObject);
                }
                break;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (type==BulletType.EnemyB && other.gameObject.GetComponent<Heroship>())
        {
            Vector3 tempVel=GetComponent<Rigidbody>().velocity;
            other.gameObject.GetComponent<Rigidbody>().AddForce(tempVel*500);
            other.gameObject.GetComponent<Heroship>().stroke=true;
            Destroy(gameObject);
        }
    }

    void Heroship()
    {
        timer++;
        if (timer==70)
        {
            Destroy(gameObject);
        }
    }

    void EnemyB()
    {
        timer++;
        if (timer==60)
        {
            Destroy(gameObject);
        }
    }
}
