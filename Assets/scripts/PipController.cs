using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipController : MonoBehaviour {

    public float moveRate = 0.1f;
    public GameObject pip;

    private Animator animator;
    private bool isSaved=false;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        Invoke("PipRun", 15);

    }
	
	// Update is called once per frame
	void Update () {
        if (isSaved==false) {
            transform.position = new Vector2(transform.position.x + moveRate, transform.position.y);
        }

        if (transform.position.x >= 313.7)
        {
            Destroy(gameObject);
        }
        if (transform.Find("fire")==null)
        {
            isSaved = true;
            animator.SetInteger("anim", 1);
        }
    }
    void PipRun()
    {
        Instantiate(pip, new Vector3(-15, transform.position.y, transform.position.z), transform.rotation);
    }
}
