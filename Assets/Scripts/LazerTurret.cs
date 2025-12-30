using UnityEngine;

public class LazerTurret : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target == null) return;

        Vector2 dir = target.position - transform.position;

        // 각도 계산 (라디안 → 도)
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // Z축 회전만 적용
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
