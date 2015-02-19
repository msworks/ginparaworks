using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour {

    public float ScrollSpeed = 0.05f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<UIScrollView>().Scroll(ScrollSpeed * Time.deltaTime);
	}
}
