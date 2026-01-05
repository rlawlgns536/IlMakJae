using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerProcess2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (A.answer == 2)
        {
            StatSystem.hintnum += 1;
            SceneManager.LoadScene("1Stage");
        }
        else if (A.answer != 2 && A.answer != 0)
        {
            SceneManager.LoadScene("1Stage");
        }
    }
}
