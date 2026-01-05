using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    [Header("폭발 설정")]
    public float explodeDelay = 2f;   // 폭발까지 시간
    public float bounceForce = 8f;    // 바운스 힘
    private bool bounced = false;

    private SpriteRenderer sr;
    private Collider2D col;
    private Rigidbody2D rb;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        bounced = false;
        if (sr != null) sr.enabled = true;
        if (col != null) col.enabled = true;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

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
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 3f);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                PlayerHP hp = hit.GetComponent<PlayerHP>();
                if (hp != null)
                    hp.TakeDamage();
            }

            if (hit.CompareTag("Boss"))
            {
                MonkeyBoss boss = hit.GetComponent<MonkeyBoss>();
                if (boss != null)
                    boss.HitByBomb();
            }
        }

        StartCoroutine(DeactivateBomb());
    }

    IEnumerator DeactivateBomb()
    {
        if (sr != null) sr.enabled = false;
        if (col != null) col.enabled = false;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        yield return null;
    }

    public void Bounce(Vector2 dir)
    {
        bounced = true;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(dir * bounceForce, ForceMode2D.Impulse);
        }
    }

    public void ActivateBomb(Vector2 spawnPos)
    {
        transform.position = spawnPos;

        if (sr != null) sr.enabled = true;
        if (col != null) col.enabled = true;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        bounced = false;
        gameObject.SetActive(true);
        StartCoroutine(ExplodeTimer());
    }
}
