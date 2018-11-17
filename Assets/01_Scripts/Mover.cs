using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	public float fSpeed;
	private Rigidbody rbBolt;
	void Start()
	{
		rbBolt = GetComponent<Rigidbody>();
		rbBolt.velocity = transform.forward * fSpeed;
	}
}
