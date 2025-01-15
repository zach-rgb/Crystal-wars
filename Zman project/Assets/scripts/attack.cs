
using UnityEngine;
using UnityEngine.AI;

public class attack : MonoBehaviour
{
    private GameObject target;
    private GameObject other_target; // two possible targets
    [SerializeField] private GameObject ObjectToSpawn; // missile that the tank will spam 
    [SerializeField] private float time; // max time on the timer  
    public target_finding Target_Finding; // script that i am referencing to use a function
    public timer timer;
    private GameObject closetTarget; // now an empty variable that will be the closest of the two object
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.Find("ball_group");
        other_target = GameObject.Find("buildings");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (target.transform.childCount > 0 || other_target.transform.childCount > 0)
        {
            if (timer.timer_func(time)) { 
                Instantiate(ObjectToSpawn, transform.position, transform.rotation);
            }
        
            
            if (target.transform.childCount > 0 || other_target.transform.childCount > 0)
            {

                closetTarget = Target_Finding.findingGameObjectLayer(3);
                transform.GetComponent<NavMeshAgent>().destination = closetTarget.transform.position;
            }
        
        }
        else
        {
            transform.GetComponent<NavMeshAgent>().destination = transform.parent.position;
        }
    }
}