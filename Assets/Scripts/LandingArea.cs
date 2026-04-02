using UnityEngine;

public class LandingArea : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    
    private void OnCollisionEnter(Collision collision)
    {
        //We are turning the landing strip into an impassable surface.
        if (collision.gameObject.CompareTag("Player"))
        {
            //If the plane bypassed the danger zone:
            if (examManager != null && examManager.threatCleared)
            {
                examManager.CompleteMission();
                //Stop the aircraft after a successful landing.
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                if(rb != null) rb.linearVelocity = Vector3.zero; 
            }
            else
            {
                //If the aircraft failed to successfully clear the danger zone:
                examManager.UpdateHUD("You must survive the danger zone first!", "Landing Refused!");
            }
        }
    }
}
