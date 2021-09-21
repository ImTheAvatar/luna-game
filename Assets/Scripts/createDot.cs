using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createDot : MonoBehaviour
{
    public GameObject theDot;
    public GameObject theObj;
    public float spamTime=0.1f;
    void Start()
    {
        StartCoroutine(instantiate());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("SpaceShip"))
        {
            Destroy(gameObject, 0.1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void spawnDot()
    {
        Instantiate(theDot, theObj.transform.position, Quaternion.identity);
    }
    IEnumerator instantiate()
    {
        while (true)
        {
            yield return new WaitForSeconds(spamTime);
            spawnDot();
        }
    }
}
