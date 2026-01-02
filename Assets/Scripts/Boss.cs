using UnityEngine;

public class Boss : MonoBehaviour
{
    //보스 폭탄 위치 스크립트
    public int bombnum = 0;
    public float bombcool = 4f;
    public float timer;
    public float timer2;
    public bool timer2Active = false;
    public float StartWaitTime;
    public int a = 0; //폭탄 x좌표
    public int b = 0; //폭탄 y좌표
    private SpriteRenderer spriteRenderer;
    public Sprite sprite1;  // 첫 번째 스프라이트(폭탄 터지기 전)
    public Sprite sprite2;  // 두 번째 스프라이트(폭탄 터진 이미지)
    public float waitTime = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WaitForSeconds(StartWaitTime));
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < bombcool)
        {
            timer += Time.deltaTime;
        }
        else if(timer >= bombcool)
        {
            a = Random.Range(-30, 31);
            b = Random.Range(-30, 31);
            timer2Active = true;
        }
        if(timer2Active == true && timer2 < 0.5f)
        {
            timer2 += Time.deltaTime;
        }
        if(timer2Active == true && timer2 >= 0.5f)
        {
            timer2 = 0;
            timer = 0;
            a = -100;
            b = -100;
            timer2Active = false;
        }
        transform.position = new Vector2(a, b);
    }
    public void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            StatSystem.playerhp -= 1000;
            spriteRenderer.sprite = sprite2;
            StartCoroutine(WaitForSeconds(waitTime));
        }    
    }
    IEnumerator WaitForSeconds(float seconds)
    {
        // seconds만큼 기다리기
        yield return new WaitForSeconds(seconds);
        
        // 기다린 후 실행될 코드
        spriteRenderer.sprite = sprite1;
        a = -100;
        b = -100;
    }
}
