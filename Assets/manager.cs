using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GreenElephant;
using TMPro;
using UnityEngine.UI;
using System;

public class manager : MonoBehaviour
{

	public GameObject simObj;
	public UnityEngine.Vector2 v1 = new UnityEngine.Vector2(0, 1);
	public UnityEngine.Vector2 v2 = new UnityEngine.Vector2(1, 0);

	public float b = 5f;
	[Range(0.1f, 0.7f)]
	public float n = .5f;

	Matrix2x2 matrix = new Matrix2x2(0, 1, 1, 0);

	[Range(0, 10)]
	public float magnetudeStrength = 5f;

	public GameObject vector;
	public UnityEngine.Vector2 bounds;
	public float density = 1f;

	GameObject[] vectorObjs;
	SpriteRenderer[] renderers;

	[HideInInspector]
	public bool simRunning = false;

	[Range(0, 10)]
	public float simSpeed = 5;

	UnityEngine.Vector2 velocity;

	Expression xExpression;
	Expression yExpression;

	[SerializeField]
	TMP_InputField xFunctionField;
	[SerializeField]
	TMP_InputField yFunctionField;

	[SerializeField]
	TextMeshProUGUI startstop_sim_button_text;

	[SerializeField]
	int sim_iterations_per_frame = 1;

	[SerializeField]
	float arrow_brightness = 0.5f;

	[SerializeField]
	Image x_function_input_background;
	
	[SerializeField]
	Image y_function_input_background;

	Color default_background_input_colour = new Color(0.1886792f, 0.1886792f, 0.1886792f);
	Color highlighted_error_colour = new Color(0.6132076f, 0.2311133f, 0.1995817f);

	bool sim_mode = true; // true: velocity, false: acceloration

	void Start()
    {
		xExpression = Expression.ParseExpression("sin(y) * cos(x)");
		yExpression = Expression.ParseExpression("cos(y) * sin(x)");

		InitializeField();
	}

	void InitializeField()
	{
		vectorObjs = new GameObject[(int)(4 * (bounds.x + 1) * (bounds.y + 1) / (density * density))];
		renderers = new SpriteRenderer[(int)(4 * (bounds.x + 1) * (bounds.y + 1) / (density * density))];

		int index = 0;
		for (float x = -(int)bounds.x; x <= bounds.x; x += density)
		{
			for (float y = -(int)bounds.y; y <= bounds.y; y += density)
			{
				if (x != 0 || y != 0)
				{
					vectorObjs[index] = Instantiate(vector, new Vector3(x, y), Quaternion.identity);
					vectorObjs[index].transform.localScale = new Vector3(density, density, 1);

					GreenElephant.Vector2 v =  Function(new GreenElephant.Vector2(x, y));
					vectorObjs[index].transform.eulerAngles = new Vector3(0, 0, GreenMath.RadiansToDegrees(v.angle));

					renderers[index] = vectorObjs[index].GetComponentInChildren<SpriteRenderer>();
					renderers[index].color = Color.HSVToRGB(1 - (float)GreenMath.sigmoid(v.magnetude / magnetudeStrength), GreenMath.map(v.magnetude, 0, Mathf.Max(bounds.x, bounds.y), 0.35f, 0.85f), arrow_brightness);
					
					renderers[index].transform.localScale = new Vector3(1, 1, 1) * (2 * (float)GreenMath.sigmoid(v.magnetude) - 1) * 0.2f;
					index++;
				}
			}
		}
	}

	bool has_error = false;
	Image background_image_error_input = null;
	float t = 0;
	float error_appear_speed = 10f;
	float error_disappear_delay = 1.5f;
	void HighlightSyntaxError()
	{
		if (t < 1 / error_appear_speed)
		{
			background_image_error_input.color = Color.Lerp(default_background_input_colour, highlighted_error_colour, error_appear_speed*t);
		}
		else
		{
			background_image_error_input.color = Color.Lerp(highlighted_error_colour, default_background_input_colour, GreenMath.map(t, 1 / error_appear_speed, error_disappear_delay, 0, 1));
		}

		t += Time.deltaTime;
		if (t > error_disappear_delay)
		{
			has_error = false;
			t = 0;
		}
	}

    void Update()
    {
		if (simRunning)
			RunSimulation();

		if (has_error)
			HighlightSyntaxError();
		//matrix = new Matrix2x2(v1.x, v1.y, v2.x, v2.y);
		
/*		int index = 0;
		for (int x = -(int)bounds.x; x <= bounds.x; x++)
		{
			for (int y = -(int)bounds.y; y <= bounds.y; y++)
			{
				if (x != 0 || y != 0)
				{
					GreenElephant.Vector2 v = Function(new GreenElephant.Vector2(x, y));
					vectorObjs[index].transform.eulerAngles = new Vector3(0, 0, GreenMath.RadiansToDegrees(v.angle));
					renderers[index] = vectorObjs[index].GetComponentInChildren<SpriteRenderer>();
					renderers[index].color = Color.HSVToRGB(1 - (float)GreenMath.sigmoid(v.magnetude / magnetudeStrength), GreenMath.map(v.magnetude, 0, Mathf.Max(bounds.x, bounds.y), 0.35f, 0.85f), 1);
					index++;
				}
			}
		}*/

	}

	GreenElephant.Vector2 Function(GreenElephant.Vector2 v)
	{
		Expression.variables["x"] = v.x;
		Expression.variables["y"] = v.y;
		return new GreenElephant.Vector2(xExpression.evaluate(), yExpression.evaluate());
		//return new GreenElephant.Vector2(Mathf.Sin(v.y) * Mathf.Cos(v.x), Mathf.Cos(v.y) * Mathf.Sin(v.x));

		//float[] result = (float[])codeCompiler.RunCode(v.x, v.y);
		//return new GreenElephant.Vector2(result[0], result[1]);

		/*
				GreenElephant.Vector2 vector = new GreenElephant.Vector2();

				vector.x = -b / (2 * Mathf.PI) * (Mathf.Atan(v.y / v.x) + v.x * v.y / (2 * (1 - n) * (v.x * v.x + v.y * v.y)));

				vector.y = b / (8 * Mathf.PI * (1 - n)) * ((1 - 2 * n) * Mathf.Log(v.x * v.x + v.y * v.y) + (v.x * v.x - v.y * v.y) / (v.x * v.x + v.y * v.y));

				return vector;*/

		/*
		GreenElephant.Vector2 v1 = (v - new GreenElephant.Vector2(1, 0)).normalized;
		GreenElephant.Vector2 v2 = (v + new GreenElephant.Vector2(1, 0)).normalized;

		float ratio = v1.magnetude / (v2.magnetude + v1.magnetude);

		return v1 * ratio - v2 * (1 - ratio);*/
		//return new GreenElephant.Vector2(v.y, -Mathf.Sin(v.x));
		//return v * matrix;


		//return new GreenElephant.Vector2();
	}

	void RunSimulation()
	{
		for (int i = 0; i < sim_iterations_per_frame; i++)
		{
			GreenElephant.Vector2 v = Function(new GreenElephant.Vector2(simObj.transform.position.x, simObj.transform.position.y)) * Time.deltaTime * simSpeed / (sim_iterations_per_frame);
			if (sim_mode)
				velocity = new UnityEngine.Vector2(v.x, v.y);
			else
				velocity += new UnityEngine.Vector2(v.x, v.y);
			simObj.transform.position += (Vector3)velocity;//new Vector3(v.x, v.y);
		}
	}

	public void StartStopSim()
	{
		simRunning = !simRunning;

		switch (simRunning)
		{
			case true:
				startstop_sim_button_text.text = "stop simulation";
				break;
			case false:
				startstop_sim_button_text.text = "start simulation";
				break;
		}
	}

	public void ResetSim()
	{
		simObj.transform.position = new Vector3();
		velocity = new UnityEngine.Vector2();
	}

	public void reloadFunction()
	{
		try
		{
			xExpression = Expression.ParseExpression(xFunctionField.text);
		}
		catch(Exception e)
		{
			has_error = true;
			background_image_error_input = x_function_input_background;
			print("test");
			return;
		}

		try
		{
			yExpression = Expression.ParseExpression(yFunctionField.text);
		}
		catch
		{
			has_error = true;
			background_image_error_input = y_function_input_background;
			return;
		}


		UpdateArrows();
/*		int index = 0;
		for (float x = -(int)bounds.x; x <= bounds.x; x += density)
		{
			for (float y = -(int)bounds.y; y <= bounds.y; y += density)
			{
				if (x != 0 || y != 0)
				{
					GreenElephant.Vector2 v = Function(new GreenElephant.Vector2(x, y));
					vectorObjs[index].transform.eulerAngles = new Vector3(0, 0, GreenMath.RadiansToDegrees(v.angle));
					renderers[index] = vectorObjs[index].GetComponentInChildren<SpriteRenderer>();
					renderers[index].color = Color.HSVToRGB(1 - (float)GreenMath.sigmoid(v.magnetude / magnetudeStrength), GreenMath.map(v.magnetude, 0, Mathf.Max(bounds.x, bounds.y), 0.35f, 0.85f), arrow_brightness);
					index++;
				}
			}
		}*/
	}

	public void changeColourMagnetude(float _magnetudeStrength)
	{
		magnetudeStrength = _magnetudeStrength;
		UpdateArrows();
	}

	public void UpdateArrows()
	{
		int index = 0;
		for (float x = -(int)bounds.x; x <= bounds.x; x += density)
		{
			for (float y = -(int)bounds.y; y <= bounds.y; y += density)
			{
				if (x != 0 || y != 0)
				{
					GreenElephant.Vector2 v = Function(new GreenElephant.Vector2(x, y));
					vectorObjs[index].transform.eulerAngles = new Vector3(0, 0, GreenMath.RadiansToDegrees(v.angle));
					renderers[index] = vectorObjs[index].GetComponentInChildren<SpriteRenderer>();
					renderers[index].color = Color.HSVToRGB(1 - (float)GreenMath.sigmoid(v.magnetude / magnetudeStrength), GreenMath.map(v.magnetude, 0, Mathf.Max(bounds.x, bounds.y), 0.35f, 0.85f), arrow_brightness);
					
					renderers[index].transform.localScale = new Vector3(1, 1, 1) * (2 * (float)GreenMath.sigmoid(v.magnetude) - 1) * 0.2f;
					index++;
				}
			}
		}
	}

	public void change_sim_mode(int mode)
	{
		sim_mode = mode == 0;
	}

	public void change_sim_speed(float _speed)
	{
		simSpeed = _speed;
	}

	public void change_sim_iterations(float _iter)
	{
		sim_iterations_per_frame = (int)_iter;
	}
}
