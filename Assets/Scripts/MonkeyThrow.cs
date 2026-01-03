using UnityEngine;
using System.Collections;

public class MonkeyThrow : MonoBehaviour
{
    public GameObject bananaPrefab;
    public GameObject bombPrefab;
    public Transform throwPoint;

    public float throwForce = 7f;

    private bool throwBanana = true;

    void Start()
    {
        StartCoroutine(ThrowRoutine());
    }

    IEnumerator ThrowRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            if (throwBanana)
                Throw(bananaPrefab);
            else
                Throw(bombPrefab);

            throwBanana = !throwBanana;
        }
    }

    void Throw(GameObject obj)
    {
        GameObject g = Instantiate(obj, throwPoint.position, Quaternion.identity);
        Rigidbody2D rb = g.GetComponent<Rigidbody2D>();

        Vector2 dir = (GameObject.FindGameObjectWithTag("Player").transform.position
                      - throwPoint.position).normalized;

        rb.AddForce(dir * throwForce, ForceMode2D.Impulse);
    }
}
