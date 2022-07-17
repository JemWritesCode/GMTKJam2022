using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] float dmgDealtToPlayer = 20f;
    GameManager gameManager;
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("A particle collided with the player.");
        gameManager.OffsetPlayerCash(dmgDealtToPlayer);
    }
}
