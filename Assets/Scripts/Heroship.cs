using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroship : MonoBehaviour
{
    public GameObject cam, camOrigin, focus, cannon, bullet, cannonpos;
    public float speed, sensibility, aceleration, change=2;
    public bool withCannon, stroke;

    float mousex, mousey;
 
    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        aceleration=speed;
        cannonpos=transform.GetChild(0).transform.GetChild(3).gameObject;

        // de 0 a 12
    }

    void Update()
    {
        ControlB();
        ShotB();
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag=="Dagerous")
        {
            Destroy(gameObject);
        }
    }

    void ControlA()
    {
        mousey=Input.GetAxis("Mouse X");
        mousex=Input.GetAxis("Mouse Y");
        cannon.transform.Rotate(new Vector3(mousex,mousey*-1,0)*sensibility);
        cannon.transform.position=cannonpos.transform.position;
        Vector3 toLook=cannon.transform.GetChild(1).transform.position;
        cam.transform.LookAt(toLook);
        cam.transform.position=Vector3.Lerp(cam.transform.position, camOrigin.transform.position, 0.1f);
        transform.GetChild(0).transform.LookAt(toLook);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            aceleration=speed*3;
        }
        else
        {
            aceleration=speed;
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
            GetComponent<Rigidbody>().velocity=cannon.transform.right*aceleration;
        }  
        else if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().velocity=cannon.transform.right*aceleration*-1;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity=transform.up*aceleration*3;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            GetComponent<Rigidbody>().velocity=transform.up*aceleration*-3;
        }
        else
        {
            if (stroke==false)
            {
                GetComponent<Rigidbody>().velocity=Vector3.zero;
            }
            
        }  
        
    }

    void ControlB()
    {
        transform.eulerAngles=new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        Transform toLook=cannon.transform.GetChild(1).transform;
        cam.transform.LookAt(toLook.GetChild(0).transform.position);
        
        cam.transform.position=new Vector3(cam.transform.position.x, cam.transform.position.y, camOrigin.transform.position.z);
        cam.transform.position=Vector3.Lerp(cam.transform.position, camOrigin.transform.position, 0.07f);

        mousey=Input.GetAxis("Mouse X");
        mousex=Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(mousex,mousey*-1,0)*sensibility);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            change=2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            change=3.5f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            change=5;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift) )
            {
                aceleration=speed*change;
                
            }
            else
            {
                aceleration=speed;
            }
        }

        

        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().velocity=cannon.transform.forward*aceleration;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().velocity=cannon.transform.forward*aceleration*-1;
        }
        else
        {
            GetComponent<Rigidbody>().velocity=Vector3.zero;
        }
    }

    void ShotA()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bt = Instantiate(bullet);
            GameObject cannonC = cannon.transform.GetChild(0).gameObject;
            bt.transform.eulerAngles = cannonC.transform.eulerAngles;
            bt.transform.position = cannon.transform.position;
            bt.GetComponent<Rigidbody>().AddForce(bt.transform.up * 700);
            bt.AddComponent<BulletManager>().type = BulletType.Heroship;
        }
    } 

    void ShotB()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bt = Instantiate(bullet);
            GameObject cannonC = cannon.transform.GetChild(0).gameObject;
            bt.transform.eulerAngles = cannonC.transform.eulerAngles;
            bt.transform.position = cannon.transform.position;
            bt.GetComponent<Rigidbody>().AddForce(bt.transform.forward * 1000);
            bt.AddComponent<BulletManager>().type = BulletType.Heroship;
        }
    }

}


