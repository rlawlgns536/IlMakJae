using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerProcess : MonoBehaviour
{
    public static int hintnum = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (A.answer == 1)
        {
            hintnum += 1;
            SceneManager.LoadScene("1Stage");
        }
        else if(A.answer != 0 && A.answer != 1)
        {
            SceneManager.LoadScene("1Stage");
        }
    }
}
