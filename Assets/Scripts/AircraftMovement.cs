using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMovement : MonoBehaviour
{
    [SerializeField] private VariableJoystick variableJoystick;
    private float aircraftSpeed;
    private float aircraftTurnSpeed;
    private Vector3 aircraftMovementDirection;
    private Rigidbody aircraftRigidbody;
    [SerializeField] private GameObject aircraftGameObject;
    
    private void Awake() 
    {
        aircraftRigidbody = GetComponent<Rigidbody>();
        aircraftSpeed = 10;
        aircraftTurnSpeed = aircraftSpeed * 3f;
    }

    private void FixedUpdate() 
    {
        MoveAircraft();
        transform.position += transform.forward * aircraftSpeed * Time.deltaTime;
    }
    private void MoveAircraft()
    {
        float aircraftXAxisMovement = variableJoystick.Horizontal;
        float aircraftYAxisMovement = variableJoystick.Vertical;

        if(aircraftXAxisMovement != 0 && aircraftYAxisMovement != 0)
        {
            aircraftMovementDirection += new Vector3(aircraftXAxisMovement * aircraftTurnSpeed, aircraftYAxisMovement * aircraftTurnSpeed, this.transform.position.z);
            aircraftRigidbody.MoveRotation(Quaternion.LookRotation(aircraftMovementDirection));

            aircraftGameObject.transform.LeanRotateZ(aircraftXAxisMovement * -30, 2);
        }
    }
}
