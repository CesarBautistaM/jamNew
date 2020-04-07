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

public class CreditImageController : MonoBehaviour, IPointerClickHandler
{

    #region Inspector Variables

    [SerializeField] private GameObject hiddenContent = null;
    [SerializeField] private Text creditsInfoDisplay;
    [SerializeField] private string nombreCredits;
    [SerializeField] private string rolCredits;

    #endregion

    #region Private Variables

    #endregion


    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        this.creditsInfoDisplay.text = string.Format("Nombre: {0}\nRol: {1}", this.nombreCredits, this.rolCredits);

        if (hiddenContent)
            hiddenContent.SetActive(true);
    }

}
