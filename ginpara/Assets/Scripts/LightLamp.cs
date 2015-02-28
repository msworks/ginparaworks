using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightLamp : MonoBehaviour {

    public GameObject right;
    public GameObject left;

    private bool LightFlg;
    private int Counter = 0;

	// Use this for initialization
	void Start () {
        LightFlg = true;
        Counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (!LightFlg) return;

        Counter++;

        var r = (float)Counter * 3.14f / 60f * 5f;
        var v = Mathf.Sin(r) * Mathf.Sin(r);
        var v2 = 1f - v;

        right.GetComponent<UISprite>().alpha = v;
        left.GetComponent<UISprite>().alpha = v2;

	}
}
