using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovement", menuName = "Scriptable Objects/PlayerMovement")]

public class PlayerMovement : MonoBehaviour
{
    [Header("설정")]
    public float moveSpeed = 5f;
    public bool canMove = true; // 이동 가능 여부 (외부에서 제어 가능)

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 이동 불가능 상태면 입력 무시
        if (!canMove)
        {
            movement = Vector2.zero; // 입력값 초기화
            return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        CheckBoundary();
    }

    void FixedUpdate()
    {
        // 이동 불가능 상태면 물리 이동도 멈춤
        if (!canMove)
        {
            // 6.0버전: rb.linearVelocity = Vector2.zero; 
            // 구버전: rb.velocity = Vector2.zero;
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void CheckBoundary()
    {
        float currentX = transform.position.x;
        float currentY = transform.position.y;

        if (currentX < -10.5f || currentX > 11.5f || currentY < -4.2f || currentY > 4.2f)
        {
            transform.position = new Vector3(-9f, 0f, 0f);
            rb.linearVelocity = Vector2.zero;
        }
    }
}