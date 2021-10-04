using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    public static LightManager instance;

    [SerializeField]
    private GameObject globalLight;
    [SerializeField]
    private GameObject gameLight;    
    [SerializeField]
    private GameObject playerLight;    
    [SerializeField]
    private GameObject enemyLight;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;

        globalLight.GetComponent<Light2D>().enabled = true;
        gameLight.GetComponent<Light2D>().enabled = false;
        playerLight.GetComponent<Light2D>().enabled = false;
        enemyLight.GetComponent<Light2D>().enabled = false;
    }

    public void VariationLight()
    {
        globalLight.GetComponent<Light2D>().enabled = false;
        gameLight.GetComponent<Light2D>().enabled = true;
        playerLight.GetComponent<Light2D>().enabled = true;
        enemyLight.GetComponent<Light2D>().enabled = true;
    }
    
    public void ResetLight()
    {
        globalLight.GetComponent<Light2D>().enabled = true;
        gameLight.GetComponent<Light2D>().enabled = false;
        playerLight.GetComponent<Light2D>().enabled = false;
        enemyLight.GetComponent<Light2D>().enabled = false;
    }
}
