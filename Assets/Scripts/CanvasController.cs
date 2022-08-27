using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private IntVariable score;
    [SerializeField] private Text scoreText;
    [SerializeField] private IntVariable aircraftSpeed;
    [SerializeField] private Slider speedSlider;


    private void Update() 
    {
        scoreText.text = "Score: " + score.GetValue().ToString();
    }

    public void SpeedSliderChangeCheck(Slider speed)
	{
		aircraftSpeed.Increase((int)speed.value);
	}
}
