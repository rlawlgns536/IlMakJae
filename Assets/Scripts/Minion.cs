using UnityEngine;

public class Minion : MonoBehaviour
{
    public float hp = 10f;
    public float moveSpeed = 3f;
    public float lifeSpan = 60f; // 1분 유지 설정
    private Transform target;

    void Start()
    {
        // 60초 뒤 파괴 예약
        Destroy(gameObject, lifeSpan);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) target = player.transform;
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(target.position.x < transform.position.x ? -1 : 1, 1, 1);
        }
    }

    public void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0) Destroy(gameObject);
    }
}