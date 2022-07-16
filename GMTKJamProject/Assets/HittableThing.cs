using System.Linq;

using UnityEngine;

public class HittableThing : MonoBehaviour {
  public float healthMax = 300f;
  public float healthCurrent = 300f;

  public float healthDamageOnCollide = 150f;

  public float onCollideAddRelativeForcePower = 300f;
  public float onCollideAddUpwardsForcePower = 200f;

  Rigidbody _rigidBody;
  GameObject _explosion;

  void Awake() {
    _rigidBody = GetComponent<Rigidbody>();
    _explosion =
        FindObjectsOfType<ParticleSystem>(includeInactive: true)
            .Where(ps => ps.name == "HittableExplosion")
            .Select(ps => ps.gameObject).FirstOrDefault();

    if (!_explosion) {
      Debug.LogError($"Could not find _explosion.");
    }
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

    healthCurrent -= healthDamageOnCollide;

    if (healthCurrent <= 0f && _explosion) {
      Debug.Log($"Adding explosion");
      GameObject explosion = Instantiate(_explosion, transform);
      explosion.SetActive(true);
      Destroy(gameObject, 2f);
    }
  }
}
