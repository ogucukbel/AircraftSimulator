using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    [Header ("ScriptableObjects")]
    [SerializeField] private IntVariable score;
    [SerializeField] private IntVariable aircraftSpeed;

    [Header ("UI Objects")]
    public GameObject winPanel;
    public GameObject failPanel;
    [SerializeField] private Text distanceText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Slider speedSlider;
    private int tempSpeed;

    private void OnEnable() 
    {
        aircraftSpeed.SetValue(5);
    }

    private void Update() 
    {
        scoreText.text = "Score: " + score.GetValue().ToString();
    }

    public void SpeedSliderChangeCheck(Slider speed)
	{
        if(speed.value > tempSpeed)
        {
            aircraftSpeed.Increase((int)speed.value);
            tempSpeed = (int)speed.value;
        }
        if(speed.value <= tempSpeed)
        {
            aircraftSpeed.Decrease(tempSpeed - (int)speed.value);
            tempSpeed = (int)speed.value;
        }
	}

    public void RestartButton()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
