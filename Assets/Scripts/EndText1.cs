using UnityEngine;
using TMPro;

public class ENdText1 : MonoBehaviour
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
            tmp.text = "Q8.다음 코드의 실행 결과로 옳은 것은?\n\n<보기>\n\ndef f(): \nprint(\"Hello\") \nx = f() \n\nif x == None: \nprint(\"A\") \n\nif x is None: \nprint(\"B\")\n—-------------------------------------\n1. Hello \nA \n—-------\n2. Hello \nB \n—---\n3. Hello \nA \nB \n—------\n4. A \n—----\n5. B\n—------\n";
        }
    }
}
