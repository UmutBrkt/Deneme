using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool right;
    public bool left;
    public float speed;
    public float rotationSpeed;
    public bool canMove;
    void Update()
    {
        if (canMove)
        {
            transform.position += transform.forward / speed;

            //// To test on PC
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.down * (rotationSpeed * Time.deltaTime));
            }
            ////
            if (right)
            {
                transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
            }
            if (left)
            {
                transform.Rotate(Vector3.down * (rotationSpeed * Time.deltaTime));
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager game = FindObjectOfType(typeof(GameManager)) as GameManager;
            game.ReTry();
        }
    }
}
