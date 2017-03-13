using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 0.0f;
    public Vector2 velocityCheck = new Vector2(20.0f, 0.0f);
    private Animator animator;
    public PlayerInput input;
    
	public float CurrFuel = 35;
	public float MaxFuel = 35;

	public float CurrWat = 10;
	public float MaxWat = 10;

	public Text Fuel;
	public Text Wat;

	public AudioClip engine;
	public AudioClip siren;

    // Use this for initialization
    void Start()
    {
		Fuel = GameObject.Find ("Fuel").GetComponent<Text> ();
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
		AudioSource.PlayClipAtPoint (engine,transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		
        float forceX = 0.0f;
        float forceY = 0.0f;

            var playerAbsVelX = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x);
      //  var playerAbsVelY = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y);

        if (playerAbsVelX <= 1.0f /*&& playerAbsVelY <= 0.1f*/)
        {
            animator.SetInteger("animState", 0);
        }

        if (input.moving.x != 0 && CurrFuel > 0)
        {
			
			CurrFuel -= Time.deltaTime;
			updateGauge();
            forceX = moveSpeed * input.moving.x;
            if (playerAbsVelX <= velocityCheck.x)
            {                
                Debug.Log("player" + playerAbsVelX+ "limit" + velocityCheck.x);
            }
            if (input.moving.x>0)
            {
                animator.SetInteger("animState", 1);
            }
            if (input.moving.x < 0)
            {                
                animator.SetInteger("animState", -1);
            }
		}else if(CurrFuel <= 0){
			//Application.LoadLevel ("");
		}

        GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);

    }

	public void updateGauge(){
		Fuel.text = Math.Round(((CurrFuel / MaxFuel)*100), 2).ToString();
		Debug.Log(CurrFuel);
	}
}
