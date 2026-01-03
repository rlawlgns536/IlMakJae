using UnityEngine;

public class Pillar : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Destroy(gameObject, 2.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 대상이 "Player" 태그를 가지고 있는지 확인
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(); // 플레이어에게 데미지 전달
                Destroy(gameObject); // 기둥 삭제
            }
        }
    }
}