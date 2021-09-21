using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidStats : MonoBehaviour
{
    public static float speed;
    public static bool onSpace;
    private float hiddenScore;
    public static int publicScore;
    public float Speed;
    public bool OnSpace;
    public int PublicScore;
    public static GameObject previous;
    float speedOffset = 0;
    bool mouseHold;
    public GasBar gas;
    public float _gasCD = 2;
    bool justOutOfAstroid = false;
    void Start()
    {
        speed = Speed;
        onSpace = OnSpace;
        publicScore = PublicScore;
        previous = GameObject.Find("Astroid_small");
        gas.SetMaxHealth(10);
    }

    // Update is called once per frame
    void fillGas(float x)
    {
        if (gas.slider.value <= 10)
        {

            gas.increase(x * Time.deltaTime);
        }
    }
    void Update()
    {
        // print(spinObject.GetComponent<Transform>().position.x + " " +
        //    spinObject.GetComponent<Transform>().position.y);
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if (!onSpace)
            {
                onSpace = true;
                speed -= speedOffset;
                speedOffset = 0;
                previous = SpinAroundObjectNew.pivot;
                StartCoroutine(waitForSec(justOutOfAstroid, 0.1f));
            }
        }

        if (!onSpace)
        {
            speedOffset += 0.3f * Time.deltaTime;
            speed += 0.3f * Time.deltaTime;
            hiddenScore += Time.deltaTime;
            publicScore = (int)hiddenScore;

        }
        else
        {
            if (Input.touchCount > 0 && gas.slider.value > 0&&!justOutOfAstroid)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Stationary)
                {
                    if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0)
                    {
                        transform.Rotate(0f, 0f, 1f);
                    }
                    else
                    {
                        transform.Rotate(0f, 0f, -1f);
                    }
                    gas.decrease(2f * Time.deltaTime);
                    _gasCD = 2;
                }
            }
            if (Input.GetMouseButton(0) && gas.slider.value > 0 && !justOutOfAstroid)
            {

                if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0)
                {
                    // print("salam1");
                    transform.Rotate(0f, 0f, 90 / 5f * Time.deltaTime);
                }
                else
                {
                    //print("salam2");
                    transform.Rotate(0f, 0f, -90 / 5f * Time.deltaTime);
                }
                gas.decrease(2f * Time.deltaTime);
                _gasCD = 2;
            }
        }
    }
    private void LateUpdate()
    {
        print(_gasCD);
        _gasCD -= 1f * Time.deltaTime;
        if (_gasCD <= 0)
        {
            fillGas(10);
        }
    }
    IEnumerator increaseSpeed()
    {
        speed += 1f;
        yield return new WaitForSeconds(1);
    }
    IEnumerator waitForSec(bool x, float second)
    {
        x = true;
        yield return new WaitForSeconds(second);
        x = false;
    }
}
