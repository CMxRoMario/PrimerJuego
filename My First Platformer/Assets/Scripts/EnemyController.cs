using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public GameObject BulletPrefab;
    public int lifes = 10;
    public float moveSpeed = 4f;
    public float descendTime = 1f;
    public float ascendTime = 1f;
    private float lastShoot;
    
    public Transform mainCamera;

    private bool isDescending = true;

    void Start()
    {
        InvokeRepeating("CambiarMovimiento", 1f, descendTime + ascendTime);
    }

    void Update()
    {
        if (isDescending)
        {
            Descend();
        }
        else
        {
            Ascend();
        }
        
        
        float cameraX = mainCamera.position.x;
        float minY = 2f;
        float maxY = 9f;

        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        );

        
        if (Time.time > lastShoot + 0.75f)
        {
            Shoot();
            lastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        direction = Vector2.left;
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.9f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
    
    public void Hit()
    {
        lifes = lifes -1;
        if (lifes == 0) Destroy(gameObject);
    }


    void Descend()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    void Ascend()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    void CambiarMovimiento()
    {
        isDescending = !isDescending;
    }
    
}