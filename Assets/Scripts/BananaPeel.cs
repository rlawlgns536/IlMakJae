using UnityEngine;
using System.Collections;

public class BananaPeel : MonoBehaviour
{
    public float disappearTime = 20f;
    public float slowRate = 0.7f;    // 30% 감소
    public float slowDuration = 3f;  // 3초 지속

    private SpriteRenderer sr;
    private Collider2D col;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    void Start()
    {
        StartCoroutine(AutoDeactivate(disappearTime));
    }

    private IEnumerator AutoDeactivate(float delay)
    {
        yield return new WaitForSeconds(delay);
        Deactivate();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMove_Monkey player = other.GetComponent<PlayerMove_Monkey>();
            if (player != null)
            {
                player.Slip(slowRate, slowDuration);
            }

            Deactivate();
        }
    }

    // Destroy 대신 렌더러와 콜라이더만 끄기
    private void Deactivate()
    {
        if (sr != null) sr.enabled = false;
        if (col != null) col.enabled = false;
    }

    // 다시 사용할 때 렌더러와 콜라이더 켜기
    public void Activate()
    {
        if (sr != null) sr.enabled = true;
        if (col != null) col.enabled = true;
    }
}
