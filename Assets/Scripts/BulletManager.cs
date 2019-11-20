using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    HeroshipA,
    HerochipB,
    EnemyA
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
            case BulletType.HeroshipA:
                HeroshipA();
                break;
            case BulletType.HerochipB:

                break;
            case BulletType.EnemyA:

                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (type)
        {
            case BulletType.HeroshipA:
                if (other.tag=="CanDamage")
                {
                    Destroy(other.gameObject);
                }
                break;
            case BulletType.HerochipB:

                break;
            case BulletType.EnemyA:

                break;
        }
    }

    void HeroshipA()
    {
        timer++;
        if (timer==100)
        {
            Destroy(gameObject);
        }
    }
}
