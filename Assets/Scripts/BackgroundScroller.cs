﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    public float speed;
    public float Xend;
    public float Xstart;

    private void Update()
    {
        if (!winchecker.gameOver)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x < Xend)
            {
                Vector2 pos = new Vector2(Xstart, transform.position.y);
                transform.position = pos;
            }
        }
    }

    // public float speed;
    // public float endx,startx;
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     transform.Translate(Vector2.left * speed * Time.deltaTime);
    //     if (transform.position.x <= endx)
    //     {
    //         Vector2 pos = new Vector2(startx, transform.position.y);
    //         transform.position = pos;
    //     }
    // }
}
