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

  public float playerCash = 0f;
  public int playerHandsLevel = 0;
  public float playerHandsPower = 0f;

  public float handsLevelUpCost = 0f;

  public Rigidbody diceRigidbody;

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

  public void TryToLevelUp() {
    if (playerCash < handsLevelUpCost) {
      Debug.Log($"Not enough cash.");
      return;
    }

    Debug.Log($"Enough cash.");

    OffsetPlayerCash(-handsLevelUpCost);
    SetPlayerHandsLevel(playerHandsLevel + 1);
    SetPlayerHandsPower(playerHandsLevel * 1f);
    handsLevelUpCost = GetLevelUpCost(playerHandsLevel);
    SetupInvestFundsPanel();

    Debug.Log($"Player level now: {playerHandsLevel}");
  }

  public void ToggleInvestFundsPanel(bool toggle) {
    if (toggle) {
      SetupInvestFundsPanel();
    }

    UIManager.Instance.ShowInvestFundsPanel(toggle);
  }

  void SetupInvestFundsPanel() {
    string text =
        $"Buy <color=green>{GetLevelUpPrompTextStock(playerHandsLevel)}</color> "
            + $"for $<color=red>{handsLevelUpCost}</color>?\n";

    text += playerCash < handsLevelUpCost ? "Not enough tendies. :(" : "#yolo [e]";

    UIManager.Instance.SetInvestFundsPromptText(text);
  }

  // For easy adjustment per level.
  static float GetLevelUpCost(int level) {
    return level switch {
      0 => 0f,
      1 => 100f,
      2 => 200f,
      3 => 300f,
      4 => 400f,
      5 => 500f,
      6 => 600f,
      7 => 700f,
      _ => 888f,
    };
  }

  static string GetLevelUpPrompTextStock(int level) {
    return level switch {
      0 => "free hands",
      1 => "AMC",
      2 => "BBBY",
      3 => "NOK",
      4 => "KOSS",
      5 => "BB",
      6 => "SPCE",
      7 => "GME",
      _ => "???",
    };
  }
}
