using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        StartCoroutine(DeleteBall(30f));
    }

    IEnumerator DeleteBall(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }	

    void OnDestroy()
    {
        _count--;
    }
}
