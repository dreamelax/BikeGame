using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



// DOODAD
public class GameManager : MonoBehaviour
{
    // SETTINGS
    private int playerNum;
    // ["A","D","W"] = 1 player with A to turne left, D to turn right, W to boost
    // ["A","D","W","left","right","up"] = 2 players, player 1 has A to left, D to right, W to boost. player 2 has ye self-explainitory
    private List <GameObject> players = new List<GameObject>();
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public List<InputField> textBoxes = new List<InputField>();
    public string[] keybinds = new string[12];
    public GameObject LETSGOBUTTON;
    private int goodcount = 6; // this/3 = how many are playing!
    private int nullcount = 6; // this/3 = how many not playing :(
    public Sprite p2Sprite;
    public Sprite p3Sprite;
    public Sprite p4Sprite;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void checkKeybinds(){
        nullcount =0;
        goodcount =0;
        foreach(InputField t in textBoxes){
            if(t.text=="")
                nullcount++;
            else if(IsValidKeyCode((t.text).ToLower()))
                goodcount++;
        }
        if(nullcount<=6 && goodcount>=6 && (goodcount)%3==0)
            LETSGOBUTTON.SetActive(true);
        else
            LETSGOBUTTON.SetActive(false);
        Debug.Log(nullcount+" "+goodcount);
    }

    public bool IsValidKeyCode(string keyString)
    {
        List<string> possibleKeys = new List<string>();
        possibleKeys.Add("a");
        possibleKeys.Add("b");
        possibleKeys.Add("c");
        possibleKeys.Add("d");
        possibleKeys.Add("e");
        possibleKeys.Add("f");
        possibleKeys.Add("g");
        possibleKeys.Add("h");
        possibleKeys.Add("i");
        possibleKeys.Add("j");
        possibleKeys.Add("k");
        possibleKeys.Add("l");
        possibleKeys.Add("m");
        possibleKeys.Add("n");
        possibleKeys.Add("o");
        possibleKeys.Add("p");
        possibleKeys.Add("q");
        possibleKeys.Add("r");
        possibleKeys.Add("s");
        possibleKeys.Add("t");
        possibleKeys.Add("u");
        possibleKeys.Add("v");
        possibleKeys.Add("w");
        possibleKeys.Add("x");
        possibleKeys.Add("y");
        possibleKeys.Add("z");
        possibleKeys.Add("0");
        possibleKeys.Add("1");
        possibleKeys.Add("2");
        possibleKeys.Add("3");
        possibleKeys.Add("4");
        possibleKeys.Add("5");
        possibleKeys.Add("6");
        possibleKeys.Add("7");
        possibleKeys.Add("8");
        possibleKeys.Add("9");
        possibleKeys.Add("right shift");
        possibleKeys.Add("left shift");
        possibleKeys.Add("right ctrl");
        possibleKeys.Add("left ctrl");
        possibleKeys.Add("right alt");
        possibleKeys.Add("left alt");
        possibleKeys.Add("right cmd");
        possibleKeys.Add("left cmd");
        possibleKeys.Add("f1");
        possibleKeys.Add("f2");
        possibleKeys.Add("f3");
        possibleKeys.Add("f4");
        possibleKeys.Add("f5");
        possibleKeys.Add("f6");
        possibleKeys.Add("f7");
        possibleKeys.Add("f8");
        possibleKeys.Add("f9");
        possibleKeys.Add("f10");
        possibleKeys.Add("f11");
        possibleKeys.Add("f12");
        possibleKeys.Add("up");
        possibleKeys.Add("down");
        possibleKeys.Add("left");
        possibleKeys.Add("right");
        possibleKeys.Add("backspace");
        possibleKeys.Add("tab");
        possibleKeys.Add("return");
        possibleKeys.Add("escape");
        possibleKeys.Add("space");
        possibleKeys.Add("delete");
        possibleKeys.Add("enter");
        possibleKeys.Add("insert");
        possibleKeys.Add("home");
        possibleKeys.Add("end");
        possibleKeys.Add("page up");
        possibleKeys.Add("page down");
        foreach(string s in possibleKeys){
            if(s==keyString)
                return true;
        }
        return false;
    }


    // RESET GAME
    public void resetGame(){
        int count=0;
        foreach(InputField t in textBoxes){
            keybinds[count] = t.text;
            count++;
        }
        Debug.Log("yippeeq1");
        playerNum = goodcount/3;
        Debug.Log("playernum"+playerNum);
        if(playerNum == 2){
            Debug.Log("yippeesdddd");
            GameObject p1 = Instantiate (Resources.Load("player", typeof(GameObject))) as GameObject;
            GameObject p2 = Instantiate (Resources.Load("player", typeof(GameObject))) as GameObject;
            players.Add(p1);
            players.Add(p2);
            p1.GetComponent<PlayerMovement>().setKeyBinds(keybinds[0], keybinds[1], keybinds[2]);
            p2.GetComponent<PlayerMovement>().setKeyBinds(keybinds[3], keybinds[4], keybinds[5]);
            p2.GetComponentInChildren<SpriteRenderer>().sprite = p2Sprite;
            p1.transform.position = spawn1.transform.position;
            p2.transform.position = spawn2.transform.position;
            p1.transform.Rotate(new Vector3(0,0,180), Space.Self);
            Debug.Log("yippee");
        }
        else if(playerNum == 3){
            GameObject p1 = Instantiate (Resources.Load("player", typeof(GameObject))) as GameObject;
            GameObject p2 = Instantiate (Resources.Load("player", typeof(GameObject))) as GameObject;
            GameObject p3 = Instantiate (Resources.Load("player", typeof(GameObject))) as GameObject;
            players.Add(p1);
            players.Add(p2);
            players.Add(p3);
            p1.GetComponent<PlayerMovement>().setKeyBinds(textBoxes[0].text+"", textBoxes[1].text+"", textBoxes[2].text+"");
            p2.GetComponent<PlayerMovement>().setKeyBinds(textBoxes[3].text+"", textBoxes[4].text+"", textBoxes[5].text+"");
            p3.GetComponent<PlayerMovement>().setKeyBinds(textBoxes[6].text+"", textBoxes[7].text+"", textBoxes[8].text+""); 
            p2.GetComponentInChildren<SpriteRenderer>().sprite = p2Sprite;
            p3.GetComponentInChildren<SpriteRenderer>().sprite = p3Sprite;
            p1.transform.position = spawn1.transform.position;
            p2.transform.position = spawn2.transform.position;
            p3.transform.position = spawn3.transform.position;
            p1.transform.Rotate(new Vector3(0,0,180), Space.Self);
            p3.transform.Rotate(new Vector3(0,0,-90), Space.Self);
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
            p1.GetComponent<PlayerMovement>().setKeyBinds(textBoxes[0].text, textBoxes[1].text, textBoxes[2].text);
            p2.GetComponent<PlayerMovement>().setKeyBinds(textBoxes[3].text, textBoxes[4].text, textBoxes[5].text);
            p3.GetComponent<PlayerMovement>().setKeyBinds(textBoxes[6].text, textBoxes[7].text, textBoxes[8].text); 
            p4.GetComponent<PlayerMovement>().setKeyBinds(textBoxes[9].text, textBoxes[10].text, textBoxes[11].text);
            p2.GetComponentInChildren<SpriteRenderer>().sprite = p2Sprite;
            p3.GetComponentInChildren<SpriteRenderer>().sprite = p3Sprite;
            p4.GetComponentInChildren<SpriteRenderer>().sprite = p4Sprite;
            p1.transform.position = spawn1.transform.position;
            p2.transform.position = spawn2.transform.position;
            p3.transform.position = spawn3.transform.position;
            p4.transform.position = spawn4.transform.position;
            p1.transform.Rotate(new Vector3(0,0,180), Space.Self);
            p3.transform.Rotate(new Vector3(0,0,-90), Space.Self);
            p4.transform.Rotate(new Vector3(0,0,90), Space.Self);
        }   
    }






}

