using UnityEngine;

public class JumpGumsa : MonoBehaviour
{
    public static int jumpstate = 0;
    //0 = ¶¥, 1 = Á¡ÇÁ Áß, 2 = º®
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(jumpstate);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (jumpstate == 2)
        {
            rb.gravityScale = 0;
        }
        else if(jumpstate == 0)
        {
            rb.gravityScale = 1;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ddang")
        {
            jumpstate = 0;
            PlayerData.Instance.jumpnum = 0;
        }
        else if (other.gameObject.tag == "Byeok")
        {
            jumpstate = 2;
        }
        else if(other.gameObject.tag == "Hint")
        {
            jumpstate = 0;
        }
        else if (other.gameObject.tag == "Tp")
        {
            jumpstate = 0;
        }
        else if (other.gameObject.tag == "End")
        {
            jumpstate = 0;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ddang")
        {
            jumpstate = 1;
        }
        else if (other.gameObject.tag == "Byeok")
        {
            jumpstate = 1;
        }
    }
}
