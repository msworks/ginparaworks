using UnityEngine;
using System.Collections;

public class TapTest : MonoBehaviour {

    public void OnTap()
    {
        this.GetComponent<PlayMakerFSM>().SendEvent("Tap");
    }

}
