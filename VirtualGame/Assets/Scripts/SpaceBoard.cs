using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBoard : MonoBehaviour
{
    private GameObject[] SpawnPoint;
    public GameObject Prefab;
    private float time = 0;
    private int i = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = GameObject.FindGameObjectsWithTag("Asteroid");
        
        InstantiateAsteroid(0);
               
        

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 5 && i<4)
        {
            time = 0;
            InstantiateAsteroid(i);
            i++;
            //if (i == 3){i = 0;}
            
        }
        
                                
    }

    public void InstantiateAsteroid(int n)
    {
        var asteroid = GameObject.Instantiate(Prefab, SpawnPoint[n].transform.position, Quaternion.identity);
        CircleCollider2D cc = asteroid.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;
        Rigidbody2D rb=asteroid.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        cc.sharedMaterial = Resources.Load("Bounciness") as PhysicsMaterial2D;
        rb.gravityScale = 0;
        rb.AddForce(new Vector2(150,150));
        
        
    }

    
}
