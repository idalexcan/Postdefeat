using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : Enemy
{
    float keeping=0.5f, impulse=100;
    public GameObject[] obstacles;
    public GameObject obstaclesP;
    int obstaclesCount=0;
    Vector3 target;
    void Awake()
    {
        
        obstacles=new GameObject[obstaclesP.transform.childCount];
        for (int i = 0, j=5; i < obstacles.Length; i++, j+=5)
        {
            obstacles[i]=obstaclesP.transform.GetChild(i).gameObject;
            obstacles[i].transform.position=new Vector3(Random.Range(-1,2), Random.Range(-1.5f,1.6f), j-0.5f);
            obstacles[i].transform.eulerAngles=RandomVector(0,360,0,360,0,360);
        }
    }

    // Update is called once per frame
    void Update()
    {
        target=obstacles[obstaclesCount].transform.GetChild(0).transform.position;
        //transform.position=Vector3.Lerp(transform.position, target, 0.08f);
        transform.position-=(transform.position-target).normalized*0.2f;
        bool aux=(transform.position-target).magnitude<1f;
        if (aux && obstaclesCount<obstacles.Length-1)
        {
            obstaclesCount++;
            obstacles[obstaclesCount].GetComponent<MeshRenderer>().enabled=true;
        }
        
    }

    
    
}
