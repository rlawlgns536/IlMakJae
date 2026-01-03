using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    [Header("공용 상태값")]
    public int hint = 0;
    public int jumpnum = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
