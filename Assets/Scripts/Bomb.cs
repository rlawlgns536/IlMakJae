using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public float explodeDelay = 2f;
    public float bounceForce = 8f;
    private bool bounced = false;

    void Start()
    {
        StartCoroutine(ExplodeTimer());
    }

    IEnumerator ExplodeTimer()
    {
        yield return new WaitForSeconds(explodeDelay);

        if (!bounced)
        {
            Explode();
        }
    }

    void Explode()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1.2f);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                PlayerHP hp = hit.GetComponent<PlayerHP>();
                if (hp != null)
                {
                    hp.TakeDamage();
                }
            }
        }

        Destroy(gameObject);
    }


    public void Bounce(Vector2 dir)
    {
        bounced = true;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(dir * bounceForce, ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (bounced && collision.gameObject.CompareTag("Boss"))
        {
            MonkeyBoss boss = collision.gameObject.GetComponent<MonkeyBoss>();
            if (boss != null)
            {
                boss.HitByBomb();
            }

            Destroy(gameObject);
        }
    }

}
