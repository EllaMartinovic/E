using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerjump : MonoBehaviour
{
    public float speed = 12f;
    public float speedjump = 500f;
    public bool jump = false;
    Vector2 maxVelocity = new Vector2(5, 5);
    private Animator animator;
    public Rigidbody2D rb;
    private SpriteRenderer _spriterenderer;
    public GameObject Bullet;
    public bool isRight =true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("gameover");
        }
    }
    private void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        float forceX = 0f;
        float forceY = 0f;
        var absVelX = Mathf.Abs(rb.velocity.x);
       
      
        if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = false;
           
         
            if(absVelX<maxVelocity.x)
            {
                forceX = -speed;
            }
        }
        else if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;
           
            if (absVelX < maxVelocity.x)
            {
                forceX = speed;
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
         
        }
        if(Input.GetKey(KeyCode.Space))
        {
     
            if (!jump)
            {
                forceY = speedjump;
                jump = true;
                
            }
        }
        Vector2 v2 = new Vector2(forceX, forceY);
        rb.AddForce(v2);

      
    }
}
