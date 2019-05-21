public static class Stocks
{
	public static int blueStocks = 3;
	public static int greenStocks = 3;
	public static void playerDeath(string player)
	{
		if (player == "green")
		{
			greenStocks--;
		}
		else if (player == "blue")
		{
			blueStocks--;
		}
	}
}
