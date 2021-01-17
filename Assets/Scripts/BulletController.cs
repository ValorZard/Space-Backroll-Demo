using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	private Transform bullet;
	public float speed;
	public int port;
	public Vector3 direction;
	public float maxBoundX, minBoundX, maxBoundY, minBoundY;

	// Use this for initialization
	void Start()
	{
		bullet = GetComponent<Transform>();
	}

	void FixedUpdate()
	{
		bullet.position += direction * speed;

		if (bullet.position.x < minBoundX)
			Destroy(gameObject);
		else if (bullet.position.x > maxBoundX)
			Destroy(gameObject);

		if (bullet.position.y < minBoundY)
			Destroy(gameObject);
		else if (bullet.position.y > maxBoundY)
			Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && other.GetComponent<PlayerController>().port != port)
		{
			other.GetComponent<PlayerController>().health -= 1;
			Destroy(gameObject);
		}
	}
}
