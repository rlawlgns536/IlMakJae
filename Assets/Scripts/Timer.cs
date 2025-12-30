using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float timer;  // 타이머
    public static float TargetTime = 4f;  // 목표 시간
    public static bool timesuccess;  // 시간 성공 여부

    private float timeAfterSuccess;  // timesuccess가 true일 때의 시간 추적 변수

    void Start()
    {
        timeAfterSuccess = 0f;
    }

    void Update()
    {
        // 타이머가 목표 시간을 지나면 timesuccess를 true로 설정하고 0.5초를 기다림
        if (timer < TargetTime + 0.5f && timer < TargetTime)
        {
            timer += Time.deltaTime;
            timesuccess = false;
            timeAfterSuccess = 0f;  // timesuccess가 false일 때 시간 추적 초기화
        }
        else if (timer >= TargetTime && timeAfterSuccess < 0.5f)
        {
            // 목표 시간 4초가 지나면 timesuccess를 true로 설정
            timesuccess = true;
            timeAfterSuccess += Time.deltaTime;  // timeAfterSuccess를 증가시킴
        }
        else if (timeAfterSuccess >= 0.5f)
        {
            // 0.5초가 지나면 timesuccess를 false로 설정
            timesuccess = false;
            timer = 0;  // 타이머 리셋
        }
    }
}
