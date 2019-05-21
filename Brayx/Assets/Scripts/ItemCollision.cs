using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
	public string team;
	private Rigidbody2D RB2D;
	private SpriteRenderer sprite;
	public Sprite[] sprites;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "item")
		{
			if(collision.gameObject.GetComponent<ItemCollision>().team == "neutral")
			{
				collision.gameObject.GetComponent<ItemCollision>().team = team;
			}
		}
	}
	// Start is called before the first frame update
	private void Start()
	{
		team = "neutral";
		RB2D = gameObject.GetComponent<Rigidbody2D>();
		sprite = gameObject.GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	private void Update()
	{
		if (RB2D.velocity.magnitude <= 2)
		{
			team = "neutral";
		}
		switch(team)
		{
			case "neutral": sprite.sprite = sprites[0];
				break;
			case "blue": sprite.sprite = sprites[1];
				break;
			case "green": sprite.sprite = sprites[2];
				break;
			default: sprite.sprite = sprites[0];
				break;
		}
	}
}
