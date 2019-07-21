using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private List<Collider> cols;

    [SerializeField] LayerMask mask;

    List<GameObject> gasParticles;

    private void Awake()
    {
        gasParticles = new List<GameObject>();
    }

    void Start()
    {
        cols = new List<Collider>(GetComponentsInChildren<Collider>());
    }

    public void Placed()
    {
        transform.localScale *= 1/0.9f;
        foreach (Collider col in cols)
        { 
        Bounds b = col.bounds;
        Collider[] colliders = Physics.OverlapBox(b.center, b.extents, transform.rotation, mask);
            foreach (Collider overlap in colliders)
            {
                //Debug.Log(overlap.name);
                gasParticles.Add(overlap.gameObject);
                overlap.gameObject.SetActive(false);
            }
        }
    }

    public void Pickup()
    {
        transform.localScale *= 0.9f;
        if (gasParticles.Count > 0)
        {
            foreach (GameObject gas in gasParticles)
            {
                gas.SetActive(true);               
            }
        }
        gasParticles.Clear();
    }


    void Update()
    {
        
    }
}
