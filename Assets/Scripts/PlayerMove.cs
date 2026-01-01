using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float h;
    public float v;
    public int maxspeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        rb.AddForce(h * Vector2.right, ForceMode2D.Impulse);
        rb.AddForce(v * Vector2.up, ForceMode2D.Impulse);
        if (rb.linearVelocityX > maxspeed)
        {
            rb.linearVelocityX = maxspeed;
        }
        else if (rb.linearVelocityX < -1*maxspeed)
        {
            rb.linearVelocityX = -1*maxspeed;
        }
        if (h == 0)
        {
            rb.linearVelocityX = 0;
        }
        if (rb.linearVelocityY > maxspeed)
        {
            rb.linearVelocityY = maxspeed;
        }
        else if (rb.linearVelocityY < -1 * maxspeed)
        {
            rb.linearVelocityY = -1 * maxspeed;
        }
        if (v == 0)
        {
            rb.linearVelocityY = 0;
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        for (int i = 1; i <= 16; i++)
        {
            if (other.gameObject.tag == i.ToString())
            {
                StatSystem.playerhp -= 1000;
            }
        }
    }
}
