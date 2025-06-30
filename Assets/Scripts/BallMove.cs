using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour
{
	public float dx = 0;
	public float dy = -0.01f;
	public float speed = 0.2f;
	private float angle = 0;
	private string currentSceneName;

	void Start()
	{
		currentSceneName = SceneManager.GetActiveScene ().name;
	}

	void Update()
	{
		transform.position = new Vector3(transform.position.x + (dx*speed),transform.position.y + (dy*speed),1);
		if (transform.position.y < GameObject.FindGameObjectWithTag("Player").transform.position.y)
		{
			//Application.LoadLevel(Application.loadedLevel); //antigo
			SceneManager.LoadScene(currentSceneName);
		}

		GameObject[] bricks = GameObject.FindGameObjectsWithTag("brick");
		if (bricks.Length == 0)
		{
			alternarLevel();
		}
	}

	void alternarLevel()
	{
		int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
		if(nextSceneIndex < SceneManager.sceneCountInBuildSettings)
		{
			SceneManager.LoadScene(nextSceneIndex);
		}else
		{
			SceneManager.LoadScene(0);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			float angle = 0;
			if (Random.Range(0,100f) < 50f)
			{
				angle = Random.Range(20f, 45f);
			}
			else
			{
				angle = Random.Range(180f+20f, 180f+45f);
			}

			dx = Mathf.Cos(Mathf.Deg2Rad * angle);
			dy = Mathf.Sin(Mathf.Deg2Rad * angle);
			if (dy < 0)
			{
				dy *= -1;
			}
			speed = 0.2f;
		}else if (col.gameObject.tag == "wall")
		{
			dx *= -1;
		}else if (col.gameObject.tag == "roof")
		{
			dy *= -1;
		}else if (col.gameObject.tag == "brick")
		{
			dy *= -1;
			Destroy(col.gameObject);
		}
	}
}
