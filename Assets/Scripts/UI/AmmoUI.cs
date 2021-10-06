using UnityEngine;
using UnityEngine.UI;
public class AmmoUI : MonoBehaviour
{
    public Text _maxAmmo;
    public Text _currAmmo;

    public void SetCurrAmmo(int ammo)
    {
        _currAmmo.text = ammo.ToString();
    }
    
    public void SetMaxAmmo(int ammo)
    {
        _maxAmmo.text = ammo.ToString();
    }

}
