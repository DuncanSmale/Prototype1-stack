using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasController : MonoBehaviour
{
    #region Singleton
    private static GasController controller;

    public static GasController Controller
    {
        get { return controller; }
        private set { controller = value; }
    }
    #endregion

    private List<GasObject> gasParticles;

    [SerializeField] float TimeToComplete = 30f;

    private int TotalParticles;
    private int CurrentNumParticles;

    private void Awake()
    {

        if (controller == null)
        {
            controller = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gasParticles = new List<GasObject>(FindObjectsOfType<GasObject>());
        TotalParticles = gasParticles.Count;
        CurrentNumParticles = TotalParticles;
    }

    public void addGas(GasObject _gas)
    {
        CurrentNumParticles += 1;
        gasParticles.Add(_gas);
    }

    public void removeGas(GasObject _gas)
    {
        CurrentNumParticles -= 1;
        gasParticles.Remove(_gas);
    }

    public bool isIn(GasObject _gas)
    {
        return gasParticles.Contains(_gas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
