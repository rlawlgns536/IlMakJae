using UnityEngine;
using System.Collections;

public class Lazer1 : MonoBehaviour
{
    public float appearInterval = 1.5f; // 나타나기 전 대기 시간
    public float activeTime = 0.5f;      // 유지 시간

    private SpriteRenderer sr;
    private Collider2D col;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        SetActiveState(false);
    }

    void Start()
    {
        StartCoroutine(BlinkRoutine());
    }

    IEnumerator BlinkRoutine()
    {
        while (true)
        {
            // 대기
            yield return new WaitForSeconds(appearInterval);

            // 나타남
            SetActiveState(true);

            // 유지
            yield return new WaitForSeconds(activeTime);

            // 사라짐
            SetActiveState(false);
        }
    }

    void SetActiveState(bool state)
    {
        if (sr != null) sr.enabled = state;
        if (col != null) col.enabled = state;
    }
}
