using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region vars
    public PlayerMove[] players;
    public GameObject[] deadPoints;
    public GameObject[] enterancePoints;
    public GameObject enterance;
    public GameObject target;
    public GameObject playButt;
    public Text timerTxt;
    public float time;
    public float resetTime;
    string tempTimer;
    public int nextSceneIndex;
    GameObject temp;
    int index=0;
    #endregion
    void Start()
    {
        players = FindObjectsOfType(typeof(PlayerMove)) as PlayerMove[];
        foreach(PlayerMove player in players)
        {
            player.GetComponentInChildren<MeshRenderer>().enabled = false;
            player.GetComponentInChildren<Collider>().enabled = false;
            player.GetComponent<PlayerMove>().canMove = false;
        }
        temp = players[index].gameObject;
        StartMove();
    }

    void Update()
    {
        tempTimer = string.Format("{0:00}", time);
        time -= 1 * Time.deltaTime;
        timerTxt.text = tempTimer;
        if (time <= 0)
        {
            ReTry();
        }
    }
    public void PlayGame() //Starts time and controls
    {
        playButt.SetActive(false);
        Time.timeScale = 1;
        temp.GetComponent<PlayerMove>().canMove = true;
    }
    public void Game()//When reache to target changes car/enterance/target
    {
        int tempLength = players.Length;
        temp.GetComponent<PlayerMove>().canMove = false;
        index+=1;
        Debug.Log(index);

        if(index<tempLength)
        temp = players[index].gameObject;

        StartMove();
    }
    void StartMove()//prepares scene to next step
    {
        int tempLength = players.Length;
        if (index == tempLength)
        {
            SceneManager.LoadScene(nextSceneIndex);
            index = 0;
        }

        if (enterancePoints[index] != null)
        {
            enterance.transform.position = enterancePoints[index].transform.position;
            enterance.transform.rotation = enterancePoints[index].transform.rotation;
        }
        temp.transform.position = enterance.transform.position;
        temp.transform.rotation = enterance.transform.rotation;
        temp.GetComponentInChildren<MeshRenderer>().enabled = true;
        temp.GetComponentInChildren<Collider>().enabled = true;

        if(deadPoints[index]!=null)
        target.transform.position = deadPoints[index].transform.position;

        
        ResetTimer();
        playButt.SetActive(true);
        Time.timeScale = 0;
        
    }
    public void ReTry()//when hits others
    {
        temp.transform.position = enterance.transform.position;
        temp.transform.rotation = enterance.transform.rotation;
        temp.GetComponent<PlayerMove>().canMove = false;
        ResetTimer();
        playButt.SetActive(true);
        Time.timeScale = 0;
    }
    void ResetTimer()
    {
        time = resetTime;
    }
}
