using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBar : MonoBehaviour
{
    public SpriteRenderer Energybar;
    // public float Energy;
    // MaxEnergy = 100f;

    public float Energy, MaxEnergy = 100f;

    void Start()
    {
        Energy = MaxEnergy;
        // Energy = GameManager.instance.getStartingEnergy();
    }

    public void LossEnergy(float amount)
    {
        // Energy = Mathf.Clamp(Energy - amount, 0f, GameManager.instance.getStartingEnergy());
        // Energybar.transform.localScale = new Vector2(Energy / GameManager.instance.getStartingEnergy(), 1);

        Energy = Mathf.Clamp(Energy - amount, 0f, MaxEnergy);
        Energybar.transform.localScale = new Vector2(Energy / MaxEnergy, 1);
    }

    public void FullEnergy()
    {
        // Energybar.transform.localScale = new Vector2(GameManager.instance.getStartingEnergy() / GameManager.instance.getStartingEnergy(), 1);
        Energybar.transform.localScale = new Vector2(MaxEnergy / MaxEnergy, 1);
    }
}
