using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    GameObject obj;
    public static int hint = 0;
    private Rigidbody2D rb;
    public float jumppower = 3f;
    public static int jumpnum = 0;
    public int jumps = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public float Pspeed = 0.02f;
    public float Uspeed = 0.005f;
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (TP.tp == 1)
        {
            transform.position = new Vector3(-36.5f, 12f, 0f);
            TP.tp = 0;
            rb.gravityScale = 3;
        }
        rb.freezeRotation = true;
        if (JumpGumsa.jumpstate == 0 || JumpGumsa.jumpstate == 2)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Pspeed, 0, 0);

            }
            else if (Input.GetKey(KeyCode.A))
            { 
                transform.Translate(-Pspeed, 0, 0);
            }
            else if (JumpGumsa.jumpstate == 0 && Input.GetKeyDown(KeyCode.Space) && jumpnum == 0)
            {
                rb.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
                Debug.Log("111");
                jumpnum = 1;
            }
            if (Input.GetKey(KeyCode.W) && JumpGumsa.jumpstate == 2)
            {
                transform.Translate(0, Uspeed, 0);
                Debug.Log("w");
            }
            else if (Input.GetKey(KeyCode.S) && JumpGumsa.jumpstate == 2)
            {
                transform.Translate(0, -Uspeed, 0);
                Debug.Log("s");
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>(); 
        if (other.gameObject.tag == "Ddang")
        {
            jumpnum = 0;
        }
        if (other.gameObject.tag == "Byeok")
        {
            rb.gravityScale = 0;
            jumps = 2;
            Debug.Log(jumps);
        }
        else
        {
            jumps = 0;
        }
    }
}