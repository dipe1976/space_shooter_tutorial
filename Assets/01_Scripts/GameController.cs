using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject hazardObject;
	public Vector3 spawnPositioning;
	public int iHazardCount;
	public float fSpawnWait, finitialWait, fWaveWait;
	public Text tScoreText, tRestartText, tGameOverText;
	private int iScore;
	private bool bGameOver, bRestart;

	void Start()
	{
		iScore = 0;
		bGameOver = bRestart = false;
		tRestartText.text = tGameOverText.text = "";
		UpdateScore();	
		StartCoroutine(SpawnWaves());
	}

	void Update()
	{
		if (bRestart)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(finitialWait);
		while(true)
		{
			for (int count = 0; count < iHazardCount; count++)
			{
				Vector3 spawnPositon = new Vector3(Random.Range(-(spawnPositioning.x), spawnPositioning.x), spawnPositioning.y, spawnPositioning.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazardObject,spawnPositon, spawnRotation);
				yield return new WaitForSeconds(fSpawnWait);
			}
			yield return new WaitForSeconds(fWaveWait);
			if (bGameOver)
			{
				tRestartText.text ="Press 'R' für restart";
				bRestart = true;
				break;
			}
		}
	}

	public void AddScore(int iScoreToAdd)
	{
		iScore += iScoreToAdd;
		UpdateScore();
	}
	void UpdateScore()
	{
		tScoreText.text = "Score: " + iScore;
	}

	public void GameOver()
	{
		tGameOverText.text = "Game Over!";
		bGameOver = true;
	}
}
