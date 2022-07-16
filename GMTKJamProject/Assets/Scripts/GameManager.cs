using UnityEngine;

public class GameManager : MonoBehaviour {
  public static GameManager Instance { get; private set; }

  float _playerCash = 0f;

  void Awake() {
    if (Instance && Instance != this) {
      Debug.LogError($"Duplicate {name} singleton instantiated. Destroying.");
      Destroy(this);
    } else {
      Instance = this;
    }
  }

  void Start() {
    SetPlayerCash(0f);
  }

  public void SetPlayerCash(float cash) {
    _playerCash = cash;
    UIManager.Instance.SetFundsAmount(_playerCash);
  }

  public void OffsetPlayerCash(float offset) {
    SetPlayerCash(_playerCash + offset);
  }
}
