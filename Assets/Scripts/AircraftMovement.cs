using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMovement : MonoBehaviour
{
    [SerializeField] private GameObject aircraftGameObject;
    [SerializeField] private IntVariable aircraftSpeed;
    private Vector3 aircraftMovementDirection;
    private Rigidbody aircraftRigidbody;
    private int turnAircraftSpeed;
    
    private void Awake() 
    {
        aircraftRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        transform.position += transform.forward * aircraftSpeed.GetValue() * Time.deltaTime;
    }

    public void MoveAircraft(float _aircraftXAxisMovement, float _aircraftYAxisMovement)
    {

        if(aircraftSpeed.GetValue() < 10)
        {
            turnAircraftSpeed = 10;

            aircraftMovementDirection = new Vector3(0, _aircraftYAxisMovement * turnAircraftSpeed, this.transform.position.z);
            aircraftRigidbody.MoveRotation(Quaternion.LookRotation(aircraftMovementDirection));
        }
        else if(aircraftSpeed.GetValue() >= 25)
        {
            turnAircraftSpeed = 25;

            aircraftMovementDirection = new Vector3(_aircraftXAxisMovement * turnAircraftSpeed, _aircraftYAxisMovement * turnAircraftSpeed, this.transform.position.z);
            aircraftRigidbody.MoveRotation(Quaternion.LookRotation(aircraftMovementDirection));

            aircraftGameObject.transform.LeanRotateZ(_aircraftXAxisMovement * -45, 1);
        }
        else 
        {
            turnAircraftSpeed = aircraftSpeed.GetValue();

            aircraftMovementDirection = new Vector3(_aircraftXAxisMovement * turnAircraftSpeed, _aircraftYAxisMovement * turnAircraftSpeed, this.transform.position.z);
            aircraftRigidbody.MoveRotation(Quaternion.LookRotation(aircraftMovementDirection));

            aircraftGameObject.transform.LeanRotateZ(_aircraftXAxisMovement * -45, 1);
        }
    }
}
