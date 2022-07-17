using UnityEngine;

public class RedditManOnHit : MonoBehaviour {
  void OnCollisionEnter(Collision collision) {
    if (!collision.gameObject.CompareTag("Player")) {
      return;
    }

    Vector3 force = new(Random.Range(100f, 300f), Random.Range(100f, 300f), Random.Range(100f, 300f));
    Debug.Log($"Adding torque {force} to dice.");

    GameManager.Instance.diceRigidbody.AddTorque(force, ForceMode.Acceleration);
    GameManager.Instance.diceRigidbody.AddForce(Vector3.up * Random.Range(100f, 200f), ForceMode.Acceleration);
  }
}
