using UnityEngine;

public class JazzHands : MonoBehaviour {
  public Transform leftHand;
  public Transform rightHand;

  [Range(1f, 10f)]
  public float handPower = 1f;

  public void SetHandPower(float power) {
    handPower = power;
    UpdateHands();
  }

  void UpdateHands() {
    leftHand.localScale = Vector3.one * handPower;
    rightHand.localScale = Vector3.one * handPower;
  }

  void Awake() {
    UpdateHands();
  }
}
