using UnityEngine;

public class PlayerQSkill : MonoBehaviour
{
    public float range = 5f;
    public int damage = 1000;
    public int needParry = 5;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // ❌ 패링 횟수 부족하면 사용 불가
            if (StatSystem.parryCount < needParry)
                return;

            UseQSkill();
        }
    }

    void UseQSkill()
    {
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");

        foreach (GameObject boss in bosses)
        {
            float dist = Vector3.Distance(transform.position, boss.transform.position);

            if (dist <= range)
            {
                if (StatSystem.shieldhp > 0)
                {
                    StatSystem.shieldhp -= damage;
                    if (StatSystem.shieldhp < 0)
                        StatSystem.shieldhp = 0;
                }
                else
                {
                    StatSystem.bosshp -= damage;
                    if (StatSystem.bosshp < 0)
                        StatSystem.bosshp = 0;
                }

                // ✅ 스피어 사용 성공 → 패링 카운트 소모
                StatSystem.parryCount = 0;

                break;
            }
        }
    }
}
