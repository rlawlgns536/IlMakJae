using UnityEngine;

public class SavePoint0 : MonoBehaviour
{
    public int hintID;
    private bool isCollected;
    private Vector3 originalPosition;

    void Awake()
    {
        originalPosition = transform.position;
    }

    void Start()
    {
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject playerObj = collision.gameObject; // 여기서 실제 플레이어 오브젝트 접근

        if (!playerObj.CompareTag("Player")) return;
        if (isCollected) return;

        isCollected = true;
        PlayerData.Instance.collectedHintIDs.Add(hintID);

        // 화면에서만 사라지게 처리
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        // Return_Death 스크립트가 있으면 부활 위치 업데이트
        Return_Death deathScript = playerObj.GetComponent<Return_Death>();
        if (deathScript != null)
        {
            deathScript.UpdateRespawnPosition(playerObj.transform.position);
        }

        // 파티클/사운드 재생 가능
    }




    void MoveAway()
    {
        transform.position = new Vector3(1000, 0, 0);
    }
}
