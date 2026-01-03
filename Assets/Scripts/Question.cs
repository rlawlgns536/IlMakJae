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
            tmp.text = "Q.???";
        }
        else
        {
            tmp.text = "";
        }
    }
}
