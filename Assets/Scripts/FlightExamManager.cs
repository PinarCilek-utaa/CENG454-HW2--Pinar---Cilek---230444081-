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
    public bool hasTakenoff = false;
    public bool threatCleared = false;
    public bool missionComplete = false;

    //We will use methods to determine what to write based on the aircraft's movements.

    public void Start()
    {
        UpdateHUD("Take off and proceed to the safe zone !","The System Is Normal");
        statusText.color=UnityEngine.Color.yellow;
    }

    public void EnterDangerZone()
    {
        if(threatCleared) return;
        UpdateHUD("Escape the area or evade the missile!","Entered a Dangerous Zone!");
        statusText.color=UnityEngine.Color.red;
    }

    public void ExitDangerZone()
    {
        if(threatCleared) return;
        UpdateHUD("Proceed safely to the landing area.","Safe Airspace");
        statusText.color=UnityEngine.Color.green;
    }

    public void CompleteMission()
    {
        if(threatCleared && hasTakenoff)
        {
            missionComplete =true;
            UpdateHUD("Mission Completed!","A safe landing was achieved.");
            statusText.color=UnityEngine.Color.pink;
        }
    }

    public void UpdateHUD(string missionObj, string status)
    {
        if(missionText != null) missionText.text="Mission: " + missionObj;
        if(statusText != null) statusText.text= "Status: " + status;
    }


}

