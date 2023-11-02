using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCameraDetection : MonoBehaviour
{
    private GameObject player;
    private PlayerDetected pd;

    [SerializeField] private float maxDistance = 25f;

    [SerializeField] private LayerMask cameraMask;

    //on awake, get player
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pd = player.GetComponent<PlayerDetected>();
    }

    /*
     * When the player enters the trigger,
     * a raycast will see if the camera can see the player
     * if it can, calls HandleDetection();
     */
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            RaycastHit hit;

            Vector3 raycastOrigin = transform.position;
            Vector3 playerDirection = (player.transform.position - gameObject.transform.position).normalized;
            raycastOrigin = raycastOrigin + playerDirection;

            if (Physics.Raycast(raycastOrigin, playerDirection, out hit, maxDistance, cameraMask, QueryTriggerInteraction.Ignore))
            {
                if (hit.collider.gameObject == player)
                {
                    pd.HandleDetection();
                }
            }
        }
    }
}
