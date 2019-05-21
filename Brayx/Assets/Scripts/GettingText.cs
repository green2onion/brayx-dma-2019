using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GettingText : MonoBehaviour
{
	public string player;
	// Start is called before the first frame update
	private void Start()
	{

	}

	// Update is called once per frame
	private void Update()
	{
		if (player == "blue")
		{
			gameObject.GetComponent<Text>().text = "X " + Stocks.blueStocks;
		}
		if (player == "green")
		{
			gameObject.GetComponent<Text>().text = Stocks.greenStocks + " X";
		}

	}
}
