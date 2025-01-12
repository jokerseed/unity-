﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeHead : MonoBehaviour
{
    public int step;
    public float velocity = 0.35f;
    public Sprite[] sprites;
    public GameObject snakeBody;
    public Transform canvas;

    private int x;
    private int y;
    private Vector3 headPos;
    private List<GameObject> bodyList = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating("Move", 0, velocity);
        x = step;
        y = 0;
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, -90);
    }

    private void Update()
    {
        //GetKey支持长按  GetKeyDown只是按下
        if (Input.GetKey(KeyCode.W) && y != -step)
        {
            //向上
            x = 0;
            y = step;
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A) && x != step)
        {
            //向左
            x = -step;
            y = 0;
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.S) && y != step)
        {
            //向下
            x = 0;
            y = -step;
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
        if (Input.GetKey(KeyCode.D) && x != -step)
        {
            //向右
            x = step;
            y = 0;
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke();
            InvokeRepeating("Move", 0, velocity - 0.2f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke();
            InvokeRepeating("Move", 0, velocity);
        }
    }

    private void Move()
    {
        //挂在哪个物体上可以直接通过gameObject获取到该物体
        headPos = gameObject.transform.localPosition;
        gameObject.transform.localPosition = new Vector3(headPos.x + x, headPos.y + y, headPos.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "food")
        {
            Destroy(collision.gameObject);
            FoodMaker.instance.MakeFood();
        }
    }

    void Grow()
    {
        GameObject gb = GameObject.Instantiate(snakeBody);
        gb.transform.SetParent(canvas, false);
        int index = bodyList.Count % 2 == 0 ? 1 : 0;
        gb.GetComponent<Image>().sprite = sprites[index];
        bodyList.Add(gb);
    }
}
