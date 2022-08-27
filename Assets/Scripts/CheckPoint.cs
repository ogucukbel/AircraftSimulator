using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool isCorrectCheckPoint;
    public MeshRenderer checkPointMeshRenderer;
    [SerializeField] private IntVariable score;
    [SerializeField] private LayerMask airCraft;

    private void Awake() 
    {
        checkPointMeshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if((airCraft.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            LeanTween.scale(this.gameObject, Vector3.one * 80, 1).setOnComplete(DestoryCheckPoint);
            if(isCorrectCheckPoint)
            {
                score.Increase(1);
            }
            if(!isCorrectCheckPoint)
            {
                score.Decrease(1);
            }
        }
    }

    private void DestoryCheckPoint()
    {
        Destroy(this.gameObject);
    }
}
