using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	private Vector2 mDirection;
	private Vector2 mVelocity;
	private Rigidbody2D mRB2D;
	public float mSpeed;
	public string horizontalAxis;
	public string verticalAxis;
	private Quaternion mTargetQuaternion;
	private float rotationSpeed;
	private bool isDead;
	private float angle;
	public string team;
	public string enemyTeam;
	// Start is called before the first frame update
	private void Start()
	{
		mRB2D = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	private void FixedUpdate()
	{
		Movement();
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "item")
		{
			print(gameObject.name);
			Vector2 itemVelocity = collision.relativeVelocity;
			if(collision.gameObject.GetComponent<ItemCollision>().team == enemyTeam)
			{
				Destroy(gameObject);
				Stocks.playerDeath(team);
				SceneManager.LoadScene(0);
			}
			else
			{
				//if (itemVelocity.magnitude >= 7.1)
				//{
				//	print("item collided: " + collision.gameObject.name + "at speed: " + itemVelocity);
				//	//Destroy(gameObject);
				//}
				//else
				//{
					collision.gameObject.GetComponent<ItemCollision>().team = team;
				//}
			}

		}

	}
	private void Movement()
	{
		mDirection = new Vector2(Input.GetAxis(horizontalAxis), Input.GetAxis(verticalAxis));
		mVelocity = mDirection * mSpeed;
		mRB2D.velocity = mVelocity;

		//+= Mathf.Min(Math.Sign(Mathf.DeltaAngle(gameObject.transform.rotation.z * Mathf.Deg2Rad, Mathf.Atan2(mDirection.x, -mDirection.y * Mathf.Deg2Rad))));
		angle = Mathf.Atan2(mDirection.x, -mDirection.y) * Mathf.Rad2Deg;
		//mRB2D.MoveRotation(angle);
		gameObject.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, angle);
		//transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
	}
}
