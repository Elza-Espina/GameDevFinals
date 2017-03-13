using UnityEngine;
using System.Collections;


public class WaterController : MonoBehaviour
{

    public float moveRate = 0.2f;
    private Animator animator;
    

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + moveRate);

        if (transform.position.y >= 10 || transform.position.y<=-2.0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        
        Debug.Log("waterhit");
        if (target.gameObject.tag == "fire")
        {            
            Destroy(target.gameObject);        
            
        }
        Destroy(gameObject);

    }


}
