using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    [Header("능력치")]
    public float maxHp = 100f;
    public float currentHp;
    public float moveSpeed = 2.0f;

    [Header("소환 설정")]
    public GameObject minionPrefab;
    public Transform target;

    private bool isStunned = false;
    private bool spawned100 = false;
    private bool spawned50 = false;
    private bool spawned20 = false;

    void Start()
    {
        currentHp = maxHp;
        // 플레이어 찾기
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) target = player.transform;
        }
        CheckSummon();
    }

    void Update()
    {
        if (!isStunned && target != null)
        {
            // 2D 이동 및 Z축 고정
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, 0);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            // 좌우 시선 반전
            if (target.position.x < transform.position.x)
                transform.localScale = new Vector3(-1, 1, 1);
            else
                transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHp -= amount;
        Debug.Log($"보스 HP: {currentHp}");
        CheckSummon();

        if (currentHp <= 0)
        {
            Debug.Log("보스 사망");
            Destroy(gameObject);
        }
    }

    private void CheckSummon()
    {
        float hpPercent = (currentHp / maxHp) * 100f;

        if (!spawned100 && hpPercent <= 100f) { StartCoroutine(SummonRoutine()); spawned100 = true; }
        else if (!spawned50 && hpPercent <= 50f) { StartCoroutine(SummonRoutine()); spawned50 = true; }
        else if (!spawned20 && hpPercent <= 20f) { StartCoroutine(SummonRoutine()); spawned20 = true; }
    }

    IEnumerator SummonRoutine()
    {
        isStunned = true; // 소환 중 2초 멈춤
        Debug.Log("보스 소환 중... (2초 정지)");

        for (int i = 0; i < 3; i++)
        {
            if (minionPrefab != null)
            {
                Vector3 spawnPos = transform.position + new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f), 0);
                Instantiate(minionPrefab, spawnPos, Quaternion.identity);
            }
        }

        yield return new WaitForSeconds(2.0f);
        isStunned = false;
    }
}