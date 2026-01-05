using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("게임 설정")]
    public GameObject pillarPrefab;
    public float totalGameTime = 60f;
    public float startDelay = 3f;
    public float spawnInterval = 0.7f;
    public float minPillarDistance = 1.0f;

    [Header("HP 설정")]
    public int playerHP = 3;
    public int bossHP = 7;

    [Header("UI References")]
    public Text timerText;
    // 이 resultText에 파이썬 문제 지문이 바로 출력됩니다.
    [SerializeField] private TextMeshProUGUI resultText;
    // 배경을 덮을 패널
    [SerializeField] private Image backgroundPanel;

    private float timer;
    public bool IsGameOver { get; private set; }
    private Camera mainCamera;
    private Vector2 screenBounds;

    // 출력할 문제 지문 변수화 (수정하기 편하게 상단에 배치)
    private string questionStr = "7. 다음 파이썬 코드의 실행 결과로 옳은 것은?\n\n<보기>\na = [1, 2, 3] \nb = a \nb.append(4) \n\nprint(a)\n?------------------------------\n1.[1, 2, 3] \n2.[4] \n3.[1, 2, 3, 4] \n4.오류가 발생한다 \n5.[1, 2, 3] [4]\n";

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }
        Time.timeScale = 1f;
        mainCamera = Camera.main;
    }

    private void Start()
    {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        timer = totalGameTime;
        UpdateTimerUI();

        // 시작할 때 UI 꺼두기
        if (backgroundPanel != null) backgroundPanel.gameObject.SetActive(false);
        if (resultText != null) resultText.gameObject.SetActive(false);

        StartCoroutine(GameRoutine());
    }

    private IEnumerator GameRoutine()
    {
        yield return new WaitForSeconds(startDelay);
        while (timer > 0 && !IsGameOver)
        {
            SpawnPillars(10);
            float wait = 0f;
            while (wait < spawnInterval)
            {
                if (IsGameOver) yield break;
                wait += Time.deltaTime;
                timer -= Time.deltaTime;
                UpdateTimerUI();
                yield return null;
            }
        }
        if (!IsGameOver && timer <= 0) { GameClear(); }
    }

    private void UpdateTimerUI()
    {
        if (timerText != null) timerText.text = Mathf.Max(0, Mathf.CeilToInt(timer)).ToString();
    }

    private void SpawnPillars(int count)
    {
        if (pillarPrefab == null) return;
        List<float> xPositions = new List<float>();
        for (int i = 0; i < count; i++)
        {
            for (int attempt = 0; attempt < 10; attempt++)
            {
                float x = Random.Range(-screenBounds.x + 1f, screenBounds.x - 1f);
                bool tooClose = false;
                foreach (float existX in xPositions)
                {
                    if (Mathf.Abs(x - existX) < minPillarDistance) { tooClose = true; break; }
                }
                if (!tooClose)
                {
                    xPositions.Add(x);
                    Instantiate(pillarPrefab, new Vector2(x, 5f), Quaternion.identity);
                    break;
                }
            }
        }
    }

    public void PlayerHit()
    {
        if (IsGameOver) return;
        playerHP--;
        if (playerHP <= 0) GameOver();
    }

    public void BossHit()
    {
        if (IsGameOver) return;
        bossHP--;
        if (bossHP <= 0) GameClear();
    }

    // ---------------------------------------------------------
    // 게임 종료 시 호출되는 핵심 부분
    // ---------------------------------------------------------

    public void GameOver()
    {
        if (IsGameOver) return;
        IsGameOver = true;
        Time.timeScale = 0f;

        // 배경색을 약간 어두운 검정/회색으로 설정하고 지문 출력
        ShowFinalResult(new Color(0f, 0f, 0f, 0.8f));
    }

    public void GameClear()
    {
        if (IsGameOver) return;
        IsGameOver = true;
        Time.timeScale = 0f;

        // 배경색을 밝은 회색으로 설정하고 지문 출력
        ShowFinalResult(new Color(0.5f, 0.5f, 0.5f, 0.8f));
    }

    private void ShowFinalResult(Color bgColor)
    {
        // 1. 배경 활성화 및 색상 변경
        if (backgroundPanel != null)
        {
            backgroundPanel.gameObject.SetActive(true);
            backgroundPanel.color = bgColor;
        }

        // 2. 결과 텍스트에 파이썬 지문을 바로 삽입하고 활성화
        if (resultText != null)
        {
            resultText.gameObject.SetActive(true);
            resultText.text = questionStr; // "GameOver" 문자열 대신 미리 정의한 지문 변수를 넣음
        }
    }
}