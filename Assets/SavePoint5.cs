using UnityEngine;

public class SavePoint5 : MonoBehaviour
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        if (isCollected) return;

        isCollected = true;
        PlayerData.Instance.collectedHintIDs.Add(hintID);
        MoveAway();
    }

    void MoveAway()
    {
        transform.position = new Vector3(1000, 0, 0);
    }
}
