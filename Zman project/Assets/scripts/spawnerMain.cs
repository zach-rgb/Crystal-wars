using UnityEngine;
using UnityEngine.UIElements;

public class spawnerMain : MonoBehaviour
{
    public spawning spawning;
    [SerializeField] private float max_time;
    [SerializeField] private GameObject ObjectToSpawn;
    public target_finding target_finding;
    [SerializeField] private float max_distance;
    private bool spawn=false;
    [SerializeField] private string tag;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
            
            if (target_finding.findingDistanceTag(tag) < max_distance)
            {
                spawn = true;
            }
        
        

        
        if (timer.timer_func(max_time) && cost_checker.cost_check(cost))
        {
            Instantiate(ObjectToSpawn, position, rotation, ParentObject.transform);
        }
        if (spawn)
        {
            Debug.Log("hallo");
            spawning.spawn(max_time, ObjectToSpawn.GetComponent<cost>().CostOfObject, ObjectToSpawn, transform.position, transform.rotation, this.gameObject);
        }
    }
}

