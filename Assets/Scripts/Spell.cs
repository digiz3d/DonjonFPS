﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : ScriptableObject {

    public string Name;
    public float Cooldown;

    private GameObject spellProjectile;

    public void Init(string name, float cooldown)
    {
        this.Name = name;
        this.Cooldown = cooldown;
        this.spellProjectile = Resources.Load("Spells/" + this.Name) as GameObject;
    }

    public void Launch(Vector3 location, Vector3 direction, Quaternion rotation)
    {
        /*
        // the spells don't longer inflict direct damages, the spell's magic ball does it
        Ray ray = new Ray(location, direction);

        
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, this.Range))
        {
            // Debug.Log(hitInfo.collider.gameObject.name); // prints the name of the object we're aiming at
            Vector3 hitPoint = hitInfo.point;
            GameObject target = hitInfo.collider.gameObject;

            
            HasHealth hasHealth = target.GetComponent<HasHealth>();
            if (hasHealth)
            {
                hasHealth.InflictDamages(this.Damages);
            }
            
        }
        */

        //Debug.DrawRay(location, direction * this.range, this.Color, 5.0f);
        Instantiate(spellProjectile, location+direction, rotation);
    }
}