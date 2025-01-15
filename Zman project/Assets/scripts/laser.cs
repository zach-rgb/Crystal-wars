using UnityEngine;


public class laser : MonoBehaviour
{
    public timer timer;
    [SerializeField] private float laser_time;
    [SerializeField] private float charge_time;
    public target_finding target_finding;
    private bool charging = false;
    private bool hit = false;
    [SerializeField] private float speed;
    private Vector3 original_position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       original_position=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timer.timer_func(laser_time) && !charging && !hit)
        {
            transform.localScale = new Vector3(1, 1, transform.localScale.z);
            transform.LookAt(target_finding.findingGameObjectLayer(6).transform, Vector3.up);
            Debug.Log(timer.timer_func(laser_time));
            transform.position += transform.forward * speed/2*Time.deltaTime;
            transform.localScale += new Vector3(0, 0, speed) * Time.deltaTime;

        }
        else if (charging && timer.timer_func(charge_time))
        {
            charging = false;
            hit = false;
        }
        else if (timer.timer_func(laser_time))
        {
            charging = true;
            hit = false;
            transform.localScale = new Vector3(0, 0, 0);
            transform.position = original_position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            
            hit = true;
            other.GetComponent<deathcondition>().HP -= 1;

        }
    }
}