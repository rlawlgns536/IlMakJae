using UnityEngine;

public class Q_1 : MonoBehaviour
{
    public KeyCode targetKey = KeyCode.None; // 초기값 설정

    public void ProcessInput()
    {
        Debug.Log($"{gameObject.name} (키: {targetKey}) 사라짐!");
        gameObject.SetActive(false);
    }
}