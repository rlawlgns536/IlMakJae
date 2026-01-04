using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "B", menuName = "Scriptable Objects/B")]

public class DamageZone : MonoBehaviour
{
    [Header("색상 설정")]
    public Color normalColor = Color.blue;
    public Color hitColor = Color.red;
    public float delayTime = 0.4f; // 멈춰있는 시간 (0.5초)

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null) spriteRenderer.color = normalColor;
    }

    // 다시 OnTriggerEnter2D 사용 ("밟으면" = 겹치면)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 코루틴 시작 (멈추고 -> 기다렸다가 -> 이동하는 로직)
            StartCoroutine(HitSequence(other.gameObject));
        }
    }

    // 충돌 처리 시퀀스
    IEnumerator HitSequence(GameObject player)
    {
        PlayerMovement playerScript = player.GetComponent<PlayerMovement>();
        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();

        // 1. 플레이어 조작 비활성화 & 멈춤
        if (playerScript != null) playerScript.canMove = false;
        if (playerRb != null) playerRb.linearVelocity = Vector2.zero;

        // 3. 지정된 시간만큼 대기 (이때 플레이어는 멈춰있고, B는 빨간색)
        yield return new WaitForSeconds(delayTime);


        // 4. 플레이어 위치 리셋 (-11, 0)
        player.transform.position = new Vector3(-9f, 0f, 0f);
        if (playerRb != null) playerRb.linearVelocity = Vector2.zero; // 이동 후 속도 제거

        // 5. 색상 복구 및 플레이어 조작 재개
        if (playerScript != null) playerScript.canMove = true;
    }
}
