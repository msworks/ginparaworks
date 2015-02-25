using UnityEngine;
using System.Collections;

public class SpinFusya : MonoBehaviour {

    public GameObject Fusya;
    public string AnimationName;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Fusya.GetComponent<Animation>().Play(AnimationName);
    }

}
