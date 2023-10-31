using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    //[SerializeField] private int startingScratchStrength = 1;
    private int scratchStrength = 1;

    //neko te variables
    [SerializeField] private GameObject clawMR;
    [SerializeField] private int nekoTeBuff = 1;
    [SerializeField] private int nekoTeMaxDurability = 3;
    private int nekoTeCurrentDurability = 0;
    private bool hasNekoTe = false;

    //var to make sure how long the hitbox is active for
    [SerializeField] float scratchTime = .5f;
    private bool isScratching = false;

    //vars for cone of shame
    [SerializeField] private MeshRenderer coneMR;


    private void Awake()
    {
        playerMotion = GetComponent<PlayerMotion>();
        playerDetected = GetComponent<PlayerDetected>();
        scratchMR = scratchCollider.GetComponent<MeshRenderer>();

        //scratchStrength = startingScratchStrength;
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
                    //gameover scene
                    SceneManager.LoadScene(2);
                    caughtScraching = true;
                    RemoveNekoTe();
                    //gameOverUI.SetUpGameOverUI();
                    Debug.Log("GAME OVER");
                   

                    gameObject.SetActive(false);
                }
                else
                {
                    //score count in UI
                    ScoreManager.scoreCount -= 5;
                    wasWarned = true;
                    caughtScraching = true;
                    coneMR.enabled = true;
                    RemoveNekoTe();
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
                    if (hasNekoTe)
                    {
                        nekoTeCurrentDurability--;
                        if (nekoTeCurrentDurability <= 0)
                        {
                            RemoveNekoTe();
                            //score count in UI
                            ScoreManager.scoreCount += 8;
                        }
                    }
                }

                scratchMR.enabled = false;
            }
        }
    }

    /// <summary>
    /// removes Cone of shame from cat
    /// </summary>
    public void ResetConeOfShame()
    {
        coneMR.enabled = false;
        playerMotion.ResetStats();
        wasWarned = false;
    }

    /// <summary>
    /// cat gains buff from Neko Te Power Ups
    /// </summary>
    public void PickUpNekoTe()
    {
        if (!hasNekoTe)
        {
            hasNekoTe = true;
            nekoTeCurrentDurability = nekoTeMaxDurability;
            scratchStrength = scratchStrength + nekoTeBuff;

            clawMR.SetActive(true);
        }
        else
        {
            nekoTeCurrentDurability = nekoTeMaxDurability;
        }
    }

    /// <summary>
    /// removes Neko Te buffs from power up
    /// </summary>
    private void RemoveNekoTe()
    {
        hasNekoTe = false;
        nekoTeCurrentDurability = 0;
        scratchStrength = scratchStrength - nekoTeBuff;

        clawMR.SetActive(false);
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
