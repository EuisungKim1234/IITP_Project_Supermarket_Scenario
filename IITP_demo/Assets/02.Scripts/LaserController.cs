using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public Transform RayTransform;

    private enum State { Ready, Undo };
    private State currentState = State.Undo;

    public GameObject laserGuideLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaserOn()
    {
        
        if (laserGuideLine.activeSelf != false)
        {
            Debug.Log("Laser On");
            //currentState = State.Ready;

            LaserShot();
        }

        

        //currentState = State.Undo;
    }

    public void LaserShot()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(RayTransform.position, RayTransform.forward, out hit ) )
        {
            ICountable target = hit.collider.GetComponent<ICountable>();

            if(target != null)
            {
                target.OnCount(/*hit.transform.tag.ToString()*/);
            }
        }

        //currentState = State.Undo;
        //laserGuideLine.SetActive(false);
    }

    public void StateIn()
    {
        laserGuideLine.SetActive(true);
    }
    public void StateOut()
    {
        laserGuideLine.SetActive(false);
    }
}
