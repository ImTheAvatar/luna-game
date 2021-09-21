using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    bool firstTime = true;
    Vector2 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!firstTime)
        {
            if (collision.gameObject.name.Equals("SpaceShip"))
            {
                Destroy(gameObject, 2f/AstroidStats.speed);
            }
        }
        else
        {
            firstTime = false;
            return;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        screenBounds = Camera.main.transform.position;
        if(transform.position.y<screenBounds.y-Camera.main.orthographicSize && !gameObject.name.Equals("dot"))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
