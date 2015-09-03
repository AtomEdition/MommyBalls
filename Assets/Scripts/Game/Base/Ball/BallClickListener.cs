using UnityEngine;
using System.Collections;

public abstract class BallClickListener {

	private static float x1 = 0, x2 = 0, y1 = 0, y2 = 0;
	private static float adjacentCathetus;
	private static float opposingCathetus;
	private static float hypotenuse;

	public static void setNewPoints(float x, float y)
	{
		x2 = x1;
		y2 = y1;
		x1 = x;
		y1 = y;
	}

	private static void makeTriangle()
	{
		adjacentCathetus = Mathf.Abs (x2 - x1);
		opposingCathetus = Mathf.Abs (y2 - y1);
		hypotenuse = Mathf.Sqrt (adjacentCathetus * adjacentCathetus + opposingCathetus * opposingCathetus);
	}

	public static float getAngle()
	{
		makeTriangle ();
		float angle = Mathf.Atan (opposingCathetus / adjacentCathetus);
		if ((x2 < x1) && (y2 > y1))
			return 180 - Mathf.Rad2Deg * angle;
		else if ((x2 < x1) && (y2 < y1))
			return 180 + Mathf.Rad2Deg * angle;
		else if ((x2 > x1) && (y2 < y1))
			return 360 - Mathf.Rad2Deg * angle;
		return angle;
	}

	public static float getPowerX()
	{
		float powerX = (x1 - x2) * BallPreferences.ballPowerMultipler;
		if (powerX < BallPreferences.ballPowerMaximum) 
			return powerX;
		return BallPreferences.ballPowerMaximum;
	}

	
	public static float getPowerY()
	{
		float powerY = (y1 - y2) * BallPreferences.ballPowerMultipler; 
		if (powerY < BallPreferences.ballPowerMaximum) 
			return powerY;
		return BallPreferences.ballPowerMaximum;
	}
}