using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour, ICountable
{
    private enum State { Ready, Stop };
    private State currentState = State.Ready;

    public GameObject applePrefab;
    public GameObject rightCollider;

    private Vector3 rightColliderPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rightColliderPosition = rightCollider.transform.position;
    }

    public void OnCount()
    {
        Debug.Log("recognize Collider");
    }

    public void OnGrab()
    {
        if (currentState != State.Stop)
        {
            Debug.Log("그랩 성공");
            Instantiate(applePrefab, rightColliderPosition, applePrefab.transform.rotation);
        }
    }


    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Fruit"))
        {
            Debug.Log("과일과 충돌 중");
            currentState = State.Stop;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Fruit"))
        {
            Debug.Log("과일과 충돌 해제");
            currentState = State.Ready;
        }
    }

}
