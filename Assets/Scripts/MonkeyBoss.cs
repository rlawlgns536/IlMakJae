using UnityEngine;
public class MonkeyBoss : MonoBehaviour
{
    public int bossHP = 7;

    public void HitByBomb()
    {
        bossHP--;

        Debug.Log("º¸½º HP: " + bossHP);

        if (bossHP <= 0)
        {
            GameManager.Instance.GameClear();
        }
    }
}
