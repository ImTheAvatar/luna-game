using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAroundObject : MonoBehaviour
{
    public GameObject obj;
    Vector3 pivot;
    public int cw;
    public float angleSpeed;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 0.1f);
        Application.Quit();
    }
    void changeCw()
    {
        float angle=transform.rotation.eulerAngles.z;
        while (angle >= 360)
            angle -=360;
        while (angle < 0)
            angle += 360;
        float look = Mathf.Atan2(transform.position.y - pivot.y, transform.position.x - pivot.x)*Mathf.Rad2Deg;
        look -= 90;
        while (look >= 360)
            look -= 360;
        while (look < 0)
            look += 360;
        if (look >= 180)
        {
            if (angle <= look && angle >= look - 180)
            {
                cw = 1;
            }
            else
            {
                cw = -1;
            }
        }
        else
        {
            if(angle<=look&&angle>=look-180)
            {
                cw = 1;
            }
        }
        Vector3 direction = new Vector3(pivot.x - transform.position.x, pivot.y - transform.position.y, 0f);
        float res = Vector3.SignedAngle(direction, transform.up,Vector3.forward);
        if(res<=0)
        {
            cw = -1;
        }
        else
        {
            cw = 1;
        }
    }
    void Start()
    {
        if (obj != null)
        {
            pivot = obj.transform.position;
            AstroidStats.previous = obj;
        }
    }
    void setObj(GameObject other)
    {
        obj = other.gameObject;
        pivot = other.gameObject.transform.position;
        AstroidStats.onSpace = false;
        AstroidStats.previous = other;
        changeCw();
    }
    void changeAngle()
    {
        float distance = Vector3.Distance(pivot, transform.position);
        float angleChange = -cw * 1f / distance*AstroidStats.speed*Time.deltaTime*angleSpeed;
        if(obj.name=="Astroid_small")
        {
            if(distance>=8&&distance<=10)
            {
                angleChange -= 0.001f * -cw * AstroidStats.speed * Time.deltaTime * angleSpeed;
            }
            if(distance<=12&&distance>10)
            {
                angleChange += 0.001f*-cw * AstroidStats.speed * Time.deltaTime * angleSpeed;
            }
        }
        if (obj.name == "Astroid_medium")
        {
            if (distance >= 13 && distance <= 15)
            {
                angleChange -= 0.001f * -cw * AstroidStats.speed * Time.deltaTime * angleSpeed;
            }
            if (distance <= 17 && distance > 15)
            {
                angleChange += 0.001f * -cw * AstroidStats.speed * Time.deltaTime * angleSpeed;
            }
        }
        if (obj.name == "Astroid_big")
        {
            if (distance >= 18 && distance <= 20)
            {
                angleChange -= 0.1f * -cw * AstroidStats.speed * Time.deltaTime * angleSpeed*(20-distance);
            }
            if (distance <= 22 && distance > 20)
            {
                angleChange += 0.1f * -cw * AstroidStats.speed * Time.deltaTime * angleSpeed*(distance - 20);
            }
        }
        transform.Rotate(0f, 0f, angleChange);
    }
    void FixedUpdate()
    {
        transform.position += transform.up * AstroidStats.speed * Time.deltaTime;
        if (!AstroidStats.onSpace)
        {
            changeAngle();
            if(obj.name=="Astroid_small")
            {
                if(Vector3.Distance(pivot,transform.position)>12)
                {
                    AstroidStats.onSpace = true;
                }
            }
            if (obj.name == "Astroid_medium")
            {
                if (Vector3.Distance(pivot, transform.position) > 17)
                {
                    AstroidStats.onSpace = true;
                }
            }
            if (obj.name == "Astroid_big")
            {
                if (Vector3.Distance(pivot, transform.position) > 22)
                {
                    AstroidStats.onSpace = true;
                }
            }
        }
        else
        {
            if(Vector3.Distance(GameObject.Find("Astroid_small").transform.position,transform.position)<=12)
            {
                if (AstroidStats.previous == GameObject.Find("Astroid_small"))
                    return;
                setObj(GameObject.Find("Astroid_small"));
            }
            if (Vector3.Distance(GameObject.Find("Astroid_medium").transform.position, transform.position) <= 17)
            {
                if (AstroidStats.previous == GameObject.Find("Astroid_medium"))
                    return;
                setObj(GameObject.Find("Astroid_medium"));
            }
            if (Vector3.Distance(GameObject.Find("Astroid_big").transform.position, transform.position) <= 22)
            {
                if (AstroidStats.previous == GameObject.Find("Astroid_big"))
                    return;
                setObj(GameObject.Find("Astroid_big"));
            }
        }
    }
}
