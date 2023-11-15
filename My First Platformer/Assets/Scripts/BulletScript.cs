using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    public float destroyDelay = 3f;
    private float startTime;
    private Rigidbody2D rb;
    private Vector2 Direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        startTime = Time.time; 
        
        if (Time.time - startTime >= destroyDelay)
        {
            DestroyBullet();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControllerNave nave = collision.GetComponent<PlayerControllerNave>();
        EnemyController rival = collision.GetComponent<EnemyController>();
        
        if (nave != null)
        {
            nave.Hit();
        }
        if (rival != null)
        {
            rival.Hit();
        }
        DestroyBullet();
    }    
}
