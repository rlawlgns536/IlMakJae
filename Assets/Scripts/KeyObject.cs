using UnityEngine;

public class KeyObject : MonoBehaviour
{
    public KeyCode targetKey = KeyCode.None; 

    public void ProcessInput()
    {
        // 입력 성공 시 오브젝트 비활성화
        gameObject.SetActive(false); 
    }
}