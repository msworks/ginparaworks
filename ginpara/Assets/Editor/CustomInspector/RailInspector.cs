using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Rail))]
public class RailInspector : Editor {
	public override void OnInspectorGUI ()
	{
		GUILayout.Label("弄らせない為、CustomInspectorにて隠蔽\n");
	}
}
