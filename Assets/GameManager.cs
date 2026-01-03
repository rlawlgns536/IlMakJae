using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    /* =========================
       게임 설정 (기둥, 시간)
       ========================= */
    [Header("게임 시간 / 기둥")]
    public GameObject pillarPrefab;
    public float totalGameTime = 60f;
    public float startDelay = 3f;
    public float spawnInterval = 0.7f;
    public float minPillarDistance = 1.0f;

    /* =========================
       HP 설정
       ========================= */
    [Header("HP 설정")]
    public int playerHP = 3;
    public int bossHP = 7;

    /* =========================
       UI
       ========================= */
    [Header("UI")]
    public Text timerText;

    /* =========================
       내부 변수
       ========================= */
    private float timer;
    public bool IsGameOver { get; private set; }

    private Camera mainCamera;
    private Vector2 screenBounds;

    /* =========================
       Unity Lifecycle
       ========================= */
    private void Awake()
    {
        // 싱글톤
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        Time.timeScale = 1f;
        mainCamera = Camera.main;
    }

    private void Start()
    {
        screenBounds = mainCamera.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z)
        );

        timer = totalGameTime;
        UpdateTimerUI();

        StartCoroutine(GameRoutine());
    }

    /* =========================
       메인 게임 루프
       ========================= */
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

        if (!IsGameOver && timer <= 0)
        {
            timer = 0;
            UpdateTimerUI();
            GameClear();
        }
    }

    /* =========================
       UI
       ========================= */
    private void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = Mathf.Max(0, Mathf.CeilToInt(timer)).ToString();
    }

    /* =========================
       기둥 생성
       ========================= */
    private void SpawnPillars(int count)
    {
        List<float> xPositions = new List<float>();

        for (int i = 0; i < count; i++)
        {
            for (int attempt = 0; attempt < 10; attempt++)
            {
                float x = Random.Range(-screenBounds.x + 1f, screenBounds.x - 1f);
                bool tooClose = false;

                foreach (float existX in xPositions)
                {
                    if (Mathf.Abs(x - existX) < minPillarDistance)
                    {
                        tooClose = true;
                        break;
                    }
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

    /* =========================
       데미지 처리
       ========================= */

    // 플레이어 피격
    public void PlayerHit()
    {
        if (IsGameOver) return;

        playerHP--;
        Debug.Log("Player HP: " + playerHP);

        if (playerHP <= 0)
            GameOver();
    }

    // 보스 피격
    public void BossHit()
    {
        if (IsGameOver) return;

        bossHP--;
        Debug.Log("Boss HP: " + bossHP);

        if (bossHP <= 0)
            GameClear();
    }

    /* =========================
       게임 종료
       ========================= */
    public void GameOver()
    {
        if (IsGameOver) return;

        IsGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("Game Over");
    }

    public void GameClear()
    {
        if (IsGameOver) return;

        IsGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("Game Clear");
    }
}
