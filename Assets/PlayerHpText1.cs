using UnityEngine;
using TMPro;

public class PlayerHPText1 : MonoBehaviour
{
    public TMP_Text tmp;
    private PlayerHP playerHP; // PlayerHP 인스턴스 참조

    void Start()
    {
        // 같은 오브젝트에 PlayerHP가 있을 경우
        playerHP = GetComponent<PlayerHP>();

        // 다른 오브젝트에 있을 경우 (예: Player)
        if (playerHP == null)
        {
            playerHP = GameObject.FindWithTag("Player")?.GetComponent<PlayerHP>();
        }
    }

    void Update()
    {
        if (playerHP != null)
            tmp.text = "플레이어 HP: " + playerHP.currentHP.ToString();
    }
}
