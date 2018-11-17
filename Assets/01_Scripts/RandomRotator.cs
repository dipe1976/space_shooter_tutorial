﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
	public float fTumble;

	private Rigidbody rbAsteroid;

	void Start()
	{
		rbAsteroid = GetComponent<Rigidbody>();
		rbAsteroid.angularVelocity = Random.insideUnitSphere * fTumble;
	}
}
