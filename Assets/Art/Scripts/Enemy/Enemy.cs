using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject destroyEffect;
    private Vector3 direction;
    // Update is called once per frame
    void FixedUpdate()   
    {
        //luon theo doi vi tri   cua player
        if (PlayerController.Instance.transform.position.x > 
        transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        //di chuyen den vi tri cua player
        direction = (PlayerController.Instance.transform.position -
        transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        
    }
    void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
                Instantiate(destroyEffect, transform.position, transform.rotation);
            }
        }
}
