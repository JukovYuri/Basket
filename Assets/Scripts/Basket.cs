using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Basket : MonoBehaviour
{
	public float speedKeyboard = 1F;

	float posX, posY, posZ;
	Collider2D col;
	float basketWidth;
	float posXMin;
	float posXMax;

	bool isKeyControl;
	float posXMouseStart;

	GameManager gameManager;

	void Start()
	{
		col = GetComponent<Collider2D>();
		gameManager = FindObjectOfType<GameManager>();

		posY = transform.position.y;
		posZ = 0;

		Vector2 minXScreen = Vector2.zero;
		Vector2 maxXScreen = new Vector2(Screen.width, 0);

		basketWidth = col.bounds.size.x;

		posXMin = Camera.main.ScreenToWorldPoint(minXScreen).x + basketWidth / 2;
		posXMax = Camera.main.ScreenToWorldPoint(maxXScreen).x - basketWidth / 2;

		posXMouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
	}

	void Update()
	{
		if (gameManager.isPause)
		{
			return;
		}

		BasketController();
	}

	void BasketController()
	{
		float deltaXMouse = posXMouseStart - Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
		posXMouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
	
		if (deltaXMouse == 0)
		{
			posX += Input.GetAxis("Horizontal") * Time.deltaTime * speedKeyboard;
		}

		else
		{
			posX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
		}

		posX = Mathf.Clamp(posX, posXMin, posXMax);
		transform.position = new Vector3(posX, posY, posZ);
	}
}
