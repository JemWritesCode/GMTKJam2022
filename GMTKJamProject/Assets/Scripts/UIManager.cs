using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class UIManager : MonoBehaviour {
  public static UIManager Instance { get; private set; }

  public TMP_Text fundsAvailableText;
  public TMP_Text fundsAmountText;
  public TMP_Text handsLevel;

  void Awake() {
    if (Instance && Instance != this) {
      Debug.LogError($"Duplicate {name} singleton instantiated. Destroying.");
      Destroy(this);
    } else {
      Instance = this;
    }
  }

  public void SetFundsAmount(float amount) {
    fundsAmountText.SetText($"${amount:F0}");
  }

  public void SetHandsLevel(string name, float rawValue) {
    handsLevel.SetText($"{name} ({rawValue:F2})");
  }
}
