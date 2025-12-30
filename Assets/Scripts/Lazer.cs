using UnityEngine;

public class Lazer : MonoBehaviour
{
    public Transform target;
    private float tangle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        
        Vector2 dir = target.position - transform.position;
        
        // 각도 계산 (라디안 → 도)
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        
        // Z축 회전만 적용

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
            tangle = angle;
        if (Timer.timesuccess == true)
        {
            transform.localPosition = Vector3.zero;
        }
        else
        {
            transform.localPosition = new Vector3(100, 100, 0);
        }
        
    }
}
