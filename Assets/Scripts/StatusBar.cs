using UnityEngine;

public class StatusBar : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetEnergyLevel(float energyPercent)
    {
        transform.localScale = new Vector3(energyPercent, 1,1);
    }
}
