using UnityEngine;

public class MovingBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // 발사기에서 방향을 정해줄 함수
    public void Launch(Vector2 direction)
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction.normalized * speed;

        // 방향에 맞춰 총알 회전 (선택 사항)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}