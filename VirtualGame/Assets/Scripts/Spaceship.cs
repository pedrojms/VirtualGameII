using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        { // Move left
            gameObject.transform.Translate(-4f * Time.deltaTime, 0, 0);
            
        }

        if (Input.GetKey("right"))
        { // Move Right
            gameObject.transform.Translate(4f * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("up"))
        { // Move Up
            gameObject.transform.Translate(0,4f * Time.deltaTime, 0);
        }

        if (Input.GetKey("down"))
        { // Move Up
            gameObject.transform.Translate(0, -4f * Time.deltaTime, 0);
        }

    }
}
