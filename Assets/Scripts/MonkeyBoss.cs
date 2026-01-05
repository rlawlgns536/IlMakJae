using UnityEngine;
using TMPro;
public class MonkeyBoss : MonoBehaviour
{
    public static int bossHP = 7;
    public TMP_Text tmp;
    void Start()
    {
        bossHP = 5;
    }
    public void HitByBomb()
    {
        bossHP--;

        Debug.Log("보스 HP: " + bossHP);

        if (bossHP <= 0)
        {
            tmp.text = "4.다음중 ??????의 코드로 적절한 것은?\n\n<보기>\nplt.figure(figsize=(8, 6)) # 그래프 크기 설정 \nplt.title('Distribution of Braking Distance') # 그래프 제목 \nsns.??????(vg_1['Genre'], kde=True) # 히스토그램 + 밀도 곡선 plt.xlabel('Genre(장르)') # x축 라벨 \nplt.ylabel('Frequency') # y축 라벨 \nplt.grid(True) plt.show() # 그래프 출력\n?------------------------------------------------\n1.histplot 2.boxplot 3.ylabel 4.scatter 5. xlabel\n";
        }
    }
}
