using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Agent
{
    heroshipFocus,
    Bullet
}

public class CollManager : MonoBehaviour
{
    public Agent agent;
    public GameObject gameObjectA;
    public int idBullet, timer=0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (agent)
        {
            case Agent.Bullet:
                switch (idBullet)
                {
                    case 1:
                        BulletEA();
                        break;
                    case 2:
                        BulletHSB();
                        break;
                }
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
                if (Input.GetMouseButton(0))
                {
                    gameObjectA.GetComponent<Heroship>().caught=other.gameObject;
                }
                break;

            case Agent.Bullet:
                Destroy(gameObject);
                break;

        }
    }

    void BulletEA()
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
    
    void BulletHSB()
    {
        timer++;
        if (timer>170)
        {
            Destroy(gameObject);
        }
    }

    
}
