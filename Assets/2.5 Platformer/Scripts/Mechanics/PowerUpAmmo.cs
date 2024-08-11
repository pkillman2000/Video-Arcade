using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAmmo : MonoBehaviour
{
    [SerializeField]
    private int _ammo = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerCombat playerCombat = collision.gameObject.GetComponent<PlayerCombat>();
            playerCombat.ReloadMissiles(_ammo);
            Destroy(this.gameObject);
        }
    }
}
