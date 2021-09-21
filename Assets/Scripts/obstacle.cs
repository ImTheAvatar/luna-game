using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Vector2 ScreenBounds;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //print(ScreenBounds.x + "    " + ScreenBounds.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < ScreenBounds.x * -2)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name[0]=='A')
            Destroy(gameObject);
    }
}
