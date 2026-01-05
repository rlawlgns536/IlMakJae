using UnityEngine;
using TMPro;

public class ENdText : MonoBehaviour
{
    public TMP_Text tmp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
   
    void Update()
    {
        if (StatSystem.bosshp == 0)
        {
            tmp.text = "Q2.사이파이(scipy) 라이브러리의 특징은?\n\n1.matplotlib 기반의 파이썬 시각화 라이브러리이다.\n2.대표적인 수치 해석 라이브러리이다. \n3.다양한 과학 기술 계산 기능을 제공한다. \n4.row과 column으로 이루어진 데이터를 조작하기 위한 Data Frame 구조와 연산을 제공한다. \n5.데이터를 시각화하기 위한 다양한 도구를 제공한다";
        }
    }
}
