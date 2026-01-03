using UnityEngine;
using TMPro;
public class TimerText : MonoBehaviour
{
    public TMP_Text tmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = Timer.timer.ToString();
    }
}
