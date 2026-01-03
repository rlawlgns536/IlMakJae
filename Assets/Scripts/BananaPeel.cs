using UnityEngine;

public class BananaPeel : MonoBehaviour
{
    public float disappearTime = 20f;
    public float slowRate = 0.7f;    // 30% 감소
    public float slowDuration = 3f;  // 3초 지속

    void Start()
    {
        Destroy(gameObject, disappearTime);
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

            Destroy(gameObject);
        }
    }
}
