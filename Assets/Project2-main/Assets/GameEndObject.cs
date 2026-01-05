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
            finishText.text = "6.\n다음은 파이썬의 tkinter를 이용한 코드이다. 코드를 실행했을 때 화면에 나타나는 것으로 가장 알맞은 것은? 보기 1.아무것도 없는 검은 화면이 나타난다 \n<보기>\nimport tkinter as tk \n\nwindow = tk.Tk() \nwindow.title(\"예제\") \n\nbtn = tk.Button(window, text=\"클릭\") \nbtn.pack() \n\nwindow.mainloop() \n?---------------------------------------------------------\n1.아무것도 없는 검은 화면이 나타난다 \n2.\"클릭\"이라는 글자가 적힌 버튼 하나가 있는 창이 나타난다 \n3.콘솔 창에 클릭이라는 글자가 출력된다 \n4.오류가 발생하여 프로그램이 실행되지 않는다 \n5.버튼 두 개가 있는 창이 나타난다 \n"; // 확실하게 텍스트 설정
        }

       
        Time.timeScale = 0; 
    }
}

