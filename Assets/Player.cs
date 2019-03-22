using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 1;
    public float acceleration = 0;

    private Vector2 lastMove = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = Vector2.zero;
        if(Input.GetKey("w"))  {
            move = new Vector2(move.x, move.y + 1.0f);
        }

        if(Input.GetKey("s")) {
            move = new Vector2(move.x, move.y - 1.0f);
        }

        if(Input.GetKey("a")) {
            move = new Vector2(move.x - 1.0f, move.y);
        }

        if(Input.GetKey("d")) {
            move = new Vector2(move.x + 1.0f, move.y);
        }

        if(move != Vector2.zero) {
            acceleration = Mathf.Clamp01(acceleration + Time.deltaTime);
        } else if (move == Vector2.zero && acceleration > 0) {
            acceleration = Mathf.Clamp01(acceleration - (Time.deltaTime * 3));
            move = lastMove;
        }
        
        lastMove = move;
        move = move.normalized * Time.deltaTime * speed * acceleration;
        Vector3 newPosition = new Vector3(transform.position.x + move.x, transform.position.y, transform.position.z + move.y);
        transform.position = newPosition;
    }
}
