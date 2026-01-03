using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 공통으로 참조되는 변수들만 유지
    public static PlayerMove Instance;

    private void Awake()
    {
        Instance = this;
    }
}
