using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : Enemy
{
    float keeping=0.5f, impulse=100;
    public GameObject[] obstacles;
    public GameObject obstaclesP, taker;
    int obstaclesCount=0;
    Vector3 target;
    void Awake()
    {
        taker=GameObject.Find("Taker");
        obstacles=new GameObject[obstaclesP.transform.childCount];
        for (int i = 0, j=5; i < obstacles.Length; i++, j+=5)
        {
            obstacles[i]=obstaclesP.transform.GetChild(i).gameObject;
            obstacles[i].transform.position=new Vector3(Random.Range(-1,2), Random.Range(-1.5f,1.6f), j-0.5f);
            obstacles[i].transform.eulerAngles=RandomVector(0,360,0,360,0,360);
        }
    }

    void Update()
    {
        if ((taker.transform.position-transform.position).magnitude<0.5f)
        {
            transform.position=taker.transform.position;
            GetComponent<SphereCollider>().enabled=false;
        }
        else
        {
            target=obstacles[obstaclesCount].transform.GetChild(0).transform.position;
            transform.position-=(transform.position-target).normalized*0.2f;
            bool aux=(transform.position-target).magnitude<1f;
            if (aux && obstaclesCount<obstacles.Length-1)
            {
                obstaclesCount++;
                obstacles[obstaclesCount].GetComponent<MeshRenderer>().enabled=true;
            }
        }
    }
}
