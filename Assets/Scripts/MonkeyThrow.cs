using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonkeyThrow : MonoBehaviour
{
    public GameObject bananaPrefab;
    public GameObject bombPrefab;
    public Transform throwPoint;

    public float throwForce = 7f;
    public float throwInterval = 5f;
    public int poolSize = 5;

    private bool throwBanana = true;

    private List<GameObject> bananaPool = new List<GameObject>();
    private List<GameObject> bombPool = new List<GameObject>();

    void Start()
    {
        CreatePool(bananaPrefab, bananaPool);
        CreatePool(bombPrefab, bombPool);

        StartCoroutine(ThrowRoutine());
    }

    void CreatePool(GameObject prefab, List<GameObject> pool)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, throwPoint.position, Quaternion.identity);

            // SpriteRenderer와 Collider만 비활성화
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            if (sr != null) sr.enabled = false;

            Collider2D col = obj.GetComponent<Collider2D>();
            if (col != null) col.enabled = false;

            pool.Add(obj);
        }
    }

    IEnumerator ThrowRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(throwInterval);

            if (throwBanana)
                ThrowFromPool(bananaPool);
            else
                ThrowFromPool(bombPool);

            throwBanana = !throwBanana;
        }
    }

    void ThrowFromPool(List<GameObject> pool)
    {
        GameObject obj = pool.Find(o =>
        {
            SpriteRenderer sr = o.GetComponent<SpriteRenderer>();
            return sr != null && !sr.enabled; // 렌더러 꺼진 것만 사용
        });

        if (obj == null)
        {
            Debug.LogWarning("사용 가능한 오브젝트가 없습니다!");
            return;
        }

        // 위치 초기화
        obj.transform.position = throwPoint.position;
        obj.transform.rotation = Quaternion.identity;

        // SpriteRenderer, Collider 켜기
        SpriteRenderer srObj = obj.GetComponent<SpriteRenderer>();
        if (srObj != null) srObj.enabled = true;

        Collider2D colObj = obj.GetComponent<Collider2D>();
        if (colObj != null) colObj.enabled = true;

        // Rigidbody 초기화 및 힘 주기
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Vector2 dir = (player.transform.position - throwPoint.position).normalized;
                rb.AddForce(dir * throwForce, ForceMode2D.Impulse);
            }
        }

        // 일정 시간 후 다시 렌더러와 콜라이더 끄기
        StartCoroutine(DeactivateRendererCollider(obj, 5f));
    }

    IEnumerator DeactivateRendererCollider(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);

        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if (sr != null) sr.enabled = false;

        Collider2D col = obj.GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        // Rigidbody 초기화
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
