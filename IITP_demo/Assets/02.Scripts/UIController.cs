using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UIController : MonoBehaviour
{
    private enum State { Yet, Done };
    private State messagingState = State.Yet;

    public GameObject countChecker;
    public GameObject ui_messaging1;
    public GameObject ui_messaging2;

    public SteamVR_Action_Vibration hapticAction;
    public SteamVR_Action_Boolean trackpadAction;

    // Start is called before the first frame update
    void Start()
    {
        ui_messaging1.SetActive(true);
        ui_messaging2.SetActive(false);

        //Pulse(2, 150, 75, SteamVR_Input_Sources.LeftHand);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(trackpadAction.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Pulse(1, 150, 75, SteamVR_Input_Sources.LeftHand);
        }*/
        if(messagingState == State.Yet && countChecker.GetComponent<ObjectCounter>().totalEA > 4)
        {
            messagingState = State.Done;
            hapticAction.Execute(0, 1, 150, 75, SteamVR_Input_Sources.LeftHand);
            StartCoroutine(SecondUIOnOff());
        }
    }

    public void UIOnOff()
    {
        if (messagingState == State.Yet)
        {
            if (ui_messaging1.activeSelf == true)
            {
                ui_messaging1.SetActive(false);
            }
            else if (ui_messaging1.activeSelf == false)
            {
                ui_messaging1.SetActive(true);
            }
        }

        else if (messagingState == State.Done)
        {
            if (ui_messaging2.activeSelf == true)
            {
                ui_messaging2.SetActive(false);
            }
            else if (ui_messaging2.activeSelf == false)
            {
                ui_messaging2.SetActive(true);
            }
        }
    }
    IEnumerator SecondUIOnOff()
    {
        yield return new WaitForSeconds(1.0f);
        ui_messaging1.SetActive(false);
        ui_messaging2.SetActive(true);
    }

    /*private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);

        Debug.Log("pulse");
    }*/
}
