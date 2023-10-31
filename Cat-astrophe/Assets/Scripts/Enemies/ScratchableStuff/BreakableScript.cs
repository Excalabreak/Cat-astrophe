using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableScript : MonoBehaviour
{
    //health of the object
    [SerializeField] protected int maxHealth = 3;
    protected int currentHealth;

    //materials for feedback of damage
    private MeshRenderer mr;
    [SerializeField] private Material baseMat;
    [SerializeField] private Material halfMat;
    [SerializeField] private Material destroyedMat;

    //bool for when it can be damaged
    protected bool invincible = false;

    //stuff for points
    protected ScoreScript scoreScript;
    [SerializeField] protected int destroyScore = 3;

    protected void Awake()
    {
        currentHealth = maxHealth;
        mr = GetComponent<MeshRenderer>();
        scoreScript = GetComponent<ScoreScript>();
    }

    /// <summary>
    /// this will get called when the object gets damage
    /// </summary>
    /// <param name="damage">how much damage does object take</param>
    public virtual void DamageObject(int damage)
    {
        if (currentHealth > 0 && !invincible)
        {
            int damageScore;

            invincible = true;

            if (currentHealth >= damage)
            {
                damageScore = damage;
            }
            else
            {
                damageScore = damage - currentHealth;
            }

            currentHealth = currentHealth - damage;

            //scoreScript.AddScore(damageScore);
            if (currentHealth <= 0)
            {
                //scoreScript.AddScore(destroyScore);
            }
            

            StartCoroutine(DamageBlink());
        }
    }

    /// <summary>
    /// calculates which mat should be showing
    /// </summary>
    /// <returns>material of current health</returns>
    private Material GetMaterial()
    {
        float healthPercent = (float)currentHealth / (float)maxHealth;

        if (currentHealth <= 0)
        {
            return destroyedMat;
        }
        else if (healthPercent < .67f)
        {
            return halfMat;
        }
        else
        {
            return baseMat;
        }
    }

    //feedback for when object gets damaged
    protected virtual IEnumerator DamageBlink()
    {
        for (int i = 0; i < 5; i++)
        {
            mr.material = destroyedMat;
            yield return new WaitForSeconds(.1f);

            mr.material = GetMaterial();
            yield return new WaitForSeconds(.1f);
        }
        if (currentHealth > 0)
        {
            invincible = false;
        }
    }

    public bool Invincible
    {
        get { return invincible; }
    }
}
