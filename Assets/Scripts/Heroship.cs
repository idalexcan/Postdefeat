using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroship : MonoBehaviour
{
    public GameObject cam, camOrigin, limits, focus;
    public float speed, sensibility, aceleration, focusDistance;

    float mousex, mousey;
    int timerA;
    Vector3 targetpos;
    
    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        focus.AddComponent<CollManager>().agent = Agent.heroshipFocus;
        focus.GetComponent<CollManager>().gameObjectA=gameObject;
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
        //cam.transform.position=new Vector3(cam.transform.position.x,cam.transform.position.y,camOrigin.transform.position.z);
        cam.transform.position=new Vector3(transform.position.x,transform.position.y+0.09f,camOrigin.transform.position.z);
        cam.transform.LookAt(transform.position);
        timerA++;
        if (timerA==5)
        {
            //targetpos=transform.position;
            timerA=0;
        }
        //cam.transform.position=new Vector3(cam.transform.position.x,cam.transform.position.y,camOrigin.transform.position.z);
        //cam.transform.position=Vector3.Lerp(cam.transform.position, targetpos+new Vector3(0,0.1f,0), aceleration/200);

        if(Input.GetKey(KeyCode.D))
        {
            aceleration=speed*1.8f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            aceleration=speed*0.3f;
        }
        else
        {
            aceleration=speed;
        }

        if (Input.GetMouseButton(0))
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
        if (Input.GetKey(KeyCode.W))
        {
            transform.GetChild(2).transform.position+=transform.forward*sensibility/20;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.GetChild(2).transform.position-=transform.forward*sensibility/20;
        }
        focus.transform.position = transform.GetChild(2).transform.position;
        //focus.SetActive(Input.GetKey(KeyCode.Space));

        if (Input.GetKey(KeyCode.Space) && caught!=null && caught!=focus.gameObject)
        {
            caught.transform.position=focus.transform.position;

        }
    }
}


