using UnityEngine;
using System.Collections;

public class LaserTrap : MonoBehaviour
{
    [Header("시간 설정")]
    [Tooltip("게임을 시작하고 레이저가 처음 나오기까지 대기 시간")]
    public float startDelay = 0f; 
    
    [Tooltip("레이저가 켜져 있는 시간")]
    public float onDuration = 2f; 
    
    [Tooltip("레이저가 꺼져 있는 시간")]
    public float offDuration = 3f; 

    private SpriteRenderer spriteRenderer;
    private Collider2D laserCollider;

    void Awake()
    {
        // 컴포넌트 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>();
        laserCollider = GetComponent<Collider2D>();
    }

    void Start()
    {
        // 코루틴 시작
        StartCoroutine(LaserCycle());
    }

    IEnumerator LaserCycle()
    {
        // 1. 처음 시작 대기 (조절 가능)
        // 시작하자마자 레이저가 꺼진 상태로 대기합니다.
        SetLaserActive(false);
        yield return new WaitForSeconds(startDelay);

        while (true) // 무한 반복
        {
            // 2. 레이저 켜기
            SetLaserActive(true);
            yield return new WaitForSeconds(onDuration);

            // 3. 레이저 끄기
            SetLaserActive(false);
            yield return new WaitForSeconds(offDuration);
        }
    }

    // 레이저의 모습과 충돌체를 한꺼번에 끄고 켜는 함수
    void SetLaserActive(bool active)
    {
        if (spriteRenderer != null) spriteRenderer.enabled = active;
        if (laserCollider != null) laserCollider.enabled = active;
    }
}