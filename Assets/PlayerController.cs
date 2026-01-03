using UnityEngine;
using TMPro; // 텍스트 표시를 위해 필요

public class PlayerController : MonoBehaviour
{
    [Header("설정")]
    public float moveSpeed = 5f;
    public int maxHealth = 3;
    public TextMeshProUGUI healthText; // 체력을 표시할 UI 텍스트 연결

    private int currentHealth;
    private SpriteRenderer spriteRenderer;
    private Camera mainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main;

        spriteRenderer.color = Color.white;
        UpdateHealthUI(); // 시작 시 체력 표시

        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        objectWidth = spriteRenderer.bounds.extents.x;
        objectHeight = spriteRenderer.bounds.extents.y;
    }

    private void Update()
    {
        // 게임 오버 상태면 움직이지 않음
        if (GameManager.Instance.IsGameOver) return;

        Move();
        KeepInBounds();
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    private void KeepInBounds()
    {
        Vector3 viewPos = transform.position;
        if (viewPos.x < -screenBounds.x + objectWidth) viewPos.x = -screenBounds.x + objectWidth + 0.1f;
        if (viewPos.x > screenBounds.x - objectWidth) viewPos.x = screenBounds.x - objectWidth - 0.1f;
        if (viewPos.y < -screenBounds.y + objectHeight) viewPos.y = -screenBounds.y + objectHeight + 0.1f;
        if (viewPos.y > screenBounds.y - objectHeight) viewPos.y = screenBounds.y - objectHeight - 0.1f;
        transform.position = viewPos;
    }

    // 외부(기둥)에서 호출할 함수
    public void TakeDamage()
    {
        if (GameManager.Instance.IsGameOver) return;

        currentHealth--;
        Debug.Log($"플레이어 피격! 남은 체력: {currentHealth}");
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = $"HP : {currentHealth} / {maxHealth}";
        }
    }

    private void Die()
    {
        // 체력이 0이 되면 게임 매니저에게 실패 알림
        GameManager.Instance.GameOver();

        // 플레이어 모습 숨기기
        gameObject.SetActive(false);
    }
}

