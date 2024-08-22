using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    /*
     * Do not make the destination another teleporter pad.
     * This can cause a loop because the pad will become active
     * when the Player enters it.
     * Also, add half of the player's height to the Y value
     * so that the player doesn't materialize inside the floor.
    */
    [SerializeField]
    private Vector3 _teleportDestination;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = _teleportDestination;
            // Set current velocity to 0, so player isn't moving after teleport
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
