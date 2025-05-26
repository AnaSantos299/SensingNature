using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

/// <summary>
/// Yarn commands can be called directly on the Yarn script; make sure that you are using all the arguments  or else it will fail the call
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Background Image or Animation
    //there is a deepBackground sprite with a color; the background sprite is the one that changes on top of the deepBackground; 
    //the background sprite can be a single image or an animation, with transparent or soliod background
    public GameObject backgroundSprite;



    //Load a single Image
    [YarnCommand("changebackground")]
    public void ChangeBackground(string folderName, string filename)
    {
        //Images need to be in the Resources folder
        Sprite sp1 = Resources.Load<Sprite>("Images/" + folderName + "/" + filename);
        backgroundSprite.GetComponent<Image>().sprite = sp1;
    }

    Coroutine routine;//stores a reference to the coroutine so that it can be stopped

    //Load an animation (images going from minfilename to maxfilename, looping or not, with a duration per image)
    [YarnCommand("animationBackgroundPlay")]
    public void AnimationBackgroundPlay(string folderName, int minfilename, int maxfilename, bool loop, float durationPerImage)
    {
        routine = StartCoroutine(AnimationBackgroundPlayCoroutine(folderName, minfilename, maxfilename, loop, durationPerImage));
    }

    IEnumerator AnimationBackgroundPlayCoroutine(string folderName, int minfilename, int maxfilename, bool loop, float durationPerImage = 0.5f)
    {
        for (int i = minfilename; i <= maxfilename; i++)
        {
            //Images need to be in the Resources folder
            Sprite sp1 = Resources.Load<Sprite>("Images/" + folderName + "/" + i.ToString());
            backgroundSprite.GetComponent<Image>().sprite = sp1;
            yield return new WaitForSeconds(durationPerImage);
            if (loop == true)
            {
                if (i == maxfilename)
                {
                    i = minfilename - 1; //the loop will add 1 to i, so we need to set it to -1
                }
            }
        }
    }

    //Stop the animation coroutine
    [YarnCommand("animationBackgroundStop")]
    public void AnimationBackgroundStop()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
        }
    }
    #endregion

    #region Accept or Reject Call
    public DialogueRunner dialogueRunner;
    public GameObject rejectButton;
    public GameObject acceptButton;

    //directly called by the UI buttons
    public void AcceptCall()
    {
        dialogueRunner.Stop();
        //jumpt to node acceptCall
        dialogueRunner.StartDialogue("acceptCall");
    }
    //directly called by the UI buttons
    public void RejectCall()
    {
        dialogueRunner.Stop();
        //jumpt to node rejectCall
        dialogueRunner.StartDialogue("rejectCall");
    }

    //show or hide the UI elements (accept and reject buttons)
    [YarnCommand("showCallButtons")]
    public void ShowCallButtons()
    {
        rejectButton.SetActive(true);
        acceptButton.SetActive(true);
    }
    [YarnCommand("hideCallButtons")]
    public void HideCallButtons()
    {
        rejectButton.SetActive(false);
        acceptButton.SetActive(false);
    }
    #endregion

    #region Show or Hide UI elements
    public GameObject smallLogoImage;
    public GameObject bigLogoImage;
    public GameObject multipleButtonsImage;
    public GameObject blueOrb;

    [YarnCommand("showSmallLogo")]
    public void ShowSmallLogo()
    {
        smallLogoImage.SetActive(true);
    }
    [YarnCommand("hideSmallLogo")]
    public void HideSmallLogo()
    {
        smallLogoImage.SetActive(false);
    }
    [YarnCommand("showBigLogo")]
    public void ShowBigLogo()
    {
        bigLogoImage.SetActive(true);
    }
    [YarnCommand("hideBigLogo")]
    public void HideBigLogo()
    {
        bigLogoImage.SetActive(false);
    }
    [YarnCommand("showMultipleButtons")]
    public void ShowMultipleButtons()
    {
        multipleButtonsImage.SetActive(true);
    }
    [YarnCommand("hideMultipleButtons")]
    public void HideMultipleButtons()
    {
        multipleButtonsImage.SetActive(false);
    }
    [YarnCommand("showBlueOrb")]
    public void ShowBlueOrb()
    {
        blueOrb.SetActive(true);
    }
    [YarnCommand("hideBlueOrb")]
    public void HideBlueOrb()
    {
        blueOrb.SetActive(false);
    }
    #endregion

    #region Play Sound Fx
    //doesnt work for multiple sounds at once; currently used only for the phone ring
    public AudioSource soundfx;
    [YarnCommand("playSound")]
    public void PlaySound(string filename, bool loop = false)
    {
        //Debug.Log("Play Sound " + filename);
        soundfx.Stop();
        //Sounds must be in the Resources folder
        AudioClip au1 = Resources.Load<AudioClip>("Soundfx/" + filename);
        soundfx.clip = au1;
        soundfx.loop = loop;
        soundfx.Play();
    }

    [YarnCommand("stopSound")]
    public void StopSound()
    {
        soundfx.Stop();
    }
    #endregion
}
