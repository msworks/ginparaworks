using UnityEngine;
using System.Collections;

/// <summary>
/// ウェブボタン
/// </summary>
public class WebButton : MonoBehaviour {

    public UISprite lightButton;

    private WebViewObject webView;

    /// <summary>
    /// タップ時処理
    /// </summary>
    public void OnClick()
    {
        StartCoroutine(light());

        Debug.Log("Request Web View");
        var url = "http://www.yahoo.co.jp/";
        var webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init((msg) =>
        {
            if (msg == "clicked")
            {
                webViewObject.SetVisibility(false);
            }
        });
        webViewObject.LoadURL(url);
        webViewObject.SetMargins(50, 100, 50, 50);
        webViewObject.SetVisibility(true);
        webViewObject.EvaluateJS(
            "window.addEventListener('load', function() {" +
            "   window.addEventListener('click', function() {" +
            "       Unity.call('clicked');" +
            "   }, false);" +
            "}, false);");
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
