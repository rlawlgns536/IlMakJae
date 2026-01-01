using UnityEngine;

public class Lazer : MonoBehaviour
{
    public Transform target;

    private float lastAngle;
    private Vector3 originalPosition;

    private Renderer rend;
    private Collider2D col;

    private bool angleLocked = false; // ★ 각도 고정 여부

    void Start()
    {
        originalPosition = transform.position;
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (target == null) return;

        // ?? 3.5초 전까지만 추적
        if (!Timer.timesuccess && Timer.timer < 3.5f)
        {
            Vector2 dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            lastAngle = angle;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            angleLocked = false;
            rend.enabled = false;
            col.enabled = false;
        }
        // ?? 3.5초 이후: 각도 고정 (추적 중단)
        else if (!Timer.timesuccess && Timer.timer >= 3.5f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, lastAngle);

            angleLocked = true;
            rend.enabled = false;
            col.enabled = false;
        }
        // ?? 발사
        else if (Timer.timesuccess)
        {
            transform.position = originalPosition;
            transform.rotation = Quaternion.Euler(0f, 0f, lastAngle);

            rend.enabled = true;
            col.enabled = true;
        }
    }
}
