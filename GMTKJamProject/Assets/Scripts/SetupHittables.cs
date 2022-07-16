using UnityEngine;

public class SetupHittables : MonoBehaviour {
  public JazzHands playerJazzHands;
  public GameObject hittableDeathExplosion;

  void Awake() {
    GameObject[] hittables = GameObject.FindGameObjectsWithTag("Hittable");
    int rigidBodyAdded = 0;
    int hittableThingAdded = 0;

    foreach (GameObject hittable in hittables) {
      if (!hittable.TryGetComponent(out Rigidbody rigidbody)) {
        rigidbody = hittable.AddComponent<Rigidbody>();
        rigidBodyAdded++;
      }

      rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;

      if (!hittable.TryGetComponent(out HittableThing hittableThing)) {
        hittableThing = hittable.AddComponent<HittableThing>();
        hittableThingAdded++;
      }

      hittableThing.OnHittableDeath += (_, hittable) => AddExplosion(hittable);
      hittableThing.OnHittableDeath += (_, _) => playerJazzHands.IncreaseHandPower(1f);
    }

    Debug.Log(
        $"Added {rigidBodyAdded} Rigidbody and {hittableThingAdded} HittableThing to {hittables.Length} Hittable.");
  }

  void AddExplosion(GameObject hittable) {
    Debug.Log($"Adding explosion to {hittable.name}");
    GameObject explosion = Instantiate(hittableDeathExplosion, hittable.transform);
    explosion.SetActive(true);
  }
}
