using UnityEngine;
using TMPro;
public class Question1 : MonoBehaviour
{
    public TMP_Text tmp;
    public static bool col2 = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        col2 = true;
        tmp.text = "4.다음중 ?????? 의 코드로 적절한 것은 ?\n\n < 보기 >\nplt.figure(figsize = (8, 6)) # 그래프 크기 설정 \nplt.title('Distribution of Braking Distance') # 그래프 제목 \nsns.??????(vg_1['Genre'], kde=True) # 히스토그램 + 밀도 곡선 plt.xlabel('Genre(장르)') # x축 라벨 \nplt.ylabel('Frequency') # y축 라벨 \nplt.grid(True) plt.show() # 그래프 출력\n?------------------------------------------------\n1.histplot 2.boxplot 3.ylabel 4.scatter 5. xlabel\n";
    }
}
