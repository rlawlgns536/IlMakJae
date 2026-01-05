using UnityEngine;

public class Lazer : MonoBehaviour
{
    public Transform target;

    private float lastAngle;
    private Vector3 originalPosition;
    private Renderer rend;
    private Collider2D col;

    private bool isSelected = false;
    private static bool totalDamageApplied = false; // ?? 전체 레이저 합쳐서 1회만

    void Awake()
    {
        originalPosition = transform.position;
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider2D>();

        rend.enabled = false;
        col.enabled = false;
    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;

        if (!selected)
        {
            rend.enabled = false;
            col.enabled = false;
        }
        else
        {
            // 새로 선택되면 발사 데미지 가능
            totalDamageApplied = false;
        }
    }

    public bool IsSelected()
    {
        return isSelected;
    }

    void Update()
    {
        if (!isSelected || target == null) return;

        // 3.5초 전: 추적 경고
        if (!Timer.timesuccess && Timer.timer < 3.5f)
        {
            Vector2 dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            lastAngle = angle;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            rend.enabled = false;
            col.enabled = false;
        }
        // 3.5초 이후: 각도 고정
        else if (!Timer.timesuccess && Timer.timer >= 3.5f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, lastAngle);
            rend.enabled = false;
            col.enabled = false;
        }
        // 발사
        else if (Timer.timesuccess)
        {
            transform.position = originalPosition;
            transform.rotation = Quaternion.Euler(0f, 0f, lastAngle);

            rend.enabled = true;
            col.enabled = true;

            // ?? 총합 500 데미지 1회만
            if (!totalDamageApplied)
            {
                if (StatSystem.shieldhp > 0)
                {
                    StatSystem.shieldhp -= 500;
                    if (StatSystem.shieldhp < 0) StatSystem.shieldhp = 0;
                }
                else
                {
                    StatSystem.bosshp -= 500;
                    if (StatSystem.bosshp < 0) StatSystem.bosshp = 0;
                }

                totalDamageApplied = true;
                Parry.Parried = false;
                Debug.Log($"총합 500 데미지 적용 | shield={StatSystem.shieldhp}, boss={StatSystem.bosshp}");
            }
        }
    }

    // ?? Parry에서 새 선택 시 데미지 초기화
    public static void ResetDamageFlag()
    {
        totalDamageApplied = false;
    }
}
