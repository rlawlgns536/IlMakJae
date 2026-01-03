using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour
{
    [Header("프리팹 설정")]
    public GameObject bulletPrefab;

    [Header("발사 설정")]
    public Vector2 fireDirection = Vector2.right; // 발사 방향 (기본 오른쪽)
    public float fireInterval = 2f;               // 발사 간격 (초)
    public float startDelay = 0f;                 // 첫 발사까지 대기 시간

    void Start()
    {
        // 지정한 위치(현재 오브젝트 좌표)에서 발사 시작
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            SpawnBullet();
            yield return new WaitForSeconds(fireInterval);
        }
    }

    void SpawnBullet()
    {
        if (bulletPrefab != null)
        {
            // 1. 현재 오브젝트의 위치(특정 좌표)에서 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // 2. 총알 스크립트의 Launch 함수 호출
            MovingBullet bulletScript = bullet.GetComponent<MovingBullet>();
            if (bulletScript != null)
            {
                bulletScript.Launch(fireDirection);
            }
        }
    }
}