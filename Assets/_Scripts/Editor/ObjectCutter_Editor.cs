using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectCutter))]
public class ObjectCutter_Editor : Editor {

	ObjectCutter t;

	void OnEnable()
	{
		if( t != null )
			return;
		t = target as ObjectCutter;
	}
	private void OnSceneGUI( )
	{
		if( t == null )
			return;
		
		Handles.BeginGUI();
		/////////////////
		GUILayout.BeginArea (new Rect (Screen.width - 130, Screen.height / 2 - 20, 130, 40));
		// Create a button that slices the current object in 8 pieces
		if (GUILayout.Button ("Slice Object in 8", GUILayout.Width (120), GUILayout.Height (40))) {
			// Create a parent object to put all the fragments in
			GameObject Parent = new GameObject ();
			Parent.transform.position = t.transform.position;
			Parent.name = t.name;
			// Execute the slice method on the original gameobject with a depth value
			t.SliceGameobject (4, Parent.transform);
		}
		GUILayout.EndArea ();
		/////////////////
		Handles.EndGUI ();


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
