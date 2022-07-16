using UnityEngine;

public class SetupHittables : MonoBehaviour {
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

      if (!hittable.TryGetComponent(out HittableThing _)) {
        hittable.AddComponent<HittableThing>();
        hittableThingAdded++;
      }
    }

    Debug.Log(
        $"Added {rigidBodyAdded} Rigidbody and {hittableThingAdded} HittableThing to {hittables.Length} Hittable.");
  }
}
