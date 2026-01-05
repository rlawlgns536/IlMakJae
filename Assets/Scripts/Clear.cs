using UnityEngine;
using UnityEngine.SceneManagement;
public class Clear : MonoBehaviour
{
    public static bool col = false; 
    public static bool stage = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Hint")
        {
            PlayerData.Instance.hint += 1;
        }
        if (other.gameObject.tag == "Clear" && PlayerData.Instance.hint == 4)
        {
            SceneManager.LoadScene("ClearScene");
            col = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
    if (other.gameObject.tag == "Clear")
        {
            col = false;
        }
    }
}
