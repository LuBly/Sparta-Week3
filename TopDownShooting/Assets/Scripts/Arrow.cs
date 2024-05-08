using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // 벽 통과 O
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Debug.Log(collision);
            Invoke("DestroyArrow", 0.5f);
        }
    }

    // 벽 통과 X
    // 현실적인 재미가 이쪽이 좀더 재미있는 것 같다.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Invoke("DestroyArrow", 1.0f);
        }
    }

    void DestroyArrow()
    {
        Destroy(gameObject);
    }
}
