using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiceCollider : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<DiceThrow>().OnSideHit(gameObject.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}