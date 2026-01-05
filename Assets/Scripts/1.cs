using UnityEngine;

public class A : MonoBehaviour
{
    public static int answer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        answer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(answer);
    }
    public void OnButtonClicked()
    { 
        
    }
    public void A_1()
    {
        answer = 1;
    }
    public void A_2()
    {
        answer = 2;
    }
    public void A_3()
    {
        answer = 3;
    }
    public void A_4()
    {
        answer = 4;
    }
    public void A_5()
    {
        answer = 5;
    }
}
