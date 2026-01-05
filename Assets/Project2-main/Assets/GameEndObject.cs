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
            finishText.text = "다음 중 파이썬 내장 라이브러리에 해당하지 않는 라이브러리는?\n\n1. numpy\n2. __hello__\n3. os\n4. random\n5. tkinter"; // 확실하게 텍스트 설정
        }

       
        Time.timeScale = 1; 
    }
}

