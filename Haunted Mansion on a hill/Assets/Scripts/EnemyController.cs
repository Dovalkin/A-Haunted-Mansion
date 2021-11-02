using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject characterDestination;

    //public AudioSource chaseScreaming;
    //public AudioClip chaseClip;
    //public AudioSource patrolWhispering;
    //public AudioClip patrolClip;

    [SerializeField] GameObject patrolMode;
    [SerializeField] GameObject chaseMode;

    [SerializeField] GameObject chaseStreaming;
    //[SerializeField] GameObject patrolWhispering;
    public float lookRadius = 35f;


    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        patrolMode.gameObject.SetActive(true);
        chaseMode.gameObject.SetActive(false);

        chaseStreaming.gameObject.SetActive(false);
        //patrolWhispering.gameObject.SetActive(true);
        //chaseScreaming = GetComponent<AudioSource>();
        //patrolWhispering = GetComponent<AudioSource>();

        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            //chaseScreaming.Play();
            //patrolWhispering.Pause();
            patrolMode.gameObject.SetActive(false);
            chaseMode.gameObject.SetActive(true);

            chaseStreaming.gameObject.SetActive(true);
            //patrolWhispering.gameObject.SetActive(false);

            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
        else
        {
            //chaseScreaming.Pause();
            //patrolWhispering.Play();
            patrolMode.gameObject.SetActive(true);
            chaseMode.gameObject.SetActive(false);

            chaseStreaming.gameObject.SetActive(false);
            //patrolWhispering.gameObject.SetActive(true);

            agent.SetDestination(characterDestination.transform.position);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
