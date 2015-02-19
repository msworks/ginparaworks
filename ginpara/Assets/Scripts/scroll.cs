using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<UIScrollView>().Scroll(5f * Time.deltaTime);
	}
}
