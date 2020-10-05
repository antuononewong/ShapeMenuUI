using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

/* Script for handling user in put with a dropdown menu picker for generic
 * Unity shape and input fields to position/name the desired shape.
 */

public class ShapesMenuManager : MonoBehaviour
{
	// Input GameObjects
	public GameObject shapePicker;
	public GameObject background;
	public GameObject xInput;
	public GameObject yInput;
	public GameObject zInput;
	public GameObject nameInput;

	// Input fields
	private TMP_Dropdown menu;
	private TMP_InputField x;
	private TMP_InputField y;
	private TMP_InputField z;
	private TMP_InputField shapeName;

	private GameObject shape;

	void Start()
	{
		gameObject.SetActive(false); // Disable menu at start up, button in top right will active the menu

		menu = shapePicker.GetComponent<TMP_Dropdown>();
		x = xInput.GetComponent<TMP_InputField>();
		y = yInput.GetComponent<TMP_InputField>();
		z = zInput.GetComponent<TMP_InputField>();
		shapeName = nameInput.GetComponent<TMP_InputField>();
	}

	//  Debug function to print all drop down menu options to console
	public void PrintMenuOption()
	{
		int menuIndex = menu.value;
		List<TMP_Dropdown.OptionData> menuOptions = menu.options;
		string text = menuOptions[menuIndex].text;

		Debug.Log(text);
	}

	// Check for valid user input, then create shape based on inputted values. Closes menu after creation
	public void AddShape()
	{

		if (float.TryParse(x.text, out float xValue) && float.TryParse(y.text, out float yValue) && float.TryParse(z.text, out float zValue))
		{
			if (xValue > 0 && yValue > 0 && zValue > 0)
			{
				Vector3 size = new Vector3(xValue, yValue, zValue);
				CreateShape(GetShapeOption(), size);
				gameObject.SetActive(false);
				background.SetActive(false);
			}
		}
	}

	// Gets the currently selected shape option from dropdown list
	private string GetShapeOption()
	{
		int menuIndex = menu.value;
		List<TMP_Dropdown.OptionData> menuOptions = menu.options;
		return menuOptions[menuIndex].text; 
	}

	// Creates shape based on inputted values
	private void CreateShape(string shapeText, Vector3 size)
	{
		switch (shapeText)
		{
			case "Cube":
				shape = GameObject.CreatePrimitive(PrimitiveType.Cube);
				break;
			case "Cylinder":
				shape = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
				break;
			case "Sphere":
				shape = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				break;
		}

		shape.transform.position = Vector3.zero;
		shape.transform.localScale = size;
		if (shapeName.text != "") 
		{
			shape.name = shapeName.text;
		}

	}
}
