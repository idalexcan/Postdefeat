using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroship : MonoBehaviour
{
    public GameObject cam, camOrigin, limits, cannon, bullet, sphere;
    public float speed, sensibility;

    public float mousex, mousey;
    int timerA;
    Vector3 targetpos;
    
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        sphere.AddComponent<CollManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Control();
        Shot();

    }

    void Control()
    {
        mousey=Input.GetAxis("Mouse X");
        mousex=Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(mousex,mousey*-1,0)*sensibility);
        limits.transform.position=new Vector3(transform.position.x/5,0,transform.position.z);
        cam.transform.position=new Vector3(cam.transform.position.x,cam.transform.position.y,camOrigin.transform.position.z);
        cam.transform.LookAt(transform.position);
        timerA++;
        if (timerA==5)
        {
            targetpos=transform.position;
            timerA=0;
        }
        cam.transform.position=Vector3.Lerp(cam.transform.position, targetpos+new Vector3(0,0.1f,0), speed/70);
        if (Input.GetMouseButton(0))
        {
            GetComponent<Rigidbody>().velocity=transform.forward*speed;
        }
        else
        {
            GetComponent<Rigidbody>().velocity=Vector3.zero;
        }
    }

    void Shot()
    {
        if (Input.GetKey(KeyCode.W))
        {
            sphere.transform.position+=sphere.transform.forward*sensibility/20;
        }
    }
}


