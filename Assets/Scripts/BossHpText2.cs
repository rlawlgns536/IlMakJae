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
        tmp.text = "Shield hp: " + StatSystem.shieldhp.ToString() + "\nBoss hp: " + StatSystem.bosshp.ToString();
    }
}
