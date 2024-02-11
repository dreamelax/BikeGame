using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Transform transform;
    public Rigidbody2D rigidbody2d;

    public GameManager gamemanager;

    public float runspeed;
    public float horizontal;
    public float vertical;
    public float inversionFactor;
    public Vector2 movementvector;

    string [] inps;
    // Start is called before the first frame update
    void Start()
    {
        
        // intial movement 
        horizontal = -1; 
        vertical   = 0;
        inversionFactor = 1;
        movementvector = new Vector2(horizontal, vertical);
        runspeed = 20f;
        
    }

    void Awake(){
        inps = new string [3];
    }
    // Update is called once per frame
    void Update()
    {

        // float horizontal = Input.GetAxisRaw("Horizontal"); 
        // float vertical   = Input.GetAxisRaw("Vertical");
        // Vector2 movementvector = new Vector2(horizontal, vertical);
        // movementVector.Normalize(); //-> keeps diagonal movement at the same speed
        // transform.Translate(movementvector*runspeed*Time.deltaTime);  

        // getting keybinds from gamemanager , order: left - right - boost 
        // Debug.Log("hello");
        // Debug.Log(inps[0]);

        if(Input.GetKeyDown(""+inps[0])){
            Debug.Log("NOT Hooray~!");
            horizontal = -1;
            vertical   = 0;
            inversionFactor = 1;
            // transform.localRotation = Quaternion.Euler(0, 0, 0);
            Vector3 vRot = new Vector3(0,0,90);
            transform.Rotate(vRot, Space.Self);
        }


        if(Input.GetKeyDown(""+inps[1])){
            Debug.Log("Hooray~!");
            horizontal = 1; 
            vertical   = 0;
            inversionFactor = -1;
            // Quaternion q1 = Quaternion(90,0,0);
            // transform.LookAt(new Vector2(transform.localPosition.x+1,transform.localPosition.y+1));
            // transform.localRotation = Quaternion.Euler(0, 0, 180);
            Vector3 vRot = new Vector3(0,0,270);
            transform.Rotate(vRot, Space.Self);
        }


        movementvector = new Vector2(horizontal*inversionFactor, vertical);
        transform.Translate(movementvector*runspeed*Time.deltaTime);  

    }

    public void setKeyBinds(string s1, string s2, string s3){
        inps[0] = s1;
        inps[1] = s2;
        inps[2] = s3;
    }
}
