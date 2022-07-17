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

  float playerCash = 0f;
  int playerHandsLevel = 0;
  float playerHandsPower = 0f;

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
    SetPlayerHandsPower(0f);
    SetPlayerHandsLevel(0);
  }

  public void SetPlayerCash(float cash) {
    playerCash = cash;
    UIManager.Instance.SetFundsAmount(playerCash);
  }

  public void OffsetPlayerCash(float offset) {
    SetPlayerCash(playerCash + offset);
  }

  public void SetPlayerHandsPower(float power) {
    playerHandsPower = power;

    // TODO: lol.
    playerJazzHands.SetHandsScale(power);

    UIManager.Instance.SetHandsLevel(
        handsLevelNames[Mathf.Clamp(playerHandsLevel, 0, handsLevelNames.Count - 1)], playerHandsPower);
  }

  public void OffsetPlayerHandsPower(float offset) {
    SetPlayerHandsPower(playerHandsPower + offset);
  }

  public void SetPlayerHandsLevel(int level) {
    playerHandsLevel = level;

    UIManager.Instance.SetHandsLevel(
        handsLevelNames[Mathf.Clamp(playerHandsLevel, 0, handsLevelNames.Count - 1)], playerHandsPower);
  }
}
