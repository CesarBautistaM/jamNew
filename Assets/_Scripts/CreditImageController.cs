/*
Author: Andres Mrad (Q-ro)
Date: Monday 06/April/2020 @ 18:37:21
Description:  Handles the interaction between  
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(Outline))]
public class CreditImageController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    #region Inspector Variables

    [SerializeField] private GameObject hiddenContent = null;
    [SerializeField] private Text creditsInfoDisplay;
    [SerializeField] private string nombreCredits;
    [SerializeField] private string rolCredits;

    #endregion

    #region Private Variables

    private Outline _portraitHighligth;

    #endregion

    void Start()
    {
        _portraitHighligth = this.gameObject.GetComponent<Outline>();
        _portraitHighligth.enabled = (false);
    }


    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        _portraitHighligth.enabled = (false);

    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        _portraitHighligth.enabled = (true);

    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        this.creditsInfoDisplay.text = string.Format("Nombre: {0}\nRol: {1}", this.nombreCredits, this.rolCredits);

        if (hiddenContent)
            hiddenContent.SetActive(true);
    }

}
