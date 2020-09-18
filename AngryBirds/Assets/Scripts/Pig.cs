using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public float maxSpeed = 10;
    public float minSpeed = 5;
    public Sprite hurt;
    public GameObject boom;
    public GameObject score;

    private SpriteRenderer sp;

    private void Awake()
    {
        //第一次激活    
        //脚本失活也会触发

        sp = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > maxSpeed)
        {
            Dead();
        }
        else if (collision.relativeVelocity.magnitude > minSpeed)
        {
            sp.sprite = hurt;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    void Dead()
    {
        Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(gameObject);

        GameObject s = Instantiate(score, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        Destroy(s, 1.5f);
    }
}
