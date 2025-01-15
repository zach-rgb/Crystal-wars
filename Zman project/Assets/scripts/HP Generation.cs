using UnityEngine;

public class HPGeneration : MonoBehaviour
{

    public timer timer;
    public float time;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timer_func(time / this.gameObject.GetComponent<deathcondition>().MaxHP))
        {
            this.gameObject.GetComponent<deathcondition>().HP += 1;

        }

    }
    
}
