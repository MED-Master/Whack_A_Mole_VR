﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour{

    public bool isActive = false;
    public int redOdds = 8;

    private float lifeTime = 5f;
    private float timer = 0f;
    private bool startShining = true;
    private bool startNormal = true;
    private Material[] moleMaterial = new Material[2];

    void Start()
    {
        
    }

    void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer > lifeTime) //During the lifeTime of the mall, we make it shine
            {
                if (startNormal)
                {
                    makeItNormal();
                    startNormal = false;
                }
                timer = 0;
                startShining = true;
                isActive = false;
            }
            else
            {
                if (startShining)
                {
                    makeItShine();
                    startShining = false;
                }
                startNormal = true;
            }
        }
    }

    private void makeItShine() //Make the mole shine in green or red
    {
        Material currentMaterial;
        int odds = Random.Range(0, redOdds);
        if (odds != redOdds / 2)
        {
            currentMaterial = (Material)Resources.Load("Materials/green");
        }
        else
        {
            currentMaterial = (Material)Resources.Load("Materials/red");
        }

        moleMaterial[0] = (Material)Resources.Load("Materials/mole");
        moleMaterial[1] = currentMaterial;
        gameObject.GetComponent<MeshRenderer>().materials = moleMaterial;
    }

    private void makeItNormal() //Make the mole going back to normal
    {
        moleMaterial[0] = (Material)Resources.Load("Materials/mole");
        moleMaterial[1] = null;
        gameObject.GetComponent<MeshRenderer>().materials = moleMaterial;
    }
}