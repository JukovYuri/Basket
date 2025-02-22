﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
	[Range(-5, 5)] public int score;
	[Range(-1, 1)] public int life;
	[Range(0.5f, 1.5f)] public float multiply;
	public bool isEnemy;
	GameManager gameManager;
	AudioManager audioManager;
	[Header("Звуки")]
	public AudioClip sndOk;
	public AudioClip sndNot;


	private void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(gameObject);

		if (collision.gameObject.CompareTag("Basket"))
		{
			gameManager.AddScore(score);
			gameManager.AddLife(life);
			gameManager.AddTimeScale(multiply);
			audioManager.PlaySound(sndOk);

			if (isEnemy)
			{
				audioManager.PlaySound(sndNot);
				return;
			}

		}

		if (collision.gameObject.CompareTag("Floor"))
		{
			if (isEnemy)
			{
				return;
			}
			gameManager.SubLife();
		}



	}
}


