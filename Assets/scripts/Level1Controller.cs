using UnityEngine;
using System.Collections;

public class Level1Controller : MonoBehaviour {

    public float targetTime = 60.0f;

    public GameObject fire;


    // Use this for initialization
    void Start () {
        InvokeRepeating("GenerateFire", 0, 5);
    }

// Update is called once per frame
    void Update() {
        targetTime -= Time.deltaTime;

    if (targetTime > 0.0f)
    {
       
    }else{
        timerEnded();
    }
    }

    void timerEnded()
    {
        Debug.Log("timer out");
    }

    void GenerateFire()
    {
        Instantiate(fire, bomber.position, 1);
    }

}
