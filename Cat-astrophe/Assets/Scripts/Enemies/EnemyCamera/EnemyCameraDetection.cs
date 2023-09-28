using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCameraDetection : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private float maxDistance = 25;

    //on awake, get player
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    /*
     * When the player enters the trigger,
     * a raycast will see if the camera can see the player
     * if it can... we will figure that out later
     */
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            RaycastHit hit;

            Vector3 raycastOrigin = transform.position;
            raycastOrigin.z = raycastOrigin.z + 1;

            Vector3 playerDirection = (player.transform.position - gameObject.transform.position).normalized;

            if (Physics.Raycast(raycastOrigin, playerDirection, out hit, maxDistance))
            {
                //Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject == player)
                {
                    Debug.Log("see player");
                }
            }
        }
    }
}
