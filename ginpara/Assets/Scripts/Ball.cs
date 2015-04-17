using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    static private int _count = 0;

    static public int Count
    {
        get
        {
            return _count;
        }
    }

	void Start () {
        _count++;
	}
	
    void OnDestroy()
    {
        _count--;	
	}
}
