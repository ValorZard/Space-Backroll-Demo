using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Transform player;
    public int port;
    public int maxHealth;
    public int health;
    public float speed;
    public float maxBoundX, minBoundX, maxBoundY, minBoundY;

    public GameObject shot;
    public Transform shotSpawn;

    public Transform spawnPoint;

    private float horizontalInput, verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputSystem.Update();

        if (player.position.x < minBoundX && horizontalInput < 0)
            horizontalInput = 0;
        else if (player.position.x > maxBoundX && horizontalInput > 0)
            horizontalInput = 0;

        if (player.position.y < minBoundY && verticalInput < 0)
            verticalInput = 0;
        else if (player.position.y > maxBoundY && verticalInput > 0)
            verticalInput = 0;

        player.position += Vector3.right * horizontalInput * speed;
        player.position += Vector3.up * verticalInput * speed;

        if(health < 0)
        {
            health = maxHealth;
            player.position = spawnPoint.position;
        }

    }

    private void OnMove(InputValue input)
    {
        horizontalInput = input.Get<Vector2>().x;
        verticalInput = input.Get<Vector2>().y;
    }

    private void OnFire()
    {
        GameObject bullet = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        bullet.GetComponent<BulletController>().port = port;
        if(port == 1)
        {
            bullet.GetComponent<BulletController>().direction = Vector3.up;
        }
        else if (port == 2)
        {
            bullet.GetComponent<BulletController>().direction = Vector3.down;
        }
    }
}
