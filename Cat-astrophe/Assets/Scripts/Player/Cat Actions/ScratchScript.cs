using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchScript : MonoBehaviour
{
    //vars for getting caught damaging objects
    private PlayerDetected playerDetected;
    private bool wasWarned = false;
    private bool caughtScraching = false;

    //vars for debuff when getting caught once
    private PlayerMotion playerMotion;
    //[SerializeField] private GameOverUI gameOverUI;

    //vars to render scrach
    [SerializeField] private GameObject scratchCollider;
    private MeshRenderer scratchMR;

    //how much damage the cat does
    [SerializeField] private int scratchStrength = 1;

    //var to make sure how long the hitbox is active for
    [SerializeField] float scratchTime = .5f;
    private bool isScratching = false;

    //vars for cone of shame
    [SerializeField] private MeshRenderer coneMR;

    //bool to reset cone of shame
    public bool testConeReset = false;

    private void Awake()
    {
        playerMotion = GetComponent<PlayerMotion>();
        playerDetected = GetComponent<PlayerDetected>();
        scratchMR = scratchCollider.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (testConeReset)
        {
            testConeReset = false;
            ResetConeOfShame();
        }
    }

    //turns isScratching on
    public void HandleScratch()
    {
        StartCoroutine(Scratch());
    }

    //will scrach objects tagged with breakable
    private void OnTriggerStay(Collider other)
    {
        if (isScratching && other.gameObject.tag == "Breakable")
        {
            if (playerDetected.IsDetected && !caughtScraching)
            {
                if (wasWarned)
                {
                    caughtScraching = true;
                    //gameOverUI.SetUpGameOverUI();
                    Debug.Log("GAME OVER");

                    gameObject.SetActive(false);
                }
                else
                {
                    wasWarned = true;
                    caughtScraching = true;
                    coneMR.enabled = true;
                    playerMotion.HandleConeOfShame();
                    //gameOverUI.SetUpConeOfShameUI();
                    Debug.Log("CONE OF SHAME");
                }
            }
            else
            {
                BreakableScript breakScript = other.gameObject.GetComponent<BreakableScript>();

                isScratching = false;

                if (!breakScript.Invincible)
                {
                    breakScript.DamageObject(scratchStrength);
                }

                scratchMR.enabled = false;
            }
        }
    }

    public void ResetConeOfShame()
    {
        coneMR.enabled = false;
        playerMotion.ResetStats();
        wasWarned = false;
    }
    
    /// <summary>
    /// this coroutine will make sure the hitbox for the cat is on for a certian amount of time
    /// </summary>
    private IEnumerator Scratch()
    {
        //Debug.Log("hi");
        scratchMR.enabled = true;
        isScratching = true;

        yield return new WaitForSeconds(scratchTime);

        scratchMR.enabled = false;
        isScratching = false;
        caughtScraching = false;
    }
}
