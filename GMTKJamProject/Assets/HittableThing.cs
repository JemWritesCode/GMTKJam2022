using UnityEngine;

public class HittableThing : MonoBehaviour {
  public float healthMax = 300f;
  public float healthCurrent = 300f;

  public float onCollideAddRelativeForcePower = 300f;
  public float onCollideAddUpwardsForcePower = 200f;

  Rigidbody _rigidBody;

  void Awake() {
    _rigidBody = GetComponent<Rigidbody>();
  }

  private void OnCollisionEnter(Collision collision) {
    if (!collision.gameObject.CompareTag("Player")) {
      return;
    }

    Vector3 force = collision.contacts[0].point - transform.position;
    force = force.normalized;
    force = force * -onCollideAddRelativeForcePower + Vector3.up * onCollideAddUpwardsForcePower;

    Debug.Log($"{collision.gameObject.name} hit me with {collision.contactCount} contacts, adding force: {force}");
    _rigidBody.AddForce(force);
  }
}
