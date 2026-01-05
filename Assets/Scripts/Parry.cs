using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    public float eCooldown = 4f;
    private float eTimer = 0f;
    public static bool Parried = false;
    void Update()
    {
        if (eTimer > 0) eTimer -= Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.E) && eTimer <= 0f)
        {
            ParryLaser();
            eTimer = eCooldown;
        }
    }

    void ParryLaser()
    {
        Lazer[] lasers = FindObjectsByType<Lazer>(FindObjectsSortMode.None);
        if (lasers.Length == 0) return;

        // 1️⃣ 레이저 갯수 결정
        int laserCount;
        float hpRatio = (float)StatSystem.shieldhp / 10000f;
        if (hpRatio > 0.66f) laserCount = 4;
        else if (hpRatio > 0.33f) laserCount = 8;
        else laserCount = 16;

        // 2️⃣ 모든 레이저 선택 해제
        foreach (var l in lasers)
            l.SetSelected(false);

        // 🔹 총합 데미지 초기화
        Lazer.ResetDamageFlag();

        // 3️⃣ 랜덤으로 N개 선택
        List<Lazer> laserList = new List<Lazer>(lasers);
        for (int i = 0; i < laserCount && laserList.Count > 0; i++)
        {
            int idx = Random.Range(0, laserList.Count);
            laserList[idx].SetSelected(true);
            laserList.RemoveAt(idx);
        }
        Parried = true;
        Debug.Log($"Parry 완료 | 선택된 레이저 수: {laserCount}");
    }
}
