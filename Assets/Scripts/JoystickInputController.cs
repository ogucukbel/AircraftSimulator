using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickInputController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private VariableJoystick variableJoystick;
    [SerializeField] private AircraftMovement aircraftMovement;
    private float aircraftXAxisMovement;
    private float aircraftYAxisMovement;
    private float tempAircraftXAxisMovement;
    private float tempAircraftYAxisMovement;

    private void Awake() 
    {
        variableJoystick = GetComponent<VariableJoystick>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        aircraftMovement.MoveAircraft(aircraftXAxisMovement, aircraftXAxisMovement);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        aircraftMovement.MoveAircraft(tempAircraftXAxisMovement, tempAircraftYAxisMovement);
    }

    public void OnDrag(PointerEventData eventData)
    {
        aircraftXAxisMovement = variableJoystick.Horizontal;
        aircraftYAxisMovement = variableJoystick.Vertical;
        
        aircraftMovement.MoveAircraft(aircraftXAxisMovement, aircraftYAxisMovement);

        tempAircraftXAxisMovement = aircraftXAxisMovement;
        tempAircraftYAxisMovement = aircraftYAxisMovement;
    }
}
