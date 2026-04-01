using UnityEngine;

public class TakeoffArea : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    // `exit` is written to activate when the aircraft leaves the runway:
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (examManager != null && !examManager.hasTakenOff)
            {
                // The plane's takeoff is detected:
                examManager.TakeOff(); 
            }
        }
    }

    
}
