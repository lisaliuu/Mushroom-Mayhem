using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_control : MonoBehaviour
{
    camera_controller limit;
    // Health health;

    public float speed = 5f;
    public float jump_speed = 8f;
    private float direction = 0f;
    private Rigidbody2D rb2d;
    public Animator animator;

    public bool is_jumping;

    public Vector3 last_check_point = new Vector3(-12,-2, 0);

    // Start is called before the first frame update
    void Start()
    {
        limit=GameObject.FindWithTag("MainCamera").GetComponent<camera_controller>();
        // health=GameObject.FindWithTag("MainCamera").GetComponent<Health>();

        rb2d = GetComponent<Rigidbody2D>();
        // last_check_point= new Vector3(-12,-2, 0);
    }

    private void Awake(){
        transform.position = last_check_point;
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (direction == 0f) {
            rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
        }
        else if(rb2d.transform.position.x<-20){ 
            rb2d.transform.position=new Vector3(limit.min_limit, rb2d.transform.position.y, rb2d.transform.position.z);
        }
        else{
            rb2d.velocity = new Vector2 (direction * speed, rb2d.velocity.y);
        }


        if (Input.GetButtonDown("Jump") && !is_jumping) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump_speed);
        }
        animator.SetFloat("Speed", Mathf.Abs(direction));

        // if(Health.num_hearts)
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            is_jumping = false;
        }
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            last_check_point = other.transform.position;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            is_jumping = true;
        }
    }
}
