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
    private int mode;
    public List<(float, GameObject)> Targetdistances = new List<(float, GameObject)>();
    private float time_elasped

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (this.tag=="player"){
            mode=1
        }
        else if(this.tag=="AI"){
            mode=2
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
            
            Targetdistances.Clear();

        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject target in targets)
        {
            Targetdistances.Add((Vector3.Distance(target.transform.position, transform.position), target));
        }
        Targetdistances.Sort((a, b) => a.Item1.CompareTo(b.Item1));
        if (Targetdistances[0].Item1 < max_distance){
            spawn=true
        }
        
        
    


    if (mode==1){
        
        if ((time_elasped % 60) >= max_time && spawn && ObjectToSpawn.GetComponent<cost>().CostOfObject<storage.player_metal)
        {
            time_elasped = 0;
            Instantiate(ObjectToSpawn, transform.position, transform.rotation, transform);
        }
    }
    else if(mode==2){
        if ((time_elasped % 60) >= max_time && spawn && ObjectToSpawn.GetComponent<cost>().CostOfObject<storage.AI_metal)
        {
            time_elasped = 0;
            Instantiate(ObjectToSpawn, transform.position, transform.rotation, transform);
        }
    }
        
    }
}

