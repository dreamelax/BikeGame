using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DOODAD
public class GameManager : MonoBehaviour
{
    // SETTINGS
    private int playerNum;
    // ["A","D","W"] = 1 player with A to turne left, D to turn right, W to boost
    // ["A","D","W","left","right","up"] = 2 players, player 1 has A to left, D to right, W to boost. player 2 has ye self-explainitory
    private static string[] playerkeybinds; 
    private List <GameObject> players = new List<GameObject>();
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;


    // Start is called before the first frame update
    void Start()
    {
        playerNum = 2;
        playerkeybinds = new string[6];
        playerkeybinds[0] = "a"; playerkeybinds[1] = "d"; playerkeybinds[2] = "w";
        playerkeybinds[3] = "left"; playerkeybinds[4] = "right"; playerkeybinds[5] = "up";
        resetGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // RESET GAME
    public void resetGame(){
        if(playerNum == 2){
            GameObject p1 = Instantiate (Resources.Load("player", typeof(GameObject))) as GameObject;
            GameObject p2 = Instantiate (Resources.Load("player", typeof(GameObject))) as GameObject;
            players.Add(p1);
            players.Add(p2);
            p1.GetComponent<PlayerMovement>().setKeyBinds(playerkeybinds[0], playerkeybinds[1], playerkeybinds[2]);
            p2.GetComponent<PlayerMovement>().setKeyBinds(playerkeybinds[3], playerkeybinds[4], playerkeybinds[5]);
            p1.transform.position = spawn1.transform.position;
            p2.transform.position = spawn2.transform.position;
            Vector3 vRot = new Vector3(0,0,180);
            p1.transform.Rotate(vRot, Space.Self);
        }
        else if(playerNum == 3){
            GameObject p1 = Instantiate (Resources.Load("player", typeof(GameObject))) as GameObject;
            GameObject p2 = Instantiate (Resources.Load("player", typeof(GameObject))) as GameObject;
            GameObject p3 = Instantiate (Resources.Load("player", typeof(GameObject))) as GameObject;
            players.Add(p1);
            players.Add(p2);
            players.Add(p3);
            p1.GetComponent<PlayerMovement>().setKeyBinds(playerkeybinds[0], playerkeybinds[1], playerkeybinds[2]);
            p1.GetComponent<PlayerMovement>().setKeyBinds(playerkeybinds[3], playerkeybinds[4], playerkeybinds[5]);
            p1.GetComponent<PlayerMovement>().setKeyBinds(playerkeybinds[7], playerkeybinds[7], playerkeybinds[8]);
        }   
        else if(playerNum == 4){
            GameObject p1 = Instantiate (Resources.Load("player", typeof(GameObject))) as GameObject;
            GameObject p2 = Instantiate (Resources.Load("player", typeof(GameObject))) as GameObject;
            GameObject p3 = Instantiate (Resources.Load("player", typeof(GameObject))) as GameObject;
            GameObject p4 = Instantiate (Resources.Load("player", typeof(GameObject))) as GameObject;   
            players.Add(p1);
            players.Add(p2);
            players.Add(p3);
            players.Add(p4);
            p1.GetComponent<PlayerMovement>().setKeyBinds(playerkeybinds[0], playerkeybinds[1], playerkeybinds[2]);
            p1.GetComponent<PlayerMovement>().setKeyBinds(playerkeybinds[3], playerkeybinds[4], playerkeybinds[5]);
            p1.GetComponent<PlayerMovement>().setKeyBinds(playerkeybinds[7], playerkeybinds[7], playerkeybinds[8]);
            p1.GetComponent<PlayerMovement>().setKeyBinds(playerkeybinds[9], playerkeybinds[10], playerkeybinds[11]);            

        }   
    }

    public string [] getKeyBinds(){
        return playerkeybinds;
    }


}

