using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject startPos;
    public float distance;
    public GameObject left;
    public GameObject right;

    [HideInInspector]
    public SpringJoint2D sj;

    bool isClick = false;
    LineRenderer r;
    LineRenderer l;
    bool canMove = true;

    private void Awake()
    {
        r = right.GetComponent<LineRenderer>();
        l = left.GetComponent<LineRenderer>();
        sj = GetComponent<SpringJoint2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (isClick)
            {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);

                if (Vector3.Distance(transform.position, startPos.transform.position) > distance)
                {
                    transform.position = (transform.position - startPos.transform.position).normalized * distance + startPos.transform.position;//向量计算
                }
                drawLine();
            }
        }

        float posX = transform.position.x;
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(Mathf.Clamp(posX, 0, 15), Camera.main.transform.position.y, Camera.main.transform.position.z), 2);
    }

    private void OnMouseDown()
    {
        if (canMove)
        {
            isClick = true;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            r.enabled = true;
            l.enabled = true;
        }
    }

    private void OnMouseUp()
    {
        if (canMove)
        {
            isClick = false;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            Invoke("fly", 0.1f);
            r.enabled = false;
            l.enabled = false;
            canMove = false;
        }
    }

    void fly()
    {
        gameObject.GetComponent<SpringJoint2D>().enabled = false;
        Invoke("Dead", 3);
    }

    /*
     *划线 
     */
    void drawLine()
    {
        r.SetPosition(0, right.transform.position);
        r.SetPosition(1, transform.position);
        l.SetPosition(0, left.transform.position);
        l.SetPosition(1, transform.position);
    }

    void Dead() {
        GameManager._instance.birds.Remove(this);
        GameManager._instance.CheckWin();
        this.enabled = false;
    }
}
