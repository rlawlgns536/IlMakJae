using UnityEngine;
using System.Collections;

public class BossBomb : MonoBehaviour
{
    public float bombcool = 4f;
    private float timer = 0f;

    private SpriteRenderer spriteRenderer;
    public Sprite sprite1;  // ÆøÅº Àü
    public Sprite sprite2;  // Æø¹ß
    public float activeTime = 0.5f;

    private bool isActive = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite1;
        transform.position = new Vector2(-100, -100); // ÃÊ±â ºñÈ°¼º À§Ä¡
    }

    void Update()
    {
        if (!isActive)
        {
            timer += Time.deltaTime;
            if (timer >= bombcool)
            {
                timer = 0f;
                StartCoroutine(ActivateBomb());
            }
        }
    }

    IEnumerator ActivateBomb()
    {
        isActive = true;

        // ·£´ý À§Ä¡·Î ÀÌµ¿
        int x = Random.Range(-15, 16);
        int y = Random.Range(-15, 16);
        transform.position = new Vector2(x, y);

        // ÆøÅºÀÌ Àá½Ã È°¼ºÈ­ (Sprite1 À¯Áö)
        spriteRenderer.sprite = sprite1;

        yield return new WaitForSeconds(activeTime);

        // Æø¹ß Ã³¸®
        spriteRenderer.sprite = sprite2;

        // Àá±ñ Æø¹ß Ç¥½Ã
        yield return new WaitForSeconds(0.1f);

        // ÃÊ±âÈ­
        transform.position = new Vector2(-100, -100);
        spriteRenderer.sprite = sprite1;

        isActive = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StatSystem.playerhp -= 1000;
            spriteRenderer.sprite = sprite2;
        }
    }

}
