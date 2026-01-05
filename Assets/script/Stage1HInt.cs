using UnityEngine;
using TMPro;
public class Stage1HInt : MonoBehaviour
{
    public TMP_Text tmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StatSystem.hintnum == 1)
        {
            tmp.text = "2번은 아니다";
        }
        else if (StatSystem.hintnum == 2)
        {
            tmp.text = "3번은 아니다";
        }
        else if (StatSystem.hintnum == 3)
        {
            tmp.text = "4번은 아니다";
        }
        else if (StatSystem.hintnum == 4)
        {
            tmp.text = "5번은 아니다";
        }
        else if (StatSystem.hintnum == 5)
        {
            tmp.text = "1번이 답이다";
        }
    }
}
