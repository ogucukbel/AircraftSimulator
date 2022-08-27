using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftInteractor : MonoBehaviour
{
    [SerializeField] private LayerMask checkPoint;
    [SerializeField] private CheckPointManager checkPointManager;
    private GameObject currentCheckPoint;
    private RaycastHit hit;

    private void FixedUpdate() 
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out hit, 15, checkPoint))
        {
            if(hit.transform.gameObject.name == checkPointManager.CheckPoints[0].name)
            {
                currentCheckPoint = hit.transform.gameObject;

                currentCheckPoint.GetComponent<CheckPoint>().isCorrectCheckPoint = true;
                currentCheckPoint.GetComponent<CheckPoint>().checkPointMeshRenderer.material.color = Color.green;
            }
            if(hit.transform.gameObject.name != checkPointManager.CheckPoints[0].name)
            {
                currentCheckPoint = hit.transform.gameObject;

                currentCheckPoint.GetComponent<CheckPoint>().isCorrectCheckPoint = false;
                currentCheckPoint.GetComponent<CheckPoint>().checkPointMeshRenderer.material.color = Color.red;
            }
        }
    }
}
