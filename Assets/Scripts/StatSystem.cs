using UnityEngine;

public class StatSystem : MonoBehaviour
{
    public static int bosshp = 10000;
    public static int bossatk = 1000;
    public static int shieldhp = 10000;
    public static int playerhp = 3000;
    public static int playeratk = 500;
    public static int parryCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bosshp = 10000;
        bossatk = 1000;
        shieldhp = 10000;
        playerhp = 3000;
        playeratk = 500;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
