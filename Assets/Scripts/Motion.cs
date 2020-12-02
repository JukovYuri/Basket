using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
	public float speedRotation;
	public float speedMotionX;
	public float speedMotionY;
	private float posX, posY, PosZ;
	private int directionX;
	private int directionY;
	bool isCollision;

	[Space]
	[Header("Elliptical movement")] 
	[Range (0f, 10f)] public float a;
	[Range(0f, 10f)] public float b;


	private float t = 0;
	private float moveDown = 0;

	Subject subject;


	void Start()
	{
		subject = FindObjectOfType<Subject>();

		directionY = 1;
		directionX = 1;

		PosZ = 0;
		posX = transform.position.x;
		posY = transform.position.y;


	}

	void CountSubject() 
	{ 
	
	}

	void Update()
	{
		if (subject.isEnemy)
		{
			MotionDiff();
			return;
		}

		MotionSimple();
	}

	void MotionSimple()
	{
		transform.Rotate(Vector3.forward * Time.deltaTime * speedRotation);

		posX += Time.deltaTime * directionX * speedMotionX;
		posY -= Time.deltaTime * directionY * speedMotionY;
		transform.position = new Vector3(posX, posY, PosZ);
	}

	void MotionDiff()
	{		
		transform.Rotate(Vector3.forward * Time.deltaTime * speedRotation);

		posX = a * Mathf.Cos(t);
		posY = 6 + b * Mathf.Sin(t);
		posY -= moveDown;

		moveDown += Time.deltaTime * speedMotionY;
		t += Time.deltaTime;
		if (t >= Mathf.PI * 2)
		{
			t = 0;
		}

		transform.position = new Vector3(posX, posY, PosZ);
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.CompareTag("Wall"))
		{
			directionX = -directionX;
			return;
		}

		if (collision.gameObject.CompareTag("Roof"))
		{
			directionY = -directionY;
			return;
		}

	}
}
