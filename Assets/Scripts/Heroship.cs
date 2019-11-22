using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ShipType
{
    capsuler, spheric
}
public class Heroship : MonoBehaviour
{
    public ShipType ship;
    public GameObject cam, camOrigin, limits, focus, cannon, bullet;
    public float speed, sensibility, aceleration;
    public bool withCannon;
    Vector3 lastpos, lastrot;

    float mousex, mousey;

    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        aceleration=speed;
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        switch (ship)
        {
            case ShipType.capsuler:
                ControlCapsuler();
                if (withCannon)
                {
                    Shot();
                }
                break;
            case ShipType.spheric:
                ControlSpheric();
                Shot();
                break;
        }
        lastpos=transform.position;
        lastrot=transform.eulerAngles;
    }

    void OnCollisionEnter(Collision other)
    {
        // GetComponent<Rigidbody>().velocity=Vector3.zero;
        // GetComponent<Rigidbody>().freezeRotation=true;
        //GetComponent<Rigidbody>().freezeRotation=false;
    }

    void Reactive()
    {
        GetComponent<Rigidbody>().freezeRotation=false;
    }

    // FUNCIONES PARA NAVE CAPSULAR _______________________________________________________________________________________________________
    void ControlCapsuler()
    {
        mousey=Input.GetAxis("Mouse X");
        mousex=Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(mousex,mousey*-1,0)*sensibility);
        limits.transform.position=new Vector3(transform.position.x/5,0,transform.position.z);
        cam.transform.position=new Vector3(transform.position.x,transform.position.y+0.1f,camOrigin.transform.position.z);
        cam.transform.LookAt(transform.position);
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            aceleration+=1f;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            aceleration-=1;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().velocity=transform.forward*aceleration;
        }
        else
        {
            GetComponent<Rigidbody>().velocity=Vector3.zero;
        }
        
    }    

    // FUNCIONES PARA NAVE ESFÉRICA _______________________________________________________________________________________________________
    void ControlSpheric()
    {
        mousey=Input.GetAxis("Mouse X");
        mousex=Input.GetAxis("Mouse Y");
        cannon.transform.Rotate(new Vector3(mousex,mousey*-1,0)*sensibility);
        Vector3 toLook=cannon.transform.GetChild(1).transform.position;
        cam.transform.LookAt(toLook);
        cam.transform.position=Vector3.Lerp(cam.transform.position, camOrigin.transform.position, 0.1f);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            aceleration+=1f;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            aceleration-=1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().velocity=cannon.transform.forward*aceleration;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().velocity=cannon.transform.forward*aceleration*-1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().velocity=cannon.transform.right*aceleration*0.5f;
        }  
        else if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().velocity=cannon.transform.right*aceleration*-0.5f;
        }   
        else
        {
            GetComponent<Rigidbody>().velocity=Vector3.zero;
        }

        
    }


    void Shot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bt = Instantiate(bullet);
            GameObject cannonC = cannon.transform.GetChild(0).gameObject;
            bt.transform.eulerAngles = cannonC.transform.eulerAngles;
            bt.transform.position = cannon.transform.position;//+(bt.transform.forward*0.05f);
            bt.GetComponent<Rigidbody>().AddForce(bt.transform.up * 700);
            bt.AddComponent<BulletManager>().type = BulletType.HeroshipA;
        }
    } 

}


