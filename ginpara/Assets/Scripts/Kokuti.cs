using UnityEngine;
using System.Collections;

/// <summary>
/// 告知クラス
/// </summary>
public class Kokuti : MonoBehaviour {

    private static Kokuti _instance;

    private UITexture flash;

    public static Kokuti Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
        flash = this.gameObject.transform.FindChild("TaiyoFlash").GetComponent<UITexture>();
    }

    public void KokutiActionA()
    {
        StartCoroutine(enumKokutiActionA());
    }

    private IEnumerator enumKokutiActionA()
    {
        AudioManager.Instance.PlaySE(21, 0.2f);

        var count = 0f;
        var alpha = 0f;
        flash.alpha = alpha;

        while (count < 1f)
        {
            alpha = Mathf.Abs(Mathf.Sin(count * 30)*Mathf.Sin(count*30)*3);
            flash.alpha = alpha;
            count += Time.deltaTime;
            yield return null;
        }

        flash.alpha = 0f;
    }

    public void KokutiActionB()
    {
        StartCoroutine(enumKokutiActionB());
    }

    private IEnumerator enumKokutiActionB()
    {
        AudioManager.Instance.PlaySE(21, 0.2f);

        var count = 0f;
        var alpha = 0f;
        flash.alpha = alpha;

        while (count < 2f)
        {
            alpha = Mathf.Abs(Mathf.Sin(count*5));
            flash.alpha = alpha;
            count += Time.deltaTime;
            yield return null;
        }

        flash.alpha = 0f;
    }
}
