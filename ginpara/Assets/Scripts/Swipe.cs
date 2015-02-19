using UnityEngine;
using System.Collections;

public class Swipe : MonoBehaviour {

    public GameObject Slider;
    public GameObject DisplayHandle;
    public float power = 0.0f;

    const float HANDLE_TURNABLE = 120.0f;

    // スワイプ時処理
    void OnSwipe(SwipeGesture gesture) {

        //Debug.Log("Swipe Direction:" + gesture.Direction);
        //Debug.Log("Swipe Selection:" + gesture.StartSelection.name);
        //Debug.Log("Swipe Velocity:" + gesture.Velocity);

        // ハンドルをスワイプしたなら
        //if (gesture.StartSelection == this.gameObject)
        {
            float force = gesture.Velocity / 10000.0f;

            Debug.Log("FORCE:" + force);

            switch (gesture.Direction)
            {
                case FingerGestures.SwipeDirection.Right:
                case FingerGestures.SwipeDirection.UpperRightDiagonal:
                case FingerGestures.SwipeDirection.LowerRightDiagonal:
                    // パワーを上昇
                    power += force;
                    break;
                case FingerGestures.SwipeDirection.Left:
                case FingerGestures.SwipeDirection.UpperLeftDiagonal:
                case FingerGestures.SwipeDirection.LowerLeftDiagonal:
                    // パワーを減少
                    power -= force;
                    break;
            }

            // スライダーを調整
            Slider.GetComponent<UISlider>().value = power;

            // ハンドルを回転
            var angle = Slider.GetComponent<UISlider>().value * -HANDLE_TURNABLE;
            //DisplayHandle.transform.Rotate(0, 0, angle);
            iTween.RotateTo(DisplayHandle, iTween.Hash("z", angle, "time", 0.5f));
        }
    }

}
