using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    private Player playerScript;

    private Vector3 offset;
    private Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<Player>();
        offset = transform.position - player.transform.position;
        lastPosition = player.transform.position;
    }

    void LateUpdate()
    {
        Vector3 movementDelta = lastPosition - player.transform.position;
        Vector3 goalPos = player.transform.position + offset;
        Vector3 fromPos = transform.position;
        Vector3 moveTo = (goalPos - fromPos) * playerScript.acceleration;
        if(moveTo != Vector3.zero) {
            transform.position = transform.position + moveTo;
        }

        lastPosition = player.transform.position;
    }
}
