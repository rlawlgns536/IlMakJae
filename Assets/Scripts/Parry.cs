using UnityEngine;

public class Parry : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            ParryLazer();
        }
    }

    void ParryLazer()
    {
        int lazerNumber = Random.Range(1, 17);
        string lazerTag = lazerNumber.ToString();

        GameObject laser = GameObject.FindGameObjectWithTag(lazerTag);
        if (laser == null) return;

        Collider2D col = laser.GetComponent<Collider2D>();
        if (col != null && col.enabled)
        {
            col.enabled = false;

            // ✅ 패링 성공
            StatSystem.parryCount++;

            if (StatSystem.shieldhp > 0)
            {
                StatSystem.shieldhp -= 500;
            }
            else
            {
                StatSystem.bosshp -= 500;
            }
        }
    }

}
