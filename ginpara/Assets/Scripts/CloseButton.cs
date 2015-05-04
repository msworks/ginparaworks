using UnityEngine;
using System;
using System.Collections;

public class CloseButton : MonoBehaviour {

    public GameObject WebButton;

    public void OnClick()
    {
        if (WebButton.GetComponent<WebButton>().webView)
        {
            WebButton.GetComponent<WebButton>().webView.SetVisibility(false);
        }
        this.gameObject.SetActive(false);
    }
}
