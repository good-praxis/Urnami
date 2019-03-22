using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    private Player playerScript;


    public Vector3 goalOffset;
    public Vector3 goalAngle;

    private Vector3 offset;
    private Vector3 lastPosition;

    public float rotationSpeed = 2f;
    public float cameraSpeed = 0.2f;

    private Vector3 upOffset = new Vector3(0, 0, 6);
    private Vector3 upAngle = new Vector3(-20, 0, 0);

    private Vector3 downOffset = new Vector3(0, -1, 2);
    private Vector3 downAngle = new Vector3(10, 0, 0);

    private Vector3 rightOffset = new Vector3(-2, 0, 0);
    private Vector3 rightAngle = new Vector3(0, 10, 0);

    private Vector3 leftOffset = new Vector3(2, 0, 0);
    private Vector3 leftAngle = new Vector3(0, 350, 0);

    public Vector3 cameraVelocity = Vector3.zero;
    public Vector3 offsetVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

        playerScript = player.GetComponent<Player>();
        offset = transform.position - player.transform.position;
        lastPosition = player.transform.position;

        goalOffset = offset;
        goalAngle = transform.eulerAngles;
    }

    void Update() {
        UpdateOffsetAndAngle("up", upOffset, upAngle);
        UpdateOffsetAndAngle("down", downOffset, downAngle);
        UpdateOffsetAndAngle("right", rightOffset, rightAngle);
        UpdateOffsetAndAngle("left", leftOffset, leftAngle);
    }

    void UpdateOffsetAndAngle(string key, Vector3 keyOffset, Vector3 keyAngle) {
        if (Input.GetKeyDown(key)) {
            goalOffset += keyOffset;
            goalAngle += keyAngle;
        }

        if (Input.GetKeyUp(key)) {
            goalOffset -= keyOffset;
            goalAngle -= keyAngle;
        }
    }

    void LateUpdate()
    {
        if(transform.eulerAngles != goalAngle) {
         transform.rotation =  Quaternion.Slerp(transform.rotation, Quaternion.Euler(goalAngle), rotationSpeed *  Time.deltaTime);
        }

        if (offset != goalOffset) {
            offset = Vector3.SmoothDamp(offset, goalOffset, ref offsetVelocity, cameraSpeed);
        }

        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + offset, ref cameraVelocity, cameraSpeed);
    }
}
