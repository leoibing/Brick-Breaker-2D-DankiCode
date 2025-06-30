using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public Rigidbody2D rb;
	public float spd = 5f;

	void Update()
	{
		if (Input.GetKey("right"))
		{
			rb.AddForce(new Vector3(spd, 0, 0));
		}
		if (Input.GetKey("left"))
		{
			rb.AddForce(new Vector3(-spd, 0, 0));
		}

		if (Input.GetKeyUp("right") || Input.GetKeyUp("left"))
		{
			rb.velocity = new Vector3(0, 0, 0);
		}
	}
}
