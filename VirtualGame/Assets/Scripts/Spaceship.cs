using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{
    public Canvas lost;
    bool active;
    // Start is called before the first frame update
    void Start()
    {
        lost.GetComponent<Canvas>();
        lost.enabled = false;


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        active = !active;
        Debug.Log("perdiste");
        lost.GetComponent<Canvas>();
        lost.enabled = active; 
        Time.timeScale = 0;
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
            gameObject.transform.Translate(0, 4f * Time.deltaTime, 0);
        }

        if (Input.GetKey("down"))
        { // Move Up
            gameObject.transform.Translate(0, -4f * Time.deltaTime, 0);
        }

    }
}
