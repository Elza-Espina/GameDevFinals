using UnityEngine;
using System.Collections;

public class Level1Controller : MonoBehaviour {

    public float targetTime = 60.0f;

    public GameObject fire;


    // Use this for initialization
    void Start () {
        InvokeRepeating("GenerateFire", 0, 0.1f);
    }

// Update is called once per frame
    void Update() {
        targetTime -= Time.deltaTime;

        if (targetTime > 0.0f)
        {

        }
        else
        {
            timerEnded();
            if (GameObject.Find("fire(Clone)") == null)
            {
                Debug.Log("no more fire");
            }
        }
    }

    void timerEnded()
    {
        Debug.Log("timer out");
        CancelInvoke("GenerateFire");
    }

    void GenerateFire()
    {
        Instantiate(fire, new Vector3(Random.Range(-9.5f, 7f), Random.Range(-1.05f,6f), transform.position.z), transform.rotation);
    }

}
