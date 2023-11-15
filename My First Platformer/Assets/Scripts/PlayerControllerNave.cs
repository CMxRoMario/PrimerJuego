using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerNave : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float speed = 5f;
    public int lifes = 10;
    public Transform mainCamera;
    private float lastShoot;

    void Update()
    {
        // Movimiento del jugador
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        transform.Translate(movement * speed * Time.deltaTime);
        
        float cameraX = mainCamera.position.x;
        float minX = cameraX - 10f;
        float maxX = cameraX + 7f;
        float minY = 2f;
        float maxY = 9f;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        );

        if (Input.GetKey(KeyCode.Space) && Time.time > lastShoot + 0.75f)
        {
            Shoot();
            lastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.9f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        lifes = lifes -1;
        if (lifes == 0) Destroy(gameObject);
    }
}