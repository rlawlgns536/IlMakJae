using UnityEngine;
using TMPro;
public class BossHpTex2 : MonoBehaviour
{
    public TMP_Text tmp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = "방어막 hp: " + StatSystem.shieldhp.ToString() + "\n보스 hp: " + StatSystem.bosshp.ToString();
    }
}
