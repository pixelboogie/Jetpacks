using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Jetpack : MonoBehaviour
{
    
    //Check to see whether we can continue flying up
    private bool fuel;

    //Float to track how much time has passed since we took off
    private float time = 0.0f;

    //How much time we have to fly before we "run out of fuel"
    public float tankCapacity = 20.0f;

    //Modifier to change how fast we descend after running out of fuel
    public float fallVelocity;


    //Reference our Character Controller on the Oculus prefab
    private CharacterController character;

    //Reference the gravity equation from OVRPlayerController script from Oculus Integration
    private float cancelGravity;

    //Declare our new upwards velocity for the Jetpack
    public float liftVelocity;

    //Create a new Vector3 to set our new Jetpack velocity
    private Vector3 moveDirection = Vector3.zero;

    //Flag to determine if we should descend slowly or if we should be affected by gravity
    public bool slowFall = false;


    //Declare controls
    // still experimenting wtih these
    private float JetpackRight = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
    private float JetpackLeft = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
    // private bool JetpackLeft = OVRInput.Get(OVRInput.RawButton.Y);
    // private bool JetpackRight = OVRInput.Get(OVRInput.RawButton.B);
    private bool HoverTrigger = OVRInput.Get(OVRInput.RawButton.LIndexTrigger);


    public Text HealthDisplay;
    public Text FuelDisplay;
    public Text FallVelocity_txt;
    public Text MoveDirection_txt;

    public int myHealth = 100;
    
    private bool onGround = true;

    public float flyAcceleration = .7f;

    public GameObject HealthBar;
    public GameObject FuelBar;

    public AudioSource RocketSound;
    public AudioClip RocketClip;

    public AudioSource HitSource;
    public AudioClip HitClip;
    float m_MySliderValue;

    public Text PrizesCount;
    int prizes;

    private Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0.1f);


    // Start is called before the first frame update
    void Start()
    {
        //Set character to our Character Controller component
        character = GetComponent<CharacterController>();

        //Set cancelGravity equal to the gravity equation from OVRPlayerController
        cancelGravity = ((Physics.gravity.y * (GetComponent<OVRPlayerController>().GravityModifier * 0.002f)));

        HealthDisplay.text = myHealth.ToString();

        // HealthBar = GameObject.FindWithTag("ProgressBar");

        prizes = 0;


    }

    // Update is called once per frame
    void Update()
    {
        //Continually re-declare our controls
        // JetpackRight = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
        JetpackLeft = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        HoverTrigger = OVRInput.Get(OVRInput.RawButton.LIndexTrigger);

        //Call Jetpack function
        newJetpack();

        //Calculate our new Character Controller move velocity
        character.Move(moveDirection * Time.deltaTime);

        FallVelocity_txt.text = moveDirection.y.ToString();
        MoveDirection_txt.text = fallVelocity.ToString();

    }

    public void newJetpack()
    {
        //Set moveDirection back to 0
        moveDirection = Vector3.zero;
        // moveDirection = myFloor;
      

        float fuelLeft = tankCapacity - time;
        FuelDisplay.text = Mathf.Round(fuelLeft).ToString();  // debug only
        FuelBar.GetComponent<ProgressBar>().current = (int)fuelLeft;
        FuelBar.GetComponent<ProgressBar>().maximum = (int)tankCapacity;

        if (time > tankCapacity)
        {
            //Run out of fuel after our designated fly time
            fuel = false;
        }



        //Check to see if both hand triggers are grabbed
        if (JetpackLeft > 0.9 && fuel)
        //  if (JetpackLeft > 0.9 && JetpackRight > 0.9 && fuel)
        // if (JetpackLeft == true && JetpackRight == true && fuel)
        {
            //start fuel timer
            time += Time.deltaTime;

            //Negate FallSpeed calculated in OVRPlayerController script
            GetComponent<OVRPlayerController>().FallSpeed = cancelGravity;

            //Increment y velocity on our Vector3 to create upward velocity
            moveDirection.y += liftVelocity;

            onGround = false;

           fallVelocity = 0;

            if(HoverTrigger)
            {
                moveDirection.y = 0.0f;
                GetComponent<OVRPlayerController>().Acceleration = 0.0f;
            }else
            {
                GetComponent<OVRPlayerController>().Acceleration = flyAcceleration;
            }

            if (RocketSound.isPlaying == true)
            {

            }
            else
            {
                RocketSound.Play();
            }

        }else { // falling
            if(!character.isGrounded)
            {
                fallVelocity-=.08f; // keep adding more fallVelocity 
            }
            
            moveDirection.y += fallVelocity; //Fall velocity has to be a negative number

           RocketSound.Stop();

            GetComponent<OVRPlayerController>().Acceleration = 0.4f;
        }


        //If character is back on the ground, set slowFall back to false.  
        if (character.isGrounded)
        {
            slowFall = false;

            fuel = true;

            fallVelocity = 0f;
        }

    }

     void OnTriggerEnter(Collider collision)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (!onGround && collision.CompareTag("Surface"))
        {
           

            if(fallVelocity < -6){
                myHealth -= 100;
                m_MySliderValue = 1.0f;
            } else if(fallVelocity < -5){
                myHealth -= 70;
                m_MySliderValue = 0.8f;
            } else if(fallVelocity < -4){
                myHealth -= 40;
                m_MySliderValue = 0.6f;
            } else if(fallVelocity < -3){
                myHealth -= 20;
                m_MySliderValue = 0.5f;
            } else if(fallVelocity < -2.5){
                myHealth -= 10;
                m_MySliderValue = 0.1f;
            }else{
                m_MySliderValue = 0.05f;
            }

            HitSource.volume = m_MySliderValue;
            HitSource.Play();

            HealthBar.GetComponent<ProgressBar>().current = myHealth;
            HealthDisplay.text = myHealth.ToString();
           
            onGround = true;

        }

        if (collision.CompareTag("Fuel"))
        {
            time = 0;
        }

        if (collision.CompareTag("Health"))
        {
            myHealth = 100;
            HealthBar.GetComponent<ProgressBar>().current = myHealth;
            HealthDisplay.text = myHealth.ToString();
        }
        if (collision.CompareTag("Prize"))
        {
            prizes++;
            PrizesCount.text = prizes.ToString();
            
            // scale it to 0 and move it to 0 so i cant see it or register more collisions
            collision.gameObject.transform.localScale = scaleChange;
            collision.gameObject.transform.position = scaleChange;
            Destroy(collision.gameObject, 2.0f);
        }

    }

}
