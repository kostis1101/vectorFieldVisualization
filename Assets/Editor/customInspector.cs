using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(manager))]
public class customInspector : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		manager manager = (manager)target;
		if (!manager.simRunning)
		{
			if (GUILayout.Button("Start Sim"))
			{
				manager.StartStopSim();
			}
		}
		else
		{
			if (GUILayout.Button("Stop Sim"))
			{
				manager.StartStopSim();
			}
		}
		if (GUILayout.Button("Reset Sim"))
		{
			manager.ResetSim();
		}
	}
}
