using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GreenElephant;
using TMPro;
using UnityEngine.UI;

public class variable_manager : MonoBehaviour
{

	[HideInInspector]
	public string variable_name = string.Empty;

	[SerializeField]
	TMP_InputField input_name_field;


	[SerializeField]
	Slider value_slider;

	[SerializeField]
	TMP_InputField value_input_field;

	manager manager;

	private void Start()
	{
		manager = FindObjectOfType<manager>();
	}


	public void change_name(string _name)
	{
		if (!Expression.variables.ContainsKey(_name) || variable_name == _name)
		{
			float value = Expression.variables[variable_name];

			Expression.variables.Remove(variable_name);
			//Expression.variables.Add(_name, value);
			Expression.variables[_name] = value;

			variable_name = _name;

			input_name_field.text = _name;
		}
	}

	public void change_value(float _value)
	{
		Expression.variables[variable_name] = _value;
		if (_value != 0)
			value_input_field.text = string.Format("{0:.##}", _value);
		else
			value_input_field.text = "0";
	}

	public void change_value(string string_to_parse)
	{
		if (string_to_parse != "-")
		{
			float _value = GreenMath.ParseFloat(string_to_parse);
			value_slider.value = _value;
			change_value(_value);
		}
	}

	public void update_graph()
	{
		manager.UpdateArrows();
	}
}
