using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCounter : MonoBehaviour
{
    public int appleEA = 0;
    public int bananaEA = 0;
    public int cucumberEA = 0;
    public int cabageEA = 0;
    public int totalEA = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Quaternion targetRotation = Quaternion.LookRotation(other.transform.position - this.transform.position, this.transform.up);

        if (targetRotation.x > 0) Debug.Log("Forward");
        if (targetRotation.x < 0) Debug.Log("Backward");

        Debug.Log(other.transform.localPosition);
        Debug.Log(other.tag);

        switch (other.tag)
        {
            case "Apple":
                appleEA++;
                totalEA++;
                Debug.Log("Apple = " + appleEA);
                break;
            case "Banana":
                bananaEA++;
                totalEA++;
                Debug.Log("Banana = " + bananaEA);
                break;
            case "Cucumber":
                cucumberEA++;
                totalEA++;
                Debug.Log("Cucumber = " + cucumberEA);
                break;
            case "Cabage":
                cabageEA++;
                totalEA++;
                Debug.Log("Cabage = " + cabageEA);
                break;
        }

        
    }
}
