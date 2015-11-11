using UnityEngine;

public class TapTest : MonoBehaviour
{
    public void OnClick()
    {
        this.GetComponent<PlayMakerFSM>().SendEvent("Tap");
    }
}
