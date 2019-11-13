using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Agent
{
    heroshipSphere
}

public class CollManager : MonoBehaviour
{
    public Agent agent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("kokokriko");
        Destroy(other);
    }
    
}
