using TMPro;
using UnityEngine;

public class Question2 : MonoBehaviour
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
        tmp.text = "8.\r\n다음 중 if문 조건으로 항상 참(True) 이 되는 것은? \r\n\r\n<보기> \r\n x = 0 \r\n—-----------------------------------\r\n1.if x: \r\n2.if x == 0: \r\n3.if x = 0: \r\n4.if x is 0: \r\n5.if x != 0:\r\n";
    }
}
