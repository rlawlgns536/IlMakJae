using UnityEngine;

using TMPro; // TextMeshPro를 사용하기 위해 필수!

public class GameEndZone : MonoBehaviour
{
    [Header("UI 연결")]
    public TextMeshProUGUI finishText; // "완료" 텍스트 오브젝트를 넣을 변수

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어와 닿았는지 확인
        if (other.CompareTag("Player"))
        {
            ShowFinishText();
        }
    }

    void ShowFinishText()
    {
        // 1. 텍스트 오브젝트가 연결되어 있다면 켭니다 (보이게 함)
        if (finishText != null)
        {
            finishText.gameObject.SetActive(true);
            finishText.text = "Fin."; // 확실하게 텍스트 설정
        }

       
        Time.timeScale = 0; 
    }
}

