using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove_TopDown : MonoBehaviour
{
    [Header("이동")]
    public float moveSpeed = 5f;

    [Header("체력 / 무적")]
    public int health = 3;
    public float invincibilityDuration = 1f;
    private bool isInvincible;

    [Header("발사")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float shootOffset = 0.7f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 moveInput;
    private Vector2 lastDir = Vector2.right;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (moveInput != Vector2.zero)
            lastDir = moveInput.normalized;

        if (Input.GetKeyDown(KeyCode.J))
            Shoot();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        if (!bulletPrefab) return;

        Vector3 pos = transform.position + (Vector3)lastDir * shootOffset;
        GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);

        Bullet b = bullet.GetComponent<Bullet>();
        if (b) b.Setup(lastDir, bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack") && !isInvincible)
            TakeDamage(1);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        for (int i = 1; i <= 16; i++)
        {
            if (other.gameObject.CompareTag(i.ToString()) && !isInvincible)
            {
                TakeDamage(1);
                break;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if ((other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss")) && !isInvincible)
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int dmg)
    {
        if (isInvincible) return;

        health -= dmg;
        Debug.Log("HP: " + health);

        if (health <= 0)
            Die();
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

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
