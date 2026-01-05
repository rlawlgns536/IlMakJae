using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
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

        if (Clear.col == true&&Clear.stage == true)
        {
            tmp.text = "";
            SceneManager.LoadScene("Phase1");
        }
        else if (Clear.col == true && Clear.stage == false)
        {
            tmp.text = "";
            SceneManager.LoadScene("2Stage_Boss");
        }
    }
}
