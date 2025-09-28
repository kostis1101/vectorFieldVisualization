using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GreenElephant;

public class variables_UI_manager : MonoBehaviour
{

	[SerializeField]
	GameObject variable_UI;

	[SerializeField]
	GameObject variables_content_view;


	int variable_amount = 0;

	RectTransform content_view_transform;

	private void Start()
	{
		content_view_transform = variables_content_view.GetComponent<RectTransform>();
	}

	public void create_new_variable()
	{

		string new_variable_name = $"variable{variable_amount + 1}";

		Expression.variables[new_variable_name] = 0;

		GameObject variable_instance = Instantiate(variable_UI, variables_content_view.transform, false);

		//variable_instance.transform.SetParent(variable_instance.transform, false);
		variable_instance.transform.position -= new Vector3(0, variable_amount * 40);

		variable_instance.GetComponent<variable_manager>().variable_name = new_variable_name;
		content_view_transform.sizeDelta = new UnityEngine.Vector2(content_view_transform.sizeDelta.x, (variable_amount + 1) * 60 + 10);
		variable_instance.GetComponent<variable_manager>().change_name(new_variable_name);

		variable_amount++;
	}


}
