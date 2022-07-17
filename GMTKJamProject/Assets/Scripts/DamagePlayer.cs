using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    float dmgDealtToPlayer = -20f;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("A particle collided with the player.");
        GameManager.Instance.OffsetPlayerCash(dmgDealtToPlayer);
    }
}
