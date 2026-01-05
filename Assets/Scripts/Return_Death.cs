// Return_Death.cs
using UnityEngine;

public class Return_Death : MonoBehaviour
{
    // static 제거 → 각 플레이어별로 저장
    public Vector3 respawnPosition = new Vector3(0, 0.5f, 0);

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            JumpGumsa.jumpstate = 0;

            // 플레이어가 사망하면 자신의 respawnPosition으로 이동
            transform.position = respawnPosition;
        }
    }

    // SavePoint에서 호출해서 플레이어의 부활 위치를 업데이트
    public void UpdateRespawnPosition(Vector3 newPos)
    {
        respawnPosition = newPos;
    }
}
