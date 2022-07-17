using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class UIManager : MonoBehaviour {
  public static UIManager Instance { get; private set; }

  public TMP_Text fundsAvailableText;
  public TMP_Text fundsAmountText;
  public TMP_Text handsLevel;

  public GameObject investFundsPanel;
  public TMP_Text investFundsPromptText;

  void Awake() {
    if (Instance && Instance != this) {
      Debug.LogError($"Duplicate {name} singleton instantiated. Destroying.");
      Destroy(this);
    } else {
      Instance = this;
    }
  }

  void Start() {
    ToggleInvestFundsPanel(false);
  }

  public void SetFundsAmount(float amount) {
    fundsAmountText.SetText($"${amount:F0}");
  }

  public void SetHandsLevel(string name, float rawValue) {
    handsLevel.SetText($"{name} ({rawValue:F2})");
  }

  public void ToggleInvestFundsPanel(bool toggle) {
    investFundsPanel.SetActive(toggle);
  }

  public void SetInvestFundsPromptText(string text) {
    investFundsPromptText.SetText(text);
  }
}
