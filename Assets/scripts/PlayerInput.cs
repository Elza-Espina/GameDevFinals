using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    public Vector2 moving = new Vector2();

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        moving.x = 0;
        moving.y = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moving.x = 1;
           
            //Debug.Log("moving.x"+moving.x);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moving.x = -1;
            //Debug.Log("moving.x"+moving.x);
        }else
        {
        }

	}
}
