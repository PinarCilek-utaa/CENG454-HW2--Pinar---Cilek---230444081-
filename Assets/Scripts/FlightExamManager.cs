using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    //We define variables to be able to modify the `scriptText` and `missionText` in Unity.
    [Header ("HUD Settings")]
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    //We define three boolean variables to understand which stage of the game we are in.
    [Header ("Mission Status")]
    public bool hasTakenOff =false;      
    public bool hasEnteredZone =false;
    public bool threatCleared =false;
    public bool isMissionComplete =false;

    //We will use methods to determine what to write based on the aircraft's movements.
    public void Start()
    {
        UpdateHUD("TAKE OFF FIRST!","THE GAME HAS BEGUN!");
        statusText.color=UnityEngine.Color.yellow;
    }

    public void TakeOff()
    {
        if (!hasTakenOff)
        {
            hasTakenOff =true;
            Debug.Log("Takeoff successful! The plane has taken off!");
            UpdateHUD("Proceed to the Danger zone!","The plane has taken off!");
            statusText.color=UnityEngine.Color.orange;
        }
    }

    public void EnterDangerZone()
    {
        if(threatCleared) return;
        UpdateHUD("Escape the area or evade the missile!"," ENTERED DANGEROUS AREA!!");
        statusText.color=UnityEngine.Color.red;
    }

    public void ExitDangerZone()
    {
        threatCleared = true;
        UpdateHUD("Proceed safely to the landing area.","SAFE AIRSPACE");
        statusText.color=UnityEngine.Color.green;
    }

    public void CompleteMission()
    {
        if(threatCleared)
        {
            isMissionComplete = true;
            UpdateHUD("A safe landing was achieved.","MISSION COMPLETED!");
            Debug.Log("Mission Success ! ");
            statusText.color=UnityEngine.Color.magenta; 
        }
        else
        {
            UpdateHUD("You must survive the danger zone first!", "Landing Refused!");
            Debug.Log("Error: You cannot land without entering the threat zone!");
        }
    }

    public void UpdateHUD(string missionObj, string status)
    {
        if(missionText != null) missionText.text = "Mission: " + missionObj;
        if(statusText != null) statusText.text = "Status: " + status;
    }
}
