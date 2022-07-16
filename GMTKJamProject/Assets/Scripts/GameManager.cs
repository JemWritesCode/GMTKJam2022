using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour {
  public static GameManager Instance { get; private set; }

  public JazzHands playerJazzHands;

  public float handsPowerInitial = 1f;
  public float handsPowerGrowth = 1.5f;

  public List<string> handsLevelNames =
      new() {
        "Can't hold anything",
        "Wet paper hands",
        "Paper hands",
        "Wood hands",
        "Bronze hands",
        "Silver hands",
        "Gold hands",
        "Diamond hands"
      };

  float _playerCash = 0f;
  int _playerHandsLevel = 1;
  float _playerHandsPower = 0f;

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
    SetPlayerHandsPower(1f);
  }

  public void SetPlayerCash(float cash) {
    _playerCash = cash;
    UIManager.Instance.SetFundsAmount(_playerCash);
  }

  public void OffsetPlayerCash(float offset) {
    SetPlayerCash(_playerCash + offset);
  }

  public void SetPlayerHandsPower(float power) {
    _playerHandsPower = power;

    // TODO: lol.
    playerJazzHands.SetHandsScale(power);

    UIManager.Instance.SetHandsLevel(
        handsLevelNames[Mathf.Clamp(_playerHandsLevel, 0, handsLevelNames.Count - 1)], _playerHandsPower);
  }

  public void OffsetPlayerHandsPower(float offset) {
    SetPlayerHandsPower(_playerHandsPower + offset);
  }

  public void SetPlayerHandsLevel(int level) {
    _playerHandsLevel = level;

    UIManager.Instance.SetHandsLevel(
        handsLevelNames[Mathf.Clamp(_playerHandsLevel, 0, handsLevelNames.Count - 1)], _playerHandsPower);
  }
}
