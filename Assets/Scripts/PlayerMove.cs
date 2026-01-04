using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove_Physics : MonoBehaviour
{
    [Header("이동")]
    public float movePower = 5f;
    public float maxSpeed = 7f;

    [Header("체력 / 무적")]
    public int health = 3;
    public float invincibilityDuration = 1f;
    private bool isInvincible;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rb.AddForce(new Vector2(h, v) * movePower, ForceMode2D.Impulse);

        rb.linearVelocity = new Vector2(
            Mathf.Clamp(rb.linearVelocityX, -maxSpeed, maxSpeed),
            Mathf.Clamp(rb.linearVelocityY, -maxSpeed, maxSpeed)
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack") && !isInvincible)
            TakeDamage(1);
    }

    void TakeDamage(int dmg)
    {
        if (isInvincible) return;

        health -= dmg;

        if (health <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
            StartCoroutine(InvincibleRoutine());
    }

    IEnumerator InvincibleRoutine()
    {
        isInvincible = true;

        float t = 0;
        while (t < invincibilityDuration)
        {
            sr.color = new Color(1, 1, 1, 0.4f);
            yield return new WaitForSeconds(0.1f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            t += 0.2f;
        }

        isInvincible = false;
    }
}
