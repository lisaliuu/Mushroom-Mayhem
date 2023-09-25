using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{

    private float direction;
    public float move_speed = 3f;
    // public GameObject wpl;
    // public GameObject wpr;
    private Rigidbody2D rb;
    //private Vector3 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = -1f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Waypoint")){
            direction *= -1f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (direction * move_speed, rb.velocity.y);
    }
}
