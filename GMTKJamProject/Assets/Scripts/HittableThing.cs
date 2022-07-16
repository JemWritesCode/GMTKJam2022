using System;

using UnityEngine;

public class HittableThing : MonoBehaviour {
  public float healthMax = 300f;
  public float healthCurrent = 300f;

  public float healthDamageOnCollide = 300f;

  public float onCollideAddRelativeForcePower = 300f;
  public float onCollideAddUpwardsForcePower = 200f;

  public float playerCashOffsetOnDeath = 50f;

  public event EventHandler<GameObject> OnHittableDeath;

  Rigidbody _rigidBody;

  void Awake() {
    _rigidBody = GetComponent<Rigidbody>();
  }

  private void OnCollisionEnter(Collision collision) {
    if (!collision.gameObject.CompareTag("Player")) {
      return;
    }

    if (healthCurrent <= 0f) {
      // Already dead, don't add more force... unless?
      return;
    }

    Vector3 force = collision.contacts[0].point - transform.position;
    force = force.normalized;
    force = force * -onCollideAddRelativeForcePower + Vector3.up * onCollideAddUpwardsForcePower;

    _rigidBody.AddForce(force);

    healthCurrent -= healthDamageOnCollide;

    if (healthCurrent <= 0f) {
      OnHittableDeath?.Invoke(this, this.gameObject);
      Destroy(gameObject, 3f);
    }
  }
}
