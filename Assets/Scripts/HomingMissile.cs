
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class HomingMissile : MonoBehaviour
{
    [Header("Flight Settings")]
    [SerializeField] private float speed=30f; //speed can be adjust
    [SerializeField] private float rotationSpeed= 1.5f;
    [SerializeField] private string targetTag="Player";

    [Header("Explosion Effect")]
    [SerializeField] private GameObject explosionPrefab;

    private Transform target;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //I'm adding this because my plane moves on its own even if I don't press space.
        rb.linearDamping=0f;

        //When the missile is triggered, it locks onto the object labeled "player" on the scene.
        GameObject player=GameObject.FindGameObjectWithTag(targetTag);
        if(player != null)
        {
            target=player.transform;
        }
    }
    //We need to use fixedupdate for physical movements.
    void FixedUpdate()
    {
        if(target==null) return;

        //To find the target and turn in that direction:
        Vector3 direction =target.position - transform.position;
        direction.Normalize();
        Quaternion targetRotation=Quaternion.LookRotation(direction);

        //For the missile to turn in a curved path instead of a sudden turn:
        rb.MoveRotation(Quaternion.Slerp(transform.rotation,targetRotation,rotationSpeed*Time.fixedDeltaTime ));

        //so that it constantly moves in the direction the missile is pointing:
        rb.linearVelocity=transform.forward*speed;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log("The missile exploded on the plane!!!");

            //instantiate exlplosion effect:
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }
            //The camera shouldn't get lost with the plane.
            if (Camera.main != null)
            {
                Camera.main.transform.SetParent(null);
            }

            Destroy(other.gameObject);//destroy aircraft
            Destroy(gameObject);//destroy missile
        }
    }
}
