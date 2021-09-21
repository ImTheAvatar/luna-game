using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector2 screenBounds;
    float halfHeight, halfWidth;
    public float edge;
    // Start is called before the first frame update
    void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        screenBounds = Camera.main.transform.position;
        if (transform.position.y+10 < screenBounds.y - halfHeight)
        {
            gameObject.transform.position = new Vector3(Random.Range(-halfWidth+edge, halfWidth-edge), transform.position.y + 120,transform.position.z);
        }
    }
}
