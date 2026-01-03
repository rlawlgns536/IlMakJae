using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float timer;
    public static float TargetTime = 4f;
    public static bool timesuccess;

    private IBossLaserController[] controllers;

    void Start()
    {
        timer = 0f;
        timesuccess = false;
        controllers = GetComponents<IBossLaserController>();

        Debug.Log("레이저 컨트롤러 수: " + controllers.Length);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!timesuccess && timer >= TargetTime)
        {
            timesuccess = true;

            foreach (var c in controllers)
            {
                c.ActivateLasersByHp();
            }
        }

        // 쿨타임 초기화
        if (timesuccess && timer >= TargetTime + 0.5f)
        {
            timer = 0f;
            timesuccess = false;
        }
    }
}
