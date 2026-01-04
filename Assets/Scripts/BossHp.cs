using UnityEngine;
using UnityEngine.SceneManagement;
public class BossHp : MonoBehaviour
{
    public static int bosshp = 10000;
    public static bool a = false;
    public static bool b = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bosshp = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        if (bosshp <= 0 && a == false)
        {
            SceneManager.LoadScene("Phase3");
            a = true;
        }
        else if (bosshp <= 0 && a == true)
        {
            SceneManager.LoadScene("2Stage");
            b = true;
        }
        if (bosshp <= 0 && b == true)
        {
            SceneManager.LoadScene("1Stage");
        }
    }
}
