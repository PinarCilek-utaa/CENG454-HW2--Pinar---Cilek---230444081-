using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [Header("Missile Assets")]
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;

    //To track the active missile:
    private GameObject activeMissile;

    public GameObject Launch()
    {
        //If there's already a missile on the scene, to avoid launching another one:
        if(activeMissile !=null) return activeMissile;

        if(missilePrefab !=null && launchPoint != null)
        {
            //To create the missile:
            activeMissile=Instantiate(missilePrefab,launchPoint.position,launchPoint.rotation);

            //To initiate sound with the audiosource component attached to the missile:
            AudioSource missileSound =activeMissile.GetComponent<AudioSource>();
            if(missileSound !=null && missileSound.clip != null)
            {
                missileSound.Play();
            }

            return activeMissile;
        }
        return null;
    }

    public void DestroyActiveMissile()
    {
        //If the player escaped the danger zone, to destroy the missile:
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile=null;
        }
    }
}
