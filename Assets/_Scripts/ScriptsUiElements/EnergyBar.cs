using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public SpriteRenderer Energybar;
  public  float Energy, MaxEnergy =100f;

    void Start()
    {
        Energy = MaxEnergy; 
      
    }

    public void LossEnergy(float amount)
    {
        Energy = Mathf.Clamp(Energy - amount, 0f, MaxEnergy);
        Energybar.transform.localScale = new Vector2(Energy / MaxEnergy, 1);
    }

    public void FullEnergy()
    {
        Energybar.transform.localScale = new Vector2(MaxEnergy / MaxEnergy, 1);
    }
}
