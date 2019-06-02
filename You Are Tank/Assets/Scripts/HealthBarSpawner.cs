using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarSpawner : MonoBehaviour
{
    public GameObject healthBarPrefab;

    public void Spawn(TankPart entity)
    {
        GameObject healthBarObject = Instantiate(healthBarPrefab, transform);
        Slider healthSlider = healthBarObject.GetComponentInChildren<Slider>();
        UIFollowObject followScript = healthBarObject.GetComponent<UIFollowObject>();
        followScript.target = entity.transform;

        entity.healthSlider = healthSlider;
    }
}
