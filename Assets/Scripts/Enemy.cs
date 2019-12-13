using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocity;
    public GameObject heroship;

    public Vector3 RandomVector(float xa,float xb, float ya, float yb, float za, float zb)
    {
        return new Vector3(
            Random.Range(xa,xb),
            Random.Range(ya,yb),
            Random.Range(za,zb));
    }
}

