using UnityEngine;

public class JazzHands : MonoBehaviour {
  public Transform leftHand;
  public Transform rightHand;

  public void SetHandsScale(float scale) {
    leftHand.transform.localScale = Vector3.one * scale;
    rightHand.transform.localScale = Vector3.one * scale;
  }

  public Animator animator;

  void Awake() {
    if (!animator) {
      animator = GetComponent<Animator>();
    }
  }

  void Update() {
    if (Input.GetMouseButtonDown(0) && !IsPlaying(1, "Wave")) {
      animator.SetTrigger("Wave");
    }
  }

  bool IsPlaying(int layerIndex, string stateName) {
    return
        animator.GetCurrentAnimatorStateInfo(layerIndex).IsName(stateName)
        && animator.GetCurrentAnimatorStateInfo(layerIndex).normalizedTime < 1.0f;
  }
}
