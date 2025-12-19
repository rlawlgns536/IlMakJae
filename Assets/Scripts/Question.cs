using UnityEngine;

public class Question : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Clear.col == true)
        {

            transform.position = new Vector3(-20.5f, 12.5f, 0f);
        }
        else
        {
            transform.position = new Vector3(-200.5f, 12.5f, 0f);
        }
    }
}
