using UnityEngine;

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
        if (other.gameObject.tag == "Clear" && stage == true)
        {
            col = true;
            stage = false;
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
