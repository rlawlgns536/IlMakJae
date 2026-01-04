using UnityEngine;
using TMPro;
public class Question : MonoBehaviour
{
    public TMP_Text tmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Clear.col == true)
        {
            tmp.text = "Q.1.이 중에서 비정규화 데이터가 아닌것은? \n\n1.A가 찍은 환경 사진 데이터 \n2.B가 녹음한 노래 모음집 음성 데이터 \n3.C가 녹화한 애완동물 동영상 데이터 \n4.D가 새벽에 쓴 소설 텍스트 데이터 \n5.E가 기록한 실험 기록 데이터 \n";
        }
        else
        {
            tmp.text = "";
        }
    }
}
