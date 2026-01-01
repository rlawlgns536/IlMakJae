using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float timer;
    public static float TargetTime = 4f;
    public static bool timesuccess;

    private float timeAfterSuccess;

    public BossLaserController bossLaserController; // ★ 추가

    void Start()
    {
        timer = 0f;
        timeAfterSuccess = 0f;
        timesuccess = false;
    }

    void Update()
    {
        if (timer < TargetTime)
        {
            timer += Time.deltaTime;
            timesuccess = false;
            timeAfterSuccess = 0f;
        }
        else if (timer >= TargetTime && timeAfterSuccess < 0.5f)
        {
            if (!timesuccess) // ★ 딱 1번만 호출
            {
                bossLaserController.ActivateLasersByHp();
            }

            timesuccess = true;
            timeAfterSuccess += Time.deltaTime;
        }
        else
        {
            timesuccess = false;
            timer = 0f;
        }
    }
}
