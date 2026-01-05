using UnityEngine;
using TMPro;
public class BossHpText1 : MonoBehaviour
{
    public TMP_Text tmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = "방어막 hp: " + StatSystem.shieldhp.ToString() + "\n 패링 성공 여부: " + Parry.Parried;
    }
}
