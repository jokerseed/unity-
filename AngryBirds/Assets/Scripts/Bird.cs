using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject startPos;
    public float distance;
    public GameObject left;
    public GameObject right;

    bool isClick = false;
    LineRenderer r;
    LineRenderer l;

    private void Awake()
    {
        r = right.GetComponent<LineRenderer>();
        l = left.GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

    private void OnMouseDown()
    {
        isClick = true;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    private void OnMouseUp()
    {
        isClick = false;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        Invoke("fly", 0.1f);
    }

    void fly()
    {
        gameObject.GetComponent<SpringJoint2D>().enabled = false;
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
}
