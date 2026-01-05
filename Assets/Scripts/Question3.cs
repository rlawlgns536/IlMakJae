using TMPro;
using UnityEngine;

public class Question3 : MonoBehaviour
{
    public TMP_Text tmp;
    public static bool col3 = false;
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
        col3 = true;
        tmp.text = "2.사이파이(scipy) 라이브러리의 특징은? \r\n\r\n1.matplotlib 기반의 파이썬 시각화 라이브러리이다. \r\n2.대표적인 수치 해석 라이브러리이다. \r\n3.다양한 과학 기술 계산 기능을 제공한다. \r\n4.row과 column으로 이루어진 데이터를 조작하기 위한 Data Frame 구조와 연산을 제공한다. \r\n5.데이터를 시각화하기 위한 다양한 도구를 제공한다\r\n";
    }
}
