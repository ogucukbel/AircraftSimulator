using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMovement : MonoBehaviour
{
    [SerializeField] private GameObject aircraftGameObject;
    [SerializeField] private IntVariable aircraftSpeed;
    private Vector3 aircraftMovementDirection;
    private Rigidbody aircraftRigidbody;
    
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
        aircraftMovementDirection = new Vector3(_aircraftXAxisMovement * 20, _aircraftYAxisMovement * 10, this.transform.position.z);
        aircraftRigidbody.MoveRotation(Quaternion.LookRotation(aircraftMovementDirection));

        aircraftGameObject.transform.LeanRotateZ(_aircraftXAxisMovement * -45, 1);
    }
}
