using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
	public GameObject objectExplosion, playerExplosion; 
	public int iScoreValue;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null)
		{
			Debug.Log("Cannot find GameController Script!");
		}
	}
	void OnTriggerEnter(Collider other)
    {
		if (other.tag != "Boundary")
		{
			Instantiate(objectExplosion, transform.position, transform.rotation);
			if (other.tag == "Player")
			{
				Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
				gameController.GameOver();
			}
			gameController.AddScore(iScoreValue);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
    }
}
