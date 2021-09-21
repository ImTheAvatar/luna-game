using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpinAroundObjectNew : MonoBehaviour
{
    public int cw;
    public static GameObject pivot;
    public GameObject Asmall, Amedium, Abig;
    float ratio;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Start()
    {
        AstroidStats.previous = Asmall;
        pivot = Asmall;
        ratio = 1.2f;
    }
    void changeCw()
    {
        Vector3 direction = new Vector3(pivot.transform.position.x - transform.position.x, pivot.transform.position.y - transform.position.y, 0f);
        float res = Vector3.SignedAngle(direction, transform.up, Vector3.forward);
        if (res <= 0)
        {
            cw = 1;
        }
        else
        {
            cw = -1;
        }
    }
    void changeAngle()
    {
        transform.Rotate(0f, 0f, AstroidStats.speed * Time.deltaTime*cw*Mathf.PI*2 / ratio);
    }
    bool checkAngle(GameObject pos)
    {
        Vector3 direction = new Vector3(pos.transform.position.x - transform.position.x, pos.transform.position.y - transform.position.y, 0f);
        float res = Vector3.SignedAngle(direction, transform.up, Vector3.forward);
        if (res >= -95&& res <= -85)
        {
            return true;
        }
        if (res >= 85&& res <= 95)
        {
            return true;
        }

        return false;
    }
    void checkForAstroid()
    {
        if(Vector2.Distance(Asmall.transform.position,transform.position)<=12
            && Vector2.Distance(Asmall.transform.position, transform.position) >= 8)
        {
            if (!AstroidStats.previous.name.Equals("Astroid_small"))
            {
                if (checkAngle(Asmall))
                {
                    AstroidStats.onSpace = false;
                    pivot = Asmall;
                    ratio = 1.15f;
                }
            }
        }
        if (Vector2.Distance(Amedium.transform.position, transform.position) <= 17
            && Vector2.Distance(Amedium.transform.position, transform.position) >= 13)
        {
            if (!AstroidStats.previous.name.Equals("Astroid_medium"))
            {
                if (checkAngle(Amedium))
                {
                    AstroidStats.onSpace = false;
                    pivot = Amedium;
                    ratio = 1.60f;
                }
            }
        }
        if (Vector2.Distance(Abig.transform.position, transform.position) <= 22
            && Vector2.Distance(Abig.transform.position, transform.position) >= 18)
        {
            if (!AstroidStats.previous.name.Equals("Astroid_big"))
            {
                if (checkAngle(Abig))
                {
                    AstroidStats.onSpace = false;
                    pivot = Abig;
                    ratio = 2.1f;
                }
            }
        }
        if(!AstroidStats.onSpace)
        {
            changeCw();
        }
        if (AstroidStats.onSpace)
        {
            if (Vector2.Distance(Asmall.transform.position, transform.position) < 8)
            {
                pivot = Asmall;
                ratio = 1.15f * 1.5f;
                changeCw();
                changeAngle();
            }
            if (Vector2.Distance(Amedium.transform.position, transform.position) < 13)
            {
                pivot = Amedium;
                ratio = 1.6f * 1.5f;
                changeCw();
                changeAngle();
            }
            if (Vector2.Distance(Abig.transform.position, transform.position) < 18)
            {
                pivot = Abig;
                ratio = 2.1f * 1.5f;
                changeCw();
                changeAngle();
            }
        }
    }
    void Update()
    {
        transform.position += transform.up*Time.deltaTime*AstroidStats.speed;
        if(!AstroidStats.onSpace)
        {
            changeAngle();
        }
        else
        {
            checkForAstroid();
        }
    }
    private void FixedUpdate()
    {
        if(transform.position.x<Camera.main.transform.position.x-50|| transform.position.x > Camera.main.transform.position.x + 50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
