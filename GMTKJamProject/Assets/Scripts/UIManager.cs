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
}
