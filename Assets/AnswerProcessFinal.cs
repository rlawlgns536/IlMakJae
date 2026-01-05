using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class AnswerProcessFinal : MonoBehaviour
{
    public TMP_Text tmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (A.answer == 3 && Clear.col == true)
        {
            tmp.text = "클리어!";
        }
        else if (A.answer == 1 && Question1.col2 == true)
        {
            tmp.text = "정답!";
        }
        else if (A.answer == 2 && Question2.col3 == true)
        {
            tmp.text = "정답!";
        }
        else if (A.answer == 3 && Question3.col3 == true)
        {
            tmp.text = "정답!";
        }
    }
}
