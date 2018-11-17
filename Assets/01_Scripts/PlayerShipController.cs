using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin,xMax,zMin,zMax;
}
public class PlayerShipController : MonoBehaviour
{
	public float fPlayerSpeed, fPlayerFireRate;
	public float fPlayerTilt;
	public Boundary PlayerBoundary;
	public GameObject shotPrefab;
	public Transform shotSpawn;
	private Rigidbody rbPlayerShip;
	private AudioSource asPlayerShot;
	private float fNextShot = 0.0f;
	void Start()
	{
		rbPlayerShip = GetComponent<Rigidbody>();
		asPlayerShot = GetComponent<AudioSource>();
	}
	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > fNextShot)
		{
			// GameObject clone = 
			Instantiate(shotPrefab, shotSpawn.position, shotSpawn.rotation);
			asPlayerShot.Play(0);
			//  as GameObject;
			fNextShot = Time.time + fPlayerFireRate;
		}
	}
	void FixedUpdate()
	{
		float fMoveHorizontal = Input.GetAxis("Horizontal");
		float fMoveVertical = Input.GetAxis("Vertical");

		rbPlayerShip.velocity = new Vector3(fMoveHorizontal, 0.0f, fMoveVertical) * fPlayerSpeed;
		rbPlayerShip.position = new Vector3
		(
			Mathf.Clamp(rbPlayerShip.position.x, PlayerBoundary.xMin, PlayerBoundary.xMax),
			0.0f,
			Mathf.Clamp(rbPlayerShip.position.z, PlayerBoundary.zMin, PlayerBoundary.zMax)
		);
		rbPlayerShip.rotation = Quaternion.Euler(0.0f, 0.0f, rbPlayerShip.velocity.x * -fPlayerTilt);
	}
}
