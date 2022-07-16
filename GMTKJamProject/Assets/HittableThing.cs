using UnityEngine;

public class HittableThing : MonoBehaviour {
  public float AddRelativeForceOnCollideMultiplier = 300f;
  public float AddUpwardsForceOnCollideMultiplier = 200f;

  Rigidbody _rigidBody;

  void Awake() {
    _rigidBody = GetComponent<Rigidbody>();
  }

  private void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("Player")) {
      Vector3 force = collision.contacts[0].point - transform.position;
      force = -force.normalized;
      force = force * AddRelativeForceOnCollideMultiplier + Vector3.up * AddUpwardsForceOnCollideMultiplier;

      Debug.Log($"{collision.gameObject.name} hit me with {collision.contactCount} contacts, adding force: {force}");

      _rigidBody.AddForce(force);
    }
  }
}
