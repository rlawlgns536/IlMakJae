using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 3;
    public int currentHP; // static 제거

    void Start()
    {
        currentHP = maxHP; // Play 시작 시 항상 초기화
    }

    public void TakeDamage()
    {
        currentHP--;

        Debug.Log("플레이어 HP: " + currentHP);

        if (currentHP <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
