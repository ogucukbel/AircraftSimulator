using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using PathCreation;

public class AircraftInteractor : MonoBehaviour
{

    [Header ("Classes & Gameobjects")]
    [SerializeField] private ParticleSystem fire;
    [SerializeField] private CanvasController canvasController;
    [SerializeField] private CheckPointManager checkPointManager;

     [Header ("Layers")]
    [SerializeField] private LayerMask checkPoint;
    [SerializeField] private LayerMask ground;

    [Header ("Path Creator")]
    [SerializeField] private PathCreator pathCreator;
    private float distanceTravelled;
    [SerializeField] private EndOfPathInstruction finishPosition;
    private GameObject currentCheckPoint;
    private Ray ray;
    private RaycastHit hit;


    private void Update() 
    {
        ray = new Ray(transform.position, transform.forward);

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

        if(checkPointManager.CheckPoints.Count <= 0)
        {
            distanceTravelled += 20 * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, finishPosition);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, finishPosition);

            canvasController.winPanel.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if((ground.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            Instantiate(fire, this.transform.position, Quaternion.identity);
            canvasController.failPanel.SetActive(true);
        }
    }
}
