using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public int walkSpeed;

    bool moving;

    // Start is called before the first frame update
    void Start()
    {
        walkSpeed = 0;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Camera.main.transform.forward * walkSpeed * Time.deltaTime;
    }

    public bool walkHandler()
    {
        if (moving == false)
        {
            move();
            moving = true;
        }
        else
        {
            stop();
            moving = false;
        }

        return moving;
    }

    public void move()
    {
        walkSpeed = 2;
    }

    public void stop()
    {
        walkSpeed = 0;
    }
}
