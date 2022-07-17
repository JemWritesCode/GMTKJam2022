using UnityEngine;

public class RedditManOnHit : MonoBehaviour {
  public CameraController cameraController;
  public GameObject player;
  public float triggerRadius = 75f;

  void Update() {
    if (Vector3.Distance(transform.position, player.transform.position) <= triggerRadius) {
      cameraController.cameraTarget = transform;
      UIManager.Instance.ToggleInvestFundsPanel(true);
    } else {
      cameraController.cameraTarget = player.transform;
      UIManager.Instance.ToggleInvestFundsPanel(false);
    }
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
