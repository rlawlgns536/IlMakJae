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
            PlayerData.Instance.hint++;
            ;
            if (PlayerData.Instance.hint == 1)
            {

            }
            else if (PlayerData.Instance.hint == 2)
            {
            
            }
            else if (PlayerData.Instance.hint == 3)
            {
            
            }
            else if (PlayerData.Instance.hint == 4)
            {
            
            }
        }
    }
}
