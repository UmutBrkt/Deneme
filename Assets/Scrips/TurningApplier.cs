using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TurningApplier : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerMove[] players;
    public bool left;
    public bool right;
    private void Start()
    {
        players = FindObjectsOfType(typeof (PlayerMove)) as PlayerMove[];
       
    }
    public void OnPointerDown(PointerEventData eventData)//right and left turning control
    {
        if (right == true)
        {
            foreach (PlayerMove player in players)
            {
                player.right = true;
            }
        }
        if (left == true)
        {
            foreach (PlayerMove player in players)
            {
                player.left = true;
            }
        }

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        
            foreach (PlayerMove player in players)
            {
                player.right = false;
                player.left = false;
            }
        
    }
}
