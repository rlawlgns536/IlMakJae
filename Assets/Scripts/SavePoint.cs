using UnityEngine;

public class SavePoint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Return_Death.a = this.transform.position.x;
            Return_Death.b = this.transform.position.y + 1;
            Return_Death.c = this.transform.position.z;
        }
        transform.Translate(0, 1000, 0);
    }
}
