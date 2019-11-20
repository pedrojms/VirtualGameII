using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{
    public Canvas lost;
    bool active;
    private Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        lost.GetComponent<Canvas>();
        lost.enabled = false;
        trans = this.transform;


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
        { // Move Left
            var oldPos = trans.position;
            var newPos = trans.position;
            newPos.x += -4f * Time.deltaTime;
            trans.position = newPos;
            ApplyConstraints(oldPos);
            
        }

        if (Input.GetKey("right"))
        { // Move Right
            //gameObject.transform.Translate(4f * Time.deltaTime, 0, 0);
            var oldPos = trans.position;
            var newPos = trans.position;
            newPos.x += 4f * Time.deltaTime;
            trans.position = newPos;
            ApplyConstraints(oldPos);
        }

        if (Input.GetKey("up"))
        { // Move Up
            var oldPos = trans.position;
            var newPos = trans.position;
            newPos.y += 4f * Time.deltaTime;
            trans.position = newPos;
            ApplyConstraints(oldPos);


        }

        if (Input.GetKey("down"))
        { // Move Up
            var oldPos = trans.position;
            var newPos = trans.position;
            newPos.y += -4f * Time.deltaTime;
            trans.position = newPos;
            ApplyConstraints(oldPos);
        }

    }

    (bool, bool) CheckConstraints()
    {
        var isOutX = false;
        var isOutY = false;

        for (int i = 0; i < trans.childCount; i++)
        {
            var childTrans = trans.GetChild(i);

            int x = Mathf.RoundToInt(childTrans.position.x);
            Debug.Log(x);
            int y = Mathf.RoundToInt(childTrans.position.y);
            Debug.Log(y);
            if (x < -3
                || x > 3)
            {
                isOutX = true;
                break;
            }
            if (y < -3 || y>3)
            {
                isOutY = true;
                break;
            }
            var row = y;
            var col = x;
            
        }
        return (isOutX, isOutY);
    }

    (bool, bool) ApplyConstraints(Vector2 rollbackPos)
    {
        var (isOutX, isOutY) = CheckConstraints();
        if (isOutX || isOutY)
        {
            trans.position = rollbackPos;
            
        }
        return (isOutX, isOutY);
    }
}
