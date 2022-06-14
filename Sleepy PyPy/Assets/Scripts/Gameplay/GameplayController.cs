using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject respawnPoint;

    [SerializeField]
    // Slider is Unity UI 
    private Slider timeSlider, consciousSlider;
    [SerializeField]
    private float timeMax = 20f, consciousMax = 20f;

    private float timeValue, consciousValue;

    [SerializeField]
    private float consciousReduceValue = 1f;

    private bool gameRunning;

    private void Awake()
    {
        if(instance==null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Set Time Slider value
        timeValue = timeMax;
        timeSlider.maxValue = timeValue;
        timeSlider.minValue = 0f; 
        timeSlider.value = timeValue;

        //Set Conscious Slider value
        consciousValue = consciousMax;
        consciousSlider.maxValue = consciousValue;
        consciousSlider.minValue = 0f;
        consciousSlider.value = consciousValue;

        gameRunning = true;
    }
      
    // Update is called once per frame
    void Update()
    {
        if (!gameRunning)
            return;
         
        ReduceTime();
        ReduceConscious();
    }

    void ReduceTime()
    {
        // Reduce time value
        timeValue -= Time.deltaTime;
        // Set time slider value equal time value 
        timeSlider.value = timeValue;

        if(timeValue <= 0f)
        {
            // if time value <= 0, time over, game over
            gameRunning = false;
            //gameOver
        }
    }
    public void ReduceConscious()
    {
        if(consciousValue > 0)
        {
            // Reduce Consciout Value
            consciousValue -= consciousReduceValue * Time.deltaTime;
            // Set Consciout Slier value equal Consciout value
            consciousSlider.value = consciousValue;
        }

        if(consciousValue < 0f)
        {
            //stun
        }
    }

    public void IncreaseConscious(float conscious)
    {
        // Increase Conscious valued based on conscious 
        consciousValue += conscious;

        if(consciousValue > consciousMax)
            consciousValue = consciousMax;
    }

    public void Restart()
    {
        player.transform.position = respawnPoint.transform.position;
    }
}
