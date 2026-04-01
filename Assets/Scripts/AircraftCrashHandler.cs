using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class AircraftCrashHandler : MonoBehaviour
{
    [Header("Effects and References")]
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private FlightExamManager examManager;

    //For the terrain collision effect, we will add collision physics with oncollisionenter without istrigger.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TakeoffArea") || collision.gameObject.CompareTag("LandingArea"))
        {
            //To prevent the plane from misperceiving a crash into terrain while on the runway and exploding:
            Debug.Log("landed on area!");
            return; 
        }

        if (collision.gameObject.CompareTag("Terrain"))
        {
            /*To apply an explosion effect when the aircraft crashes into any area labeled "terrain":
            if (examManager != null && examManager.hasEnteredZone && !examManager.threatCleared)
            {
                Debug.Log("OH NO! THE PLANE CRASHED!");
                if (explosionEffect !=null)
                {
                    Instantiate(explosionEffect, transform.position, transform.rotation);
                }
                //To save the camera and watch the explosion when the plane was destroyed:
                if (Camera.main !=null)
                {
                    Camera.main.transform.SetParent(null);
                }

                //The mission will fail because the plane crashed.
                if (examManager != null)
                {
                    examManager.UpdateHUD("CRITICAL FAILURE", "Aircraft Destroyed! Mission Failed.");
                }
                //destroy the plane:
                Destroy(gameObject);
            } 
            else 
            {
                Debug.Log("Safe zone terrain contact.");
            } */
            
            Debug.Log("You crashed terrain .Aircraft exploded!");
            Explode();
        }       
    }

    private void Explode()
    {
        Debug.Log("OH NO! THE PLANE CRASHED!");
        if (explosionEffect !=null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
        //To save the camera and watch the explosion when the plane was destroyed:
        if (Camera.main !=null)
        {
            Camera.main.transform.SetParent(null);
        }

        //The mission will fail because the plane crashed.
        if (examManager != null)
        {
            examManager.UpdateHUD("CRITICAL FAILURE:Aircraft crashed into the terrain!", "Aircraft Destroyed! Mission Failed.");
        }
        //destroy the plane:
        Destroy(gameObject);
    }
}
