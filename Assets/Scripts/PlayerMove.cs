using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.SceneManagement;
public class PlayerMove_Physcis : MonoBehaviour 
{ 
    GameObject obj; 
    public static int hint = 0; 
    private Rigidbody2D rb; 
    public float jumppower = 3f; 
    public static int jumpnum = 0; 
    public int jumps = 0;
    public float maxspeed; 
    public float maxspeed2; 
    void Start() 
    { 
        rb = GetComponent<Rigidbody2D>();
    }
    public float Pspeed = 0.02f;
    public float Uspeed = 0.005f;
    public float h; 
    public float v; 
    void Update() 
    { 
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical"); 
        rb.AddForce(h * Vector2.right, ForceMode2D.Impulse);
        if (JumpGumsa.jumpstate == 2)
        {
            rb.AddForce(v * Vector2.up, ForceMode2D.Impulse);
        }
        if (rb.linearVelocityX > maxspeed)
        { 
            rb.linearVelocityX = maxspeed;
        } 
        else if (rb.linearVelocityX < -maxspeed)
        { 
            rb.linearVelocityX = -maxspeed; 
        } 
        else if (h == 0) 
        {
            rb.linearVelocityX = 0;
        } 
        if (rb.linearVelocityY > maxspeed2)
        { 
            rb.linearVelocityY = maxspeed2; 
        }
        else if (rb.linearVelocityY < -maxspeed2) 
        { 
            rb.linearVelocityY = -maxspeed2;
        } 
        if (TP.tp == 1) 
        { 
            transform.position = new Vector3(-36.5f, 12f, 0f); 
            TP.tp = 0;
            rb.gravityScale = 3; 
        } 
        rb.freezeRotation = true; 
        if (JumpGumsa.jumpstate == 0 || JumpGumsa.jumpstate == 2)
        { 
            if (JumpGumsa.jumpstate == 0 && Input.GetKeyDown(KeyCode.Space) && PlayerData.Instance.jumpnum == 0) 
            {
                rb.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse); 
                Debug.Log("111"); 
                PlayerData.Instance.jumpnum = 1; 
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other) 
    { 
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
        else { 
            jumps = 0;
        }
    }
}
