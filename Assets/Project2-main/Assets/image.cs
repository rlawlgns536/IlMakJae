using UnityEngine;
using System.Collections; // 코루틴을 쓰기 위해 필요합니다

public class TemporaryDeactivate : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D col;

    private void Awake()
    {
        // 오브젝트에 붙어있는 그림(Sprite)과 충돌체(Collider) 컴포넌트를 가져옵니다.
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어와 닿았는지 확인
        if (other.CompareTag("Player"))
        {
            // 코루틴 시작 (1초 뒤에 다시 켜짐)
            StartCoroutine(DisableForSeconds(0.5f));
        }
    }

    // 시간차를 두고 실행되는 함수
    private IEnumerator DisableForSeconds(float duration)
    {
        // 1. 모습과 충돌을 끕니다 (마치 사라진 것처럼 보임)
        spriteRenderer.enabled = false;
        col.enabled = false;

        // 2. 지정된 시간(초) 만큼 대기합니다
        yield return new WaitForSeconds(duration);

        // 3. 다시 켭니다 (다시 나타남)
        spriteRenderer.enabled = true;
        col.enabled = true;
    }
}