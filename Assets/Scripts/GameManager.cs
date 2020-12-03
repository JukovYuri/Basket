using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public Text textScore;
	public Text textLife;
	public GameObject drawLife;
	public Image heart;
	List <Image> cloneHearts = new List<Image>();
	int score = 0;
	public int life;
	public bool isPause;
	public GameObject panelPause;
	public GameObject PanelEnd;
	public Text velocity;




	void Start() 
	{
		textScore.text = score.ToString();
		Time.timeScale = 1;
		PanelEnd.SetActive(false);
		PrintLife();
	}

	public void RestartGame()
	{
		int level = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(level);
	}

	public void Exit()
	{
		Application.Quit();
		//проверить bestscore
	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SetPauseSwitch();
		}

		velocity.text = Time.timeScale.ToString(); 

	}

	public void AddScore(int score)
	{
		this.score += score;
		AddTimeScaleFromScore();
		CheckScore();
		PrintScore();
	}

	public void PrintScore()
	{
		textScore.text = score.ToString();
	}

	public void AddLife(int life)
	{
		this.life += life;
		CheckLife();
		PrintLife();
	}

	public void SubLife()
	{
		life--;
		CheckLife();
		PrintLife();
	}

	void PrintLife()
	{
		if (life < 4)
		{
			PrintLifeHeart();
			return;
		}
		else
		{
			PrintLifeText();
		}
	}

	void CheckLife()
	{
		if (life <= 0)
		{
			SetPauseSwitch();
			PanelEnd.SetActive(true);
			SaveBestScore();
		}
	}

	void CheckScore()
	{
		if (score <= 0)
		{
			SetPauseSwitch();
			SaveBestScore();
			PanelEnd.SetActive(true);
		}
	}

	void PrintLifeText()
	{
		textLife.gameObject.SetActive(true);
		drawLife.SetActive(false);
		textLife.text = $" x {life}";
	}

	void PrintLifeHeart()
	{ 
		textLife.gameObject.SetActive(false);
		drawLife.SetActive(true);

		foreach (Image item in cloneHearts)
		{
			Destroy(item.gameObject);
		}
		cloneHearts.Clear();

		for (int i = 0; i <= life-1; i++)
		{
			Image cloneHeart =  Instantiate(heart, drawLife.transform);
			cloneHearts.Add(cloneHeart);
		}
	}

	void AddTimeScaleFromScore() // в зависимости от score
	{
		Time.timeScale = 1 + (score/100f);
	}


	public void AddTimeScale(float multiply)
	{
		Time.timeScale *= multiply;
	}

	void SetPauseSwitch()
	{
		isPause = !isPause;
		if (isPause)
		{
			Time.timeScale = 0;
			panelPause.SetActive(true);
			return;
		}

		if (!isPause)
		{
			Time.timeScale = 1;
			panelPause.SetActive(false);
			return;
		}

	}
	void SaveBestScore()
	{
		PlayerPrefs.SetInt("bestScore", score);
	}

}
