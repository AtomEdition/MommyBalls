using UnityEngine;
using System.Collections;

public abstract class BasketClickListener {

	private static float x1 = 0, x2 = 0, y1 = 0, y2 = 0;
	private static float adjacentCathetus;
	private static float opposingCathetus;
	private static float hypotenuse;

	public static void SetNewPoints(float x, float y)
	{
		x2 = x1;
		y2 = y1;
		x1 = x;
		y1 = y;
	}

	private static void MakeTriangle()
	{
		adjacentCathetus = Mathf.Abs (x2 - x1);
		opposingCathetus = Mathf.Abs (y2 - y1);
		hypotenuse = Mathf.Sqrt (adjacentCathetus * adjacentCathetus + opposingCathetus * opposingCathetus);
	}

	public static float GetPowerX()
	{
		float powerX = (x1 - x2) * BallProperties.BALL_POWER_MULTIPLIER;
		if (powerX < BallProperties.BALL_POWER_MAXIMUM) 
			return powerX;
		return BallProperties.BALL_POWER_MAXIMUM;
	}

	
	public static float GetPowerY()
	{
		float powerY = (y1 - y2) * BallProperties.BALL_POWER_MULTIPLIER; 
		if (powerY < BallProperties.BALL_POWER_MAXIMUM) 
			return powerY;
		return BallProperties.BALL_POWER_MAXIMUM;
	}
}