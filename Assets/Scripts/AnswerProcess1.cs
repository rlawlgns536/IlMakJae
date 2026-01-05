using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerProcess1 : MonoBehaviour
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
            StatSystem.hintnum += 1;
            SceneManager.LoadScene("1Stage");
        }
    }
}
