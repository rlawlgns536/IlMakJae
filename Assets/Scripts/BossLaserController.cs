using UnityEngine;
using System.Collections.Generic;

public class BossLaserController : MonoBehaviour, IBossLaserController
{
    public int maxShieldHp = 10000;

    // 4초마다 호출
    public void ActivateLasersByHp()
    {
        float hpRatio = (float)StatSystem.shieldhp / maxShieldHp;

        int laserCount;

        if (hpRatio > 0.66f)
            laserCount = 4;
        else if (hpRatio > 0.33f)
            laserCount = 8;
        else
            laserCount = 16;

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

        // 2️⃣ 전부 비활성화 (부모 기준)
        foreach (GameObject l in lasers)
        {
            l.transform.parent.gameObject.SetActive(false);
        }

        // 3️⃣ 랜덤으로 N개 선택
        for (int i = 0; i < count; i++)
        {
            int rand = Random.Range(0, lasers.Count);
            GameObject chosen = lasers[rand];
            lasers.RemoveAt(rand);

            chosen.transform.parent.gameObject.SetActive(true);
        }
    }
}
