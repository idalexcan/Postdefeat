using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroship : MonoBehaviour
{
    public GameObject cam, camOrigin, limits, cannon, bullet, focus, target;
    public float speed, sensibility;

    float mousex, mousey;
    int timerA;
    Vector3 targetpos;
    
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        focus.AddComponent<CollManager>().agent = Agent.heroshipFocus;
    }

    void Update()
    {
        Control();
        FocusControl();
    }

    void Control()
    {
        mousey=Input.GetAxis("Mouse X");
        mousex=Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(mousex,mousey*-1,0)*sensibility);
        limits.transform.position=new Vector3(transform.position.x/5,0,transform.position.z);
        cam.transform.position=new Vector3(cam.transform.position.x,cam.transform.position.y,camOrigin.transform.position.z);
        cam.transform.LookAt(transform.position);
        cannon.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, 0);
        timerA++;
        if (timerA==5)
        {
            targetpos=transform.position;
            timerA=0;
        }
        cam.transform.position=Vector3.Lerp(cam.transform.position, targetpos+new Vector3(0,0.1f,0), speed/200);
        if (Input.GetMouseButton(0))
        {
            GetComponent<Rigidbody>().velocity=transform.forward*speed;
        }
        else
        {
            GetComponent<Rigidbody>().velocity=Vector3.zero;
        }
    }

    void FocusControl()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.GetChild(2).transform.position+=transform.forward*sensibility/20;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.GetChild(2).transform.position-=transform.forward*sensibility/20;
        }
        focus.transform.position = transform.GetChild(2).transform.position;
        focus.SetActive(Input.GetKey(KeyCode.Space));
    }
}


