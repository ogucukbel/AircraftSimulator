using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckPointManager : MonoBehaviour
{
    public List<CheckPoint> CheckPoints;
    [SerializeField] private CanvasController canvasController; 
    private float distanceAirplaneToCheckPoint;
    [SerializeField] private GameObject aircraft;

    private void Update() 
    {
        CheckPoints = GetComponentsInChildren<CheckPoint>().ToList();

        if(CheckPoints.Count > 0)
        {
            distanceAirplaneToCheckPoint = Vector3.Distance(CheckPoints[0].transform.position, aircraft.transform.position);

            if(distanceAirplaneToCheckPoint > 100)
            {
                canvasController.failPanel.SetActive(true);
            }
        }
    }
}
