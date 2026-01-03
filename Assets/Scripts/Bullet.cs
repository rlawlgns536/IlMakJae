using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f;
    public float lifeTime = 3f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    // 플레이어 스크립트에서 방향을 받아와 실행
    public void Setup(Vector2 direction, float speed)
    {
        rb.linearVelocity = direction * speed;

        // 총알이 날아가는 방향을 바라보게 회전
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Boss>()?.TakeDamage(damage);
            Destroy(gameObject); // 관통 방지
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Minion>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}