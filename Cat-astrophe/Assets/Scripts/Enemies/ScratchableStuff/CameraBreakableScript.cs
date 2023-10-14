using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBreakableScript : BreakableScript
{
    //because there are 2 mats on camera, had to make this one
    [SerializeField] private MeshRenderer mr1;
    [SerializeField] private MeshRenderer mr2;

    [SerializeField] private Material baseMat1;
    [SerializeField] private Material baseMat2;
    [SerializeField] private Material damageMat;

    protected void resetMaterial()
    {
        mr1.material = baseMat1;
        mr2.material = baseMat2;
    }

    protected override IEnumerator DamageBlink()
    {
        for (int i = 0; i < 5; i++)
        {
            mr1.material = damageMat;
            mr2.material = damageMat;
            yield return new WaitForSeconds(.1f);

            resetMaterial();
            yield return new WaitForSeconds(.1f);
        }
        if (currentHealth > 0)
        {
            invincible = false;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
