using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
	public float fObjectLifetime;
	void Start()
	{
		Destroy(gameObject, fObjectLifetime);
	}
}
