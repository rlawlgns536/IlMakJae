using UnityEngine;
using TMPro;
using Unity.Burst.CompilerServices;
public class ExitText1 : MonoBehaviour
{
    public TMP_Text tmp;
    public PlayerHP curhp;

    void Awake()
    {
        curhp = GetComponent<PlayerHP>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
