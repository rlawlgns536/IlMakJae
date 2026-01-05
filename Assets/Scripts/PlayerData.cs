using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    // 🔴 기존 변수 절대 삭제 금지
    public int hint = 0;
    public int jumpnum = 0;

    // 🔥 이 줄이 핵심이다
    public HashSet<int> collectedHintIDs = new HashSet<int>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
