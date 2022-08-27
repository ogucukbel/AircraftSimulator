using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMovement : MonoBehaviour
{
    [SerializeField] private VariableJoystick variableJoystick;
    [SerializeField] private IntVariable aircraftSpeed;
    private float aircraftTurnSpeed;
    private Vector3 aircraftMovementDirection;
    private Rigidbody aircraftRigidbody;
    [SerializeField] private GameObject aircraftGameObject;
    
    private void Awake() 
    {
        aircraftRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        aircraftTurnSpeed = aircraftSpeed.GetValue() * 2f;
        transform.position += transform.forward * aircraftSpeed.GetValue() * Time.deltaTime;
        MoveAircraft();
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
