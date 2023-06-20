using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    
    public GameObject upFlap;
    public GameObject midFlap;
    public GameObject downFlap;

    public GameObject base1;
    public GameObject base2;

    public GameObject pipe;


    List<GameObject> sprites = new List<GameObject>();
    int currentIndex = 0;
    GameObject[] gameObjects = new GameObject[1000 * 2];

    void Start()
    {
        sprites.Add(upFlap);
        sprites.Add(midFlap);
        sprites.Add (downFlap);
        StartCoroutine(IncrementIndexCoroutine());


        int xdistance = 5;
        float random;
        for (int i = 0; i < 1000; i+=2)
        {
            random = Random.Range(-7.5f, -3f);
            gameObjects[i] = Instantiate(pipe, new Vector3(10 + i * xdistance, random, -6.14f), Quaternion.identity);
            gameObjects[i + 1] = Instantiate(pipe, new Vector3(20 + i * xdistance, random + 15, -6.14f), Quaternion.Euler(180, 0, 0));




        }

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject sprite in sprites)
        {
            sprite.GetComponent<SpriteRenderer>().enabled = false;
        }
        sprites[currentIndex].GetComponent<SpriteRenderer>().enabled = true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,6,0), ForceMode2D.Impulse);
        }

        if (transform.position.y < -6f)
        {
            base1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            base2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale *= 0;


            // Game Over
        }

    }
    private System.Collections.IEnumerator IncrementIndexCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f); 
            currentIndex++;
            currentIndex %= 3;
        }
    }
}
