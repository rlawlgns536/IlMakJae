using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;      // 따라갈 대상
    public float speed = 3f;      // 따라가는 속도

    void Update()
    {
        if (target == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StatSystem.playerhp -= 100;
        }
    }
}
