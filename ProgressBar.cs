using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{

    public int maximum;
    public int current;
    public Image mask;

    void Start()
    {
        
    }


    void Update()
    {
        //  current = Jetpack.myHealth;
    //    current = GetComponent<Jetpack>().myHealth;
       
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current /(float)maximum;
        mask.fillAmount = fillAmount;
    }
}
