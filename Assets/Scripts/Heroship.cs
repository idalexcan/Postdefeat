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
    public float speed, sensibility, aceleration, focusDistance;

    float mousex, mousey;

    
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (ship==ShipType.capsuler)
        {
            focus.AddComponent<CollManager>().agent = Agent.heroshipFocus;
            focus.GetComponent<CollManager>().gameObjectA=gameObject;
        }
        else if (ship==ShipType.spheric)
        {
            
        }

        aceleration=speed;
    }

    void Update()
    {
        if (ship==ShipType.capsuler)
        {
            ControlCapsuler();
            FocusControl();
        }
        else if (ship==ShipType.spheric)
        {
            ControlSpheric();
            Shot();
        }
        
    }

    void ControlCapsuler()
    {
        mousey=Input.GetAxis("Mouse X");
        mousex=Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(mousex,mousey,0)*sensibility);
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

    public GameObject caught;
    void FocusControl()
    {
        focusDistance=(focus.transform.position-transform.position).magnitude;
        if (Input.GetKey(KeyCode.D))
        {
            transform.GetChild(2).transform.position+=transform.forward*sensibility/20;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.GetChild(2).transform.position-=transform.forward*sensibility/20;
        }
        focus.transform.position = transform.GetChild(2).transform.position;

        if (Input.GetMouseButton(0) && caught!=null && caught!=focus.gameObject && caught.isStatic==false)
        {
            caught.transform.position=focus.transform.position;

        }
    }

    void ControlSpheric()
    {
        mousey=Input.GetAxis("Mouse X");
        mousex=Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(mousex,mousey*-1,0)*sensibility);
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().velocity=transform.forward*aceleration;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().velocity=transform.forward*aceleration*-1;
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
            GameObject bt=Instantiate(bullet);
            bt.transform.position=cannon.transform.position+(transform.forward*0.05f);
            bt.transform.eulerAngles=cannon.transform.eulerAngles;
            bt.GetComponent<Rigidbody>().AddForce(bt.transform.up*300);
            bt.AddComponent<CollManager>().agent=Agent.Bullet;
            bt.GetComponent<CollManager>().idBullet=2;
        }
    } 

}


