using UnityEngine;

public class JazzHands : MonoBehaviour {
  public Transform leftHand;
  public Transform rightHand;

  public float handPowerLevel = 1f;
  public float handPowerInitial = 1f;
  public float handPowerLevelGrowth = 1.5f;

  float _handPower = 1f;

  public void IncreaseHandPower(float levelOffset) {
    handPowerLevel += levelOffset;
    _handPower = handPowerInitial + handPowerLevelGrowth * Mathf.Log10(handPowerLevel);
    Debug.Log($"HandPower is now: {_handPower}");
    UpdateHands();
  }

  void UpdateHands() {
    leftHand.localScale = Vector3.one * _handPower;
    rightHand.localScale = Vector3.one * _handPower;
  }

  void Awake() {
    _handPower = handPowerInitial;
    UpdateHands();
  }
}
