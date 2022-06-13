using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
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
        timeValue = timeMax;
        timeSlider.maxValue = timeValue;
        timeSlider.minValue = 0f; 
        timeSlider.value = timeValue;

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
        timeValue -= Time.deltaTime;
        timeSlider.value = timeValue;

        if(timeValue < 0f)
        {
            gameRunning = false;
            //gameOver
        }
    }
    public void ReduceConscious()
    {
        consciousValue -= consciousReduceValue * Time.deltaTime;
        consciousSlider.value = consciousValue;

        if(consciousValue < 0f)
        {
            //stun
        }
    }

    public void IncreaseConscious(float conscious)
    {
        consciousValue += conscious;

        if(consciousValue > consciousMax)
            consciousValue = consciousMax;
    }
}
