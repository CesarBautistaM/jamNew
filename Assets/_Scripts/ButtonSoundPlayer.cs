/*
Author: Andres Mrad (Q-ro)
Date: Monday 06/April/2020 @ 21:05:03
Description:  Plays a sound when a button on the menu is selected 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(AudioSource))]
public class ButtonSoundPlayer : MonoBehaviour, IPointerEnterHandler
{

    #region Inspector Variables

    [SerializeField] private AudioClip buttonSoundClip = null;

    #endregion

    #region Private Variables

    private AudioSource buttonSoundSource;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        this.buttonSoundSource = this.gameObject.GetComponent<AudioSource>();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (this.buttonSoundClip != null)
            this.buttonSoundSource.PlayOneShot(buttonSoundClip);
        else
            this.buttonSoundSource.PlayOneShot(this.buttonSoundSource.clip);
    }
}
