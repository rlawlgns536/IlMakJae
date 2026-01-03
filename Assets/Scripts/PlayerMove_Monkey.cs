using UnityEngine;
using System.Collections;

public class PlayerMove_Monkey : MonoBehaviour
{
    public int maxspeed = 3;   // X축 최대 속도
    public int maxspeed2 = 3;  // Y축 최대 속도

    public float h;
    public float v;

    Rigidbody2D rb;

    private int originMaxSpeed;
    private int originMaxSpeed2;
    private bool isSlipping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        originMaxSpeed = maxspeed;
        originMaxSpeed2 = maxspeed2;
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        rb.AddForce(h * Vector2.right, ForceMode2D.Impulse);
        rb.AddForce(v * Vector2.up, ForceMode2D.Impulse);

        // X축 속도 제한
        if (rb.linearVelocityX > maxspeed)
            rb.linearVelocityX = maxspeed;
        else if (rb.linearVelocityX < -maxspeed)
            rb.linearVelocityX = -maxspeed;

        if (h == 0)
            rb.linearVelocityX = 0;

        // Y축 속도 제한
        if (rb.linearVelocityY > maxspeed2)
            rb.linearVelocityY = maxspeed2;
        else if (rb.linearVelocityY < -maxspeed2)
            rb.linearVelocityY = -maxspeed2;

        if (v == 0)
            rb.linearVelocityY = 0;
        if (Input.GetKeyDown(KeyCode.E))
        {
            BounceBomb();
        }
    }

    // ?? 바나나 미끄러짐 처리
    public void Slip(float rate, float duration)
    {
        if (!isSlipping)
            StartCoroutine(SlipCoroutine(rate, duration));
    }

    IEnumerator SlipCoroutine(float rate, float duration)
    {
        isSlipping = true;

        // 최소 1 보장
        maxspeed = Mathf.Max(1, Mathf.RoundToInt(originMaxSpeed * rate));
        maxspeed2 = Mathf.Max(1, Mathf.RoundToInt(originMaxSpeed2 * rate));

        // 미끄러지는 관성
        rb.linearVelocity *= 1.3f;

        yield return new WaitForSeconds(duration);

        maxspeed = originMaxSpeed;
        maxspeed2 = originMaxSpeed2;
        isSlipping = false;
    }
    void BounceBomb()
    {
        Collider2D[] bombs = Physics2D.OverlapCircleAll(transform.position, 1.2f);

        foreach (Collider2D col in bombs)
        {
            if (col.CompareTag("Bomb"))
            {
                Bomb bomb = col.GetComponent<Bomb>();
                if (bomb != null)
                {
                    Vector2 dir = (col.transform.position - transform.position).normalized;
                    bomb.Bounce(dir);
                }
            }
        }
    }

}
