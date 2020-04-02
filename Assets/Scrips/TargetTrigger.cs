using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    GameManager game;
    private void Start()
    {
        game = FindObjectOfType(typeof(GameManager)) as GameManager;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            game.Game();
            other.tag = "Dead";
            other.GetComponent<Collider>().isTrigger = true;
        }

    }
}
