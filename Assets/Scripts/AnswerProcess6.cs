using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerProcess6 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (A.answer == 1)
        {
            SceneManager.LoadScene("Stage2");
        }
    }
}
