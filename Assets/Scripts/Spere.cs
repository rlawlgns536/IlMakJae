using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerQSkill : MonoBehaviour
{
    public float range = 20f;
    public int damage = 1000;
    public int needParry = 0;

    public float qCooldown = 4f;  // 쿨타임 4초
    private float qTimer = 0f;    // 남은 쿨타임


    void Update()
    {
        if (StatSystem.bosshp <= 0)
        {
            SceneManager.LoadScene("1Stage");
        }
        // ⏳ 쿨타임 감소
        if (qTimer > 0f)
            qTimer -= Time.deltaTime;

        // Q 입력 감지
        if (Input.GetKeyDown(KeyCode.Q) && qTimer <= 0f)
        {
            // needParry 체크 (0이면 무시)
            if (needParry > 0 && StatSystem.parryCount < needParry)
                return;

            // 🔹 QSkill 실행
            UseQSkill();

            // ✅ 쿨타임 리셋
            qTimer = qCooldown;
        }
    }

    void UseQSkill()
    {
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");
        if (bosses.Length == 0) return;

        bool hitAny = false;

        foreach (GameObject boss in bosses)
        {
            // Vector3로 그냥 계산 (Z축 무시)
            float dist = Vector3.Distance(transform.position, boss.transform.position);

            if (dist <= range)
            {
                // 🔹 체력 감소 (한 번만)
                int actualDamage = Mathf.Min(damage, StatSystem.shieldhp > 0 ? StatSystem.shieldhp : StatSystem.bosshp);

                if (StatSystem.shieldhp > 0)
                    StatSystem.shieldhp -= actualDamage;
                else
                    StatSystem.bosshp -= actualDamage;

                // 패링 카운트 초기화
                StatSystem.parryCount = 0;

                Debug.Log($"QSkill 사용 | shield={StatSystem.shieldhp}, boss={StatSystem.bosshp}");

                hitAny = true;
                break; // 한 번만 적용
            }
        }

        if (!hitAny)
            Debug.Log("QSkill 범위 내에 보스 없음");
    }
}
