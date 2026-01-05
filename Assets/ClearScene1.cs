using UnityEngine;
using TMPro;
public class ClearScene1 : MonoBehaviour
{
    public TMP_Text tmp;
    public float a = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        a = Timer_Always.time;
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = "당신의 기록: " + a.ToString();
    }
}
