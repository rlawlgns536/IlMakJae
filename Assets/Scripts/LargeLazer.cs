using UnityEngine;
using System.Collections;

public class BigLaserController : MonoBehaviour
{
    public float interval = 20f;   // 레이저 발사 간격
    public float duration = 5f;    // 레이저 지속 시간

    void Start()
    {
        gameObject.SetActive(false);   // 시작할 때 레이저 꺼둠
        StartCoroutine(LaserRoutine());
    }

    IEnumerator LaserRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            gameObject.SetActive(true);    // 레이저 ON
            yield return new WaitForSeconds(duration);

            gameObject.SetActive(false);   // 레이저 OFF
        }
    }
}
