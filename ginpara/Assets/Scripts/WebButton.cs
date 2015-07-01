﻿using UnityEngine;
using System.Collections;

/// <summary>
/// ウェブボタン
/// </summary>
public class WebButton : MonoBehaviour {

    public UISprite lightButton;
    public GameObject CloseButton;

    public WebViewObject webView;

    void Start()
    {
        Debug.Log("Request Web View");
        var url = "http://web.ee-gaming.net/game/menu1.html";
        var webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init((msg) =>
        {
            if (msg == "clicked")
            {
                // webViewObject.SetVisibility(false);
            }

            if (msg.Contains("submit"))
            {
                Application.LoadLevel("Main");
            }
        });

        webViewObject.LoadURL(url);
        webViewObject.SetMargins(0, 100, 100, 50);
        webViewObject.EvaluateJS(
            "window.addEventListener('load', function() {" +
            "   window.addEventListener('click', function() {" +
            "       Unity.call('clicked');" +
            "   }, false);" +
            "}, false);");

        webView = webViewObject;

    }

    /// <summary>
    /// タップ時処理
    /// </summary>
    public void OnClick()
    {
        // アプリをポーズ状態にする
        //GameManager.Instance.PauseState = GameManager.PAUSE_STATE.PAUSE;

        CloseButton.SetActive(true);
        StartCoroutine(light());

        if (webView != null)
        {
            webView.SetVisibility(true);
        }
    }

    IEnumerator light()
    {
        var totalTime = 0.5f;
        var count = 0.0f;
        lightButton.alpha = 1.0f;

        while (count < totalTime)
        {
            count += Time.deltaTime;
            lightButton.alpha = 1.0f - count / totalTime;
            yield return null;
        }

        lightButton.alpha = 0.0f;

        yield return null;
    }

}
