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
    [SerializeField]
    private GameObject pypy;

    private PyPy pypyClass;

    private float timeValue, consciousValue;

    [SerializeField]
    private float consciousReduceValue = 1f;
    private Animator anim;
    private bool gameRunning;

    [SerializeField]
    private Canvas gameOverCanvas;
    [SerializeField]
    private Text winText, loseTest;

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

        pypyClass = pypy.GetComponent<PyPy>();
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
            GameOver(false);
        }
    }
    public void ReduceConscious()
    {
        consciousValue -= consciousReduceValue * Time.deltaTime;
        consciousSlider.value = consciousValue;

        if (consciousValue > consciousMax / 3f)
        {
            if (pypyClass != null)
            {
                pypyClass.setMoveSlowly(false);
                pypyClass.setStunned(false);
            }
        }

        else if (consciousValue <= consciousMax / 3f)
        {
            if (pypyClass != null)
            {
                pypyClass.setMoveSlowly(true);
            }
        }
           
        if (consciousValue <= 0f)
        {
            consciousValue = 0f;
            if (pypyClass != null)
            {
                pypyClass.setStunned(true);
                pypyClass.setMoveSlowly(false);
                StartCoroutine(setAfterSleep());
            }
        }
    }

    public void IncreaseConscious(float conscious)
    {
        consciousValue += conscious;

        if(consciousValue > consciousMax)
            consciousValue = consciousMax;
    }
    IEnumerator setAfterSleep()
    {
        yield return new WaitForSeconds(3f);
        consciousValue = consciousMax /2f;
        consciousSlider.value = consciousValue;
        pypyClass.setStunned(false);
        pypyClass.setMoveSlowly(true);
    }

    public void GameOver (bool win)
    {
        Destroy(pypy);
        gameOverCanvas.enabled = true;
        gameRunning = false;
        if(win)
        {
            SoundController.instance.P_victory();
            winText.gameObject.SetActive(true);
        }
        else
        {
            SoundController.instance.P_gameOver();
            loseTest.gameObject.SetActive(true);
        }
    }
}
