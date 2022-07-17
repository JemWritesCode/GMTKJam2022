using UnityEngine;

public class RespawnAtStart : MonoBehaviour {
  public Vector3 startPosition;
  public float minPositionY = 0f;

  void Awake() {
    startPosition = transform.position + new Vector3(0f, 2f, 0f);
  }

  void Update() {
    if (transform.position.y <= minPositionY) {
      transform.position = startPosition;
    }
  }
}
