using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCtrl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager game = FindObjectOfType(typeof(GameManager)) as GameManager;
            game.ReTry();
        }
    }
}
