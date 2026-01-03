using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 3;
    public int currentHP;

    void Start()
    {
        currentHP = maxHP;
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
