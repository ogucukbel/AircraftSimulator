using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckPointManager : MonoBehaviour
{
    public List<CheckPoint> CheckPoints;

    private void Update() 
    {
        CheckPoints = GetComponentsInChildren<CheckPoint>().ToList();
    }
}
