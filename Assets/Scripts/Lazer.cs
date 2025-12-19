using UnityEngine;

public class Lazer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time % 2);
        
        if (Time.time % 2 >= 1.5)
        {
            transform.localPosition = new Vector2(0, 0);
        }
        else if (Time.time % 2 < 1.5)
        {
            transform.position = new Vector2(-50, -50);
        }
    }
}
