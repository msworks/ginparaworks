using UnityEngine;

/// <summary>
/// スマホを暗転させない機能
/// </summary>
public class Init : MonoBehaviour
{
	void Start () {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;	
	}
}
