using UnityEngine;
using System.Collections.Generic;

public class BossLaserController1 : MonoBehaviour, IBossLaserController
{
    public int maxShieldHp = 10000;

    // 4초마다 호출
    public void ActivateLasersByHp()
    {
        float hpRatio = (float)StatSystem.shieldhp / maxShieldHp;

        int laserCount = 16;
        ActivateRandomLasers(laserCount);
    }

    void ActivateRandomLasers(int count)
    {
        // 1️⃣ 태그 1~16 레이저 전부 찾기
        List<GameObject> lasers = new List<GameObject>();

        for (int i = 1; i <= 16; i++)
        {
            GameObject laser = GameObject.FindGameObjectWithTag(i.ToString());
            if (laser != null)
                lasers.Add(laser);
        }

        // 🔴 보호 코드 (1번 수정)
        if (lasers.Count == 0)
            return;

        count = Mathf.Min(count, lasers.Count);

        // 2️⃣ 전부 비활성화 (부모 ❌, 자기 자신만)
        foreach (GameObject l in lasers)
        {
            l.SetActive(false);
        }

        // 3️⃣ 랜덤으로 N개 선택
        for (int i = 0; i < count; i++)
        {
            int rand = Random.Range(0, lasers.Count);
            GameObject chosen = lasers[rand];
            lasers.RemoveAt(rand);

            chosen.SetActive(true);
        }
    }
}
