using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchScript : MonoBehaviour
{
    //vars for getting caught damaging objects
    private PlayerDetected playerDetected;
    //private bool wasWarned = false;
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
    private bool canScratch = true;

    //vars for cone of shame
    private ConeOfShame coneOfShame;

    //Audio
    AudioManager audioManager;

    [SerializeField] private GameObject warningModel;

    //on awake get all components
    private void Awake()
    {
        playerMotion = GetComponent<PlayerMotion>();
        playerDetected = GetComponent<PlayerDetected>();
        scratchMR = scratchCollider.GetComponent<MeshRenderer>();
        coneOfShame = GetComponent<ConeOfShame>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        //scratchStrength = startingScratchStrength;
    }

    /// <summary>
    /// calls the scratch coroutine if the player can scratch
    /// </summary>
    public void HandleScratch()
    {
        if (canScratch)
        {
            StartCoroutine(Scratch());
        }
    }

    //will scrach objects tagged with breakable
    private void OnTriggerStay(Collider other)
    {
        if (isScratching && other.gameObject.tag == "Breakable")
        {
            if (playerDetected.IsDetected && !caughtScraching)
            {
                if (coneOfShame.HasConeOfShame)
                {
                    //gameover scene
                    caughtScraching = true;
                    RemoveNekoTe();
                    //gameOverUI.SetUpGameOverUI();
                    Debug.Log("GAME OVER");
                    coneOfShame.OnGameOver();
                    CursorManager.Instance.ShowCursor();
                }
                else if(coneOfShame.FirstWarning)
                {
                    //score count in UI
                    ScoreManager.scoreCount -= 5;
                    caughtScraching = true;
                    RemoveNekoTe();
                    coneOfShame.AddConeOfShame();
                    //gameOverUI.SetUpConeOfShameUI();
                    Debug.Log("CONE OF SHAME");
                    StartCoroutine(GracePeriod());
                }
                else
                {
                    ScoreManager.scoreCount -= 5;
                    caughtScraching = true;
                    coneOfShame.GiveFirstWarning();
                    StartCoroutine(GracePeriod());
                    RemoveNekoTe();
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
    /// cat gains buff from Neko Te Power Ups
    /// </summary>
    public void PickUpNekoTe()
    {
        if (!hasNekoTe)
        {
            hasNekoTe = true;
            nekoTeCurrentDurability = nekoTeMaxDurability;
            scratchStrength = scratchStrength + nekoTeBuff;
            audioManager.PlaySFX(audioManager.eat);
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
        if (hasNekoTe)
        {
            hasNekoTe = false;
            nekoTeCurrentDurability = 0;
            scratchStrength = scratchStrength - nekoTeBuff;
            audioManager.PlaySFX(audioManager.eat);
            clawMR.SetActive(false);
        }
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

    /// <summary>
    /// when the player gets caught/cone of shame,
    /// gives a grace period of when they can't get hurt and can't scratch
    /// </summary>
    /// <returns></returns>
    private IEnumerator GracePeriod()
    {
        canScratch = false;
        for (int i = 0; i < 8; i++)
        {
            warningModel.SetActive(true);
            playerDetected.ShowAlert();
            yield return new WaitForSeconds(.2f);

            warningModel.SetActive(false);
            yield return new WaitForSeconds(.2f);
        }
        canScratch = true;
        playerDetected.HideAlert();
    }
}
