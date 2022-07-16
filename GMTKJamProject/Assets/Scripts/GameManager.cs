using UnityEngine;

public class GameManager : MonoBehaviour {
  public static GameManager Instance { get; private set; }

  void Awake() {
    if (Instance && Instance != this) {
      Debug.LogError($"Duplicate {name} singleton instantiated. Destroying.");
      Destroy(this);
    } else {
      Instance = this;
    }
  }
}
