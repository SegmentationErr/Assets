using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private float IerpSpeed;

    [SerializeField]
    private Image health;

    [SerializeField]
    private TMP_Text valueText;

    //[SerializeField]
    //private Color fullColor;

    //[SerializeField]
    //private Color lowColor;

    public float MaxHealth { get; set; }

    public float Value
    {
        set
        {
            string[] tmp = valueText.text.Split(':');
            valueText.text = tmp[0] + ": " + value;
            fillAmount = MapHealth(value, 0, MaxHealth, 0, 1);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DealHealthBar();
    }

    private void DealHealthBar()
    {
        if (fillAmount != health.fillAmount) 
        {
           health.fillAmount = Mathf.Lerp(health.fillAmount,fillAmount, Time.deltaTime*IerpSpeed);
        }
        //health.color = Color.Lerp(lowColor, fullColor, fillAmount);
    }

    private float MapHealth(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
