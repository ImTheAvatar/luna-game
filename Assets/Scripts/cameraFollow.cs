using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform targetObject;
    private Vector3 cameraPosition;
    private float tmp;
    bool check = false;
    void Start()
    {
        transform.position = new Vector3(transform.position.x,targetObject.position.y+30,transform.position.z);
        cameraPosition.z = -10;
        tmp = targetObject.transform.position.y;
    }

    void FixedUpdate()
    {
        if (AstroidStats.onSpace)
        {
            if(check==false)
            {
                tmp = targetObject.transform.position.y;
            }
            transform.Translate(new Vector3(0f, targetObject.transform.position.y - tmp, 0f));
            tmp = targetObject.transform.position.y;
            check = true;
        }
        else
        {
            if(targetObject.transform.position.y<SpinAroundObjectNew.pivot.transform.position.y&&check==true)
            {
                transform.Translate(new Vector3(0f, targetObject.transform.position.y - tmp, 0f));
                tmp = targetObject.transform.position.y;
            }
            else
            {
                check = false;
            }
        }
    }
}
