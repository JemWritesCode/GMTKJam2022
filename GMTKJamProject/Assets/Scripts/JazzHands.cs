using UnityEngine;

public class JazzHands : MonoBehaviour {
  public Transform leftHand;
  public Transform rightHand;

  public void SetHandsScale(float scale) {
    leftHand.transform.localScale = Vector3.one * scale;
    rightHand.transform.localScale = Vector3.one * scale;
  }
}
