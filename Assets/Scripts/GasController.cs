using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasController : MonoBehaviour
{
    #region Singleton
    private static GasController controller;

    public static GasController Controller
    {
        get { return controller; }
    }
    #endregion

    private List<GasObject> gasParticles;

    [SerializeField] float TimeToComplete = 30f;
    [SerializeField] float scalingFactor = 1f;

    private Image gasMeter;
    private float fillAmount = 0;

    private int TotalParticles;
    private int CurrentNumParticles;

    public GameObject Winscreen;
    public GameObject Losescreen;
    
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
        gasMeter = GameObject.FindGameObjectWithTag("GasMeter").GetComponent<Image>();
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
        if (CurrentNumParticles == 0) {
            Winscreen.SetActive(true);
        }
    }

    public bool isIn(GasObject _gas)
    {
        return gasParticles.Contains(_gas);
    }

    // Update is called once per frame
    void Update()
    {
        FillGasMeter();
    }

    private void FillGasMeter()
    {
        fillAmount += Time.deltaTime * (0.1f * ((float)CurrentNumParticles/TotalParticles)) / TimeToComplete * scalingFactor;
        gasMeter.fillAmount = fillAmount;

        if (fillAmount >= 1) {
            Losescreen.SetActive(true);
        }
    }
}
