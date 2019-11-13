using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Agent
{
    heroshipFocus,
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
        switch (agent)
        {
            case Agent.heroshipFocus:
                Destroy(other.gameObject);
                break;
            default:
                break;
        }
    }

    
    
}
