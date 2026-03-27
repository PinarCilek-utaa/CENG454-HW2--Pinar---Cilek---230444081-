using UnityEngine;
//for using Coroutine
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [Header("System References")]
    //This sensor needs to be connected to the FlightExamManager object in order to print text to the screen.
    [SerializeField] private FlightExamManager examManager;

    [Header("Settings")]
    //We define these two variables so that they can be modified from the inspector.
    [SerializeField] private float missileDelay = 5f;
    [SerializeField ] private string playerTag= "Player";

    private Coroutine activeCountdown;
    private bool isPlayerInZone =false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isPlayerInZone =true;

            if(examManager != null)
            {
                examManager.EnterDangerZone();
            }

            if (activeCountdown != null)
            {
                //We will stop the counter with a stopcoroutine when the aircraft leaves the area, i.e., when the ontriggerexit signal is activated.
                StopCoroutine(activeCountdown);
            }

            activeCountdown= StartCoroutine(CountdownRoutine(other.transform));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isPlayerInZone =false;

            //To turn the HUD green:
            if(examManager != null)
            {
                examManager.ExitDangerZone();
            }

            //Ghost Missile Solution : If the plane takes off before 5 seconds are up, it will destroy the counter.
            if(activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown= null;
            }
        }
    }

    private IEnumerator CountdownRoutine (Transform targetTransform)
    {
        //Wait 5 seconds for the plane.
        yield return new WaitForSeconds(missileDelay);

        //If the plane remains in the air for more than 5 seconds, it launches a missile.
        if (isPlayerInZone)
        {
            Debug.Log("You stayed there for more than 5 seconds! A missile is being launched!!");

        }
    }
}
