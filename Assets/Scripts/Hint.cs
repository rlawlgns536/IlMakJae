using UnityEngine;

public class Hint : MonoBehaviour
{
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
        if (other.gameObject.tag == "Player")
        {
            PlayerMove.hint += 1;
            if (PlayerMove.hint == 1)
            {

            }
            else if (PlayerMove.hint == 2)
            {
            
            }
            else if (PlayerMove.hint == 3)
            {
            
            }
            else if (PlayerMove.hint == 4)
            {
            
            }
        }
    }
}
