using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonListner_Start : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonClicked()
    {
        Timer_Always.time = 0;
        SceneManager.LoadScene("1Stage");
        
    }
}
