using UnityEngine;

public class Hint : MonoBehaviour
{
    public int hintID;
    private bool isCollected = false; // 각 힌트 독립 상태
    private Vector3 originalPosition;

    void Awake()
    {
        originalPosition = transform.position;
    }

    void Start()
    {
        // 이미 획득한 힌트면 이동
        if (PlayerData.Instance.collectedHintIDs.Contains(hintID))
        {
            isCollected = true;
            MoveAway();
        }
        else
        {
            transform.position = originalPosition;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player") || isCollected) return;

        isCollected = true;
        PlayerData.Instance.collectedHintIDs.Add(hintID); // 공유 컬렉션에 기록
        MoveAway();
    }

    void MoveAway()
    {
        transform.position = new Vector3(1000, 0, 0); // 다른 힌트에는 영향 없음
    }
}
