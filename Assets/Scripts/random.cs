using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI; 

public class random : MonoBehaviour
{
    [Header("프리팹 설정")]
    public GameObject prefabQ;
    public GameObject prefabW;
    public GameObject prefabE;
    public GameObject prefabR;

    [Header("UI 설정")]
    public Image timerBarImage; 

    [Header("게임 설정")]
    public int totalSpawnCount = 7; 
    public float limitTime = 3f;    // 제한 시간을 3초로 설정
    private float currentTime;
    private bool isGameOver = false;
    private bool isFading = false; 

    private List<KeyObject> spawnedScripts = new List<KeyObject>();
    private int currentIndex = 0;

    void Start()
    {
        currentTime = limitTime;
        SpawnRandomObjects();
    }

    void Update()
    {
        // 1. 실패 시 바가 서서히 사라지는 연출
        if (isFading)
        {
            FadeOutTimerBar();
            return; 
        }

        if (isGameOver) return;

        // 2. 타이머 로직 및 바 업데이트
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            
            if (timerBarImage != null)
            {
                timerBarImage.fillAmount = currentTime / limitTime;
            }
        }
        else
        {
            currentTime = 0;
            if (timerBarImage != null) timerBarImage.fillAmount = 0;
            OnFail("시간 초과!"); 
            return;
        }

        // 3. 입력 체크 로직
        if (spawnedScripts.Count == 0 || currentIndex >= spawnedScripts.Count) return;

        KeyCode requiredKey = spawnedScripts[currentIndex].targetKey;

        if (Input.GetKeyDown(requiredKey))
        {
            spawnedScripts[currentIndex].ProcessInput();
            currentIndex++;

            if (currentIndex >= spawnedScripts.Count)
            {
                OnSuccess();
            }
        }
    }

    // 바의 투명도(Alpha)를 줄여서 서서히 사라지게 함
    void FadeOutTimerBar()
    {
        if (timerBarImage == null) return;

        Color currentColor = timerBarImage.color;
        // deltaTime * 3f 속도로 투명도 감소
        currentColor.a = Mathf.Lerp(currentColor.a, 0, Time.deltaTime * 3f);
        timerBarImage.color = currentColor;

        if (currentColor.a <= 0.05f)
        {
            timerBarImage.gameObject.SetActive(false);
            isFading = false;
        }
    }

    void OnSuccess()
    {
        isGameOver = true;
        Debug.Log("<color=cyan><b>[클리어 성공!]</b></color>");
    }

    void OnFail(string reason)
    {
        isGameOver = true;
        isFading = true; // 실패 시 페이드 아웃 시작
        Debug.Log($"<color=red><b>[클리어 실패!]</b></color> 사유: {reason}");
    }

    void SpawnRandomObjects()
    {
        spawnedScripts.Clear();
        currentIndex = 0;

        List<GameObject> objectPool = new List<GameObject> {
            prefabQ, prefabQ, prefabW, prefabW,
            prefabE, prefabE, prefabR, prefabR
        };

        // 셔플 로직
        for (int i = 0; i < objectPool.Count; i++)
        {
            int randomIndex = Random.Range(i, objectPool.Count);
            GameObject temp = objectPool[i];
            objectPool[i] = objectPool[randomIndex];
            objectPool[randomIndex] = temp;
        }

        List<KeyObject> tempScripts = new List<KeyObject>();

        for (int i = 0; i < totalSpawnCount; i++)
        {
            // X좌표 -6부터 2씩 간격 조절
            Vector3 pos = new Vector3(-6 + (i * 2f), 0, 0); 
            GameObject selectedPrefab = objectPool[i];
            GameObject instance = Instantiate(selectedPrefab, pos, Quaternion.identity);
            
            KeyObject script = instance.GetComponent<KeyObject>();
            if (script != null)
            {
                // 프리팹 이름 매칭으로 키 할당
                if (selectedPrefab.name == prefabQ.name) script.targetKey = KeyCode.Q;
                else if (selectedPrefab.name == prefabW.name) script.targetKey = KeyCode.W;
                else if (selectedPrefab.name == prefabE.name) script.targetKey = KeyCode.E;
                else if (selectedPrefab.name == prefabR.name) script.targetKey = KeyCode.R;

                tempScripts.Add(script);
            }
        }

        // X좌표 기준 정렬로 입력 순서 확정
        spawnedScripts = tempScripts.OrderBy(s => s.transform.position.x).ToList();
    }
}