using Unity.VisualScripting;

using UnityEngine;

public class RedditManOnHit : MonoBehaviour {
  public CameraController cameraController;
  public GameObject player;
  public float triggerRadius = 2f;

  void Update() {
    if (Vector3.Distance(transform.position, player.transform.position) <= triggerRadius) {
      if (!alreadyPanned) {
        TogglePanToDude();
        GameManager.Instance.ToggleInvestFundsPanel(true);
      }

      if (Input.GetKeyDown(KeyCode.E)) {
        GameManager.Instance.TryToLevelUp();
      }

    } else {
      cameraController.enabled = true;
      panToDude = false;
      alreadyPanned = false;
      GameManager.Instance.ToggleInvestFundsPanel(false);
    }
  }

  bool panToDude = false;
  bool alreadyPanned = false;

  void TogglePanToDude() {
    if (alreadyPanned) {
      return;
    }

    cameraController.enabled = false;
    alreadyPanned = true;
    panToDude = true;
  }

  public float cameraFocusHeight = 1f;
  public Quaternion cameraFocusRotation = Quaternion.Euler(0f, 180f, 0f);
  public float cameraFocusDistance = 2f;

  void LateUpdate() {
    if (!panToDude) {
      return;
    }

    Vector3 position = transform.position;
    position -= cameraFocusRotation * Vector3.forward * cameraFocusDistance;
    position.y = transform.position.y + cameraFocusHeight;

    cameraController.transform.position = position;
    cameraController.transform.LookAt(transform.position + new Vector3(0, cameraFocusHeight, 0));
  }

  //void OnCollisionEnter(Collision collision) {
  //  if (!collision.gameObject.CompareTag("Player")) {
  //    return;
  //  }

  //  cameraController.cameraTarget = transform;
  //  UIManager.Instance.ToggleInvestFundsPanel(true);

  //  //Vector3 force = new(Random.Range(100f, 300f), Random.Range(100f, 300f), Random.Range(100f, 300f));
  //  //Debug.Log($"Adding torque {force} to dice.");

  //  //GameManager.Instance.diceRigidbody.AddTorque(force, ForceMode.Acceleration);
  //  //GameManager.Instance.diceRigidbody.AddForce(Vector3.up * Random.Range(100f, 200f), ForceMode.Acceleration);
  //}

  //void OnCollisionExit(Collision collision) {
  //  if (!collision.gameObject.CompareTag("Player")) {
  //    return;
  //  }

  //  cameraController.cameraTarget = collision.gameObject.transform;
  //  UIManager.Instance.ToggleInvestFundsPanel(false);
  //}
}
