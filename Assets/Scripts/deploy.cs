using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deploy : MonoBehaviour
{
    public GameObject astroidPrefab;
    public float respawnTime = 4.0f;
    Vector2 screeBounds;
    // Start is called before the first frame update
    void Start()
    {
        screeBounds =Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(obstacleWave0());
    }
    void spawnObstacle(GameObject obj1,GameObject obj2)
    {
        //print("salam");
        GameObject a = Instantiate(astroidPrefab) as GameObject;
        a.transform.position = new Vector2(screeBounds.x + 5, Random.Range(obj1.transform.position.y,obj2.transform.position.y));
        a.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator obstacleWave0()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(obstacleWave1());
        yield return new WaitForSeconds(1f);
        StartCoroutine(obstacleWave2());
        yield return new WaitForSeconds(1f);
        StartCoroutine(obstacleWave3());
    }
    IEnumerator obstacleWave1()
    {
        GameObject obj1 = GameObject.Find("Astroid_small");
        GameObject obj2 = GameObject.Find("Astroid_medium");
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnObstacle(obj1, obj2);
        }
    }
    IEnumerator obstacleWave2()
    {
        GameObject obj1 = GameObject.Find("Astroid_medium");
        GameObject obj2 = GameObject.Find("Astroid_big");
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnObstacle(obj1, obj2);
        }
    }
    IEnumerator obstacleWave3()
    {
        GameObject obj1 = GameObject.Find("Astroid_small");
        GameObject obj2 = GameObject.Find("Astroid_big");
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnObstacle(obj1, obj2);
        }
    }
}
