using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GamePlayController : MonoBehaviour
{
	public static GamePlayController instance;

	[SerializeField]
	private Text scoreText, endScore, bestScore, gameOverText;

	[SerializeField]
	private Button restartGameButton, instructionsButton;

	[SerializeField]
	private GameObject pausePanel;

	[SerializeField]
	private GameObject[] birds;

	[SerializeField]
	private Sprite[] medals;

	[SerializeField]
	private Image medalImage;

	void Awake()
	{
        MakeInstance();
		Time.timeScale = 0f;
    }

	// Use this for initialization
	void Start()
	{

	}

	void MakeInstance()
	{
		if (instance == null)
		{
			instance = this;
		}
	}


	public void PauseGame()
	{
        if (BirdScript.instance!=null)
        {
			if (BirdScript.instance.isAlive)
            {
				pausePanel.SetActive(true);
				gameOverText.enabled = false;
				endScore.text = "" + BirdScript.instance.score;
				bestScore.text = "" + GameController.instance.GetHighscore();
				Time.timeScale = 0f;
				restartGameButton.onClick.RemoveAllListeners();
				restartGameButton.onClick.AddListener(() => ResumeGame());
            }
        }
	}

	public void GoToMenuButton()
	{
		SceneFader.instance.FadeIn("MainMenu");
	}

	public void ResumeGame()
	{
		pausePanel.SetActive(false);
		Time.timeScale = 1f;
	}

	public void RestartGame()
	{
		SceneFader.instance.FadeIn("GamePlay");
	}

	public void PlayGame()
	{
		Time.timeScale = 1f;
		birds[GameController.instance.GetSelectedBird()].SetActive(false);
		instructionsButton.gameObject.SetActive(false);
		scoreText.gameObject.SetActive(true);
	}

	public void SetScore(int score)
	{

	}

}
