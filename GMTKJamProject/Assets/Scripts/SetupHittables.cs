using UnityEngine;

public class SetupHittables : MonoBehaviour {
  public JazzHands playerJazzHands;
  public GameObject hittableDeathExplosion;

  GameManager _gameManager;

  void Awake() {
    _gameManager = GameManager.Instance;

    GameObject[] hittables = GameObject.FindGameObjectsWithTag("Hittable");
    int rigidBodyAdded = 0;
    int hittableThingAdded = 0;

    foreach (GameObject hittable in hittables) {
      if (!hittable.TryGetComponent(out Rigidbody rigidbody)) {
        rigidbody = hittable.AddComponent<Rigidbody>();
        rigidBodyAdded++;
      }

      rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;

      if (!hittable.TryGetComponent(out HittableThing thing)) {
        thing = hittable.AddComponent<HittableThing>();
        thing.playerHandsPowerOffsetOnDeath = Random.Range(0.25f, 0.75f);
        thing.playerCashOffsetOnDeath = Random.Range(50f, 150f);
        hittableThingAdded++;
      }

      thing.OnHittableDeath += (_, hittable) => AddExplosion(hittable);
      thing.OnHittableDeath += (_, _) => _gameManager.OffsetPlayerHandsPower(thing.playerHandsPowerOffsetOnDeath);
      thing.OnHittableDeath += (_, _) => _gameManager.OffsetPlayerCash(thing.playerCashOffsetOnDeath);
    }

    Debug.Log(
        $"Added {rigidBodyAdded} Rigidbody and {hittableThingAdded} HittableThing to {hittables.Length} Hittable.");
  }

  void AddExplosion(GameObject hittable) {
    Debug.Log($"Adding explosion to {hittable.name}");
    GameObject explosion = Instantiate(hittableDeathExplosion, hittable.transform.transform);
    explosion.SetActive(true);
    Destroy(explosion, 3f);
  }
}
