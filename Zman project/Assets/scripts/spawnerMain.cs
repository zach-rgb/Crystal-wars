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
    public storage storage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_elasped += Time.deltaTime;
        
            
            if (target_finding.findingDistanceTag(tag) < max_distance)
            {
                spawn = true;
            }
        
        
        time_elasped += Time.deltaTime;

        if (Mathf.FloorToInt(time_elasped % 60) >= time)
        {
            time_elasped = 0;
            return true;
        }
        
        if ((time_elasped % 60) >= time && ObjectToSpawn.GetComponent<cost>().CostOfObject<storage.)
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

