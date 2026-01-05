using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class BossLaserController : MonoBehaviour, IBossLaserController
{
    public int maxShieldHp = 10000;

    private List<Lazer> allLasers = new List<Lazer>();

    void Start()
    {
        // 레이저 전부 수집 (태그 1~16)
        for (int i = 1; i <= 16; i++)
        {
            GameObject obj = GameObject.FindGameObjectWithTag(i.ToString());
            if (obj != null)
            {
                Lazer lz = obj.GetComponent<Lazer>();
                if (lz != null)
                    allLasers.Add(lz);
            }
        }

        // 시작은 무조건 4개
        ActivateRandomLasers(4);
    }

    void Update()
    {
        if (StatSystem.shieldhp <= 0)
        {
            SceneManager.LoadScene("Phase2");
        }
    }

    private int lastLaserCount = -1;

    public void ActivateLasersByHp()
    {
        float hpRatio = (float)StatSystem.shieldhp / maxShieldHp;

        int laserCount;
        if (hpRatio > 0.66f) laserCount = 4;
        else if (hpRatio > 0.33f) laserCount = 8;
        else laserCount = 16;

        // 🔥 같은 개수면 다시 고르지 않음
        if (laserCount == lastLaserCount)
            return;

        lastLaserCount = laserCount;
        ActivateRandomLasers(laserCount);
    }


    void ActivateRandomLasers(int count)
    {
        // 전부 선택 해제
        foreach (var l in allLasers)
            l.SetSelected(false);

        List<Lazer> pool = new List<Lazer>(allLasers);
        List<string> selectedTags = new List<string>();

        for (int i = 0; i < count && pool.Count > 0; i++)
        {
            int rand = Random.Range(0, pool.Count);
            pool[rand].SetSelected(true);
            selectedTags.Add(pool[rand].gameObject.tag); // 선택된 태그 저장
            pool.RemoveAt(rand);
        }

        // 선택된 태그들만 로그로 출력
        Debug.Log("선택된 레이저 태그: " + string.Join(", ", selectedTags));
    }


}
