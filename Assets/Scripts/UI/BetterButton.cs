using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(EventTrigger))]
public class BetterButton : MonoBehaviour
{

    [Header("Target Graphics")]
        public TMP_Text tmp_ButtonLabel;
        public Image buttonSprite;

    [Header("Effects")]
        public bool TextColor = false;
        public bool TextScale = false;
        public bool TextRotation = false;

        public bool ImageColor = false;
        public bool ImageScale = false;
        public bool ImageRotation = false;

    [Header("Control - Color")]
        public Color textStartColor;
        public Color textHighlightColor;
        public Color textPressedColor;

        public Color imageStartColor;
        public Color imageHighlightColor;
        public Color imagePressedColor;

    [Header("Control - Scale")]
        public Vector3 textStartScale;
        public Vector3 texthighlightScale;
        public Vector3 textPressedScale;

        public Vector3 imageStartScale;
        public Vector3 imageHighlighedScale;
        public Vector3 imagePressedScale;

    [Header("Control - Rotation")]
        public Vector3 textStartRotation;
        public Vector3 textHighlightRotation;
        public Vector3 textPressedRotation;

        public Vector3 imageStartRotation;
        public Vector3 imageHighlightRotation;
        public Vector3 imagePressedRotation;


    // Start is called before the first frame update
    void Start() {
        ResetImages();
    }

    public void ResetImages () {
        if (buttonSprite){
            if (ImageColor) {
                buttonSprite.color = imageStartColor;
            }
            if (ImageScale) {
                buttonSprite.transform.localScale = imageStartScale;
            }   
            if (ImageRotation) {
                buttonSprite.transform.localEulerAngles = imageStartRotation;
            }
        }
        if (tmp_ButtonLabel) {
            if (TextColor) {
                tmp_ButtonLabel.color = textStartColor;
            }
            if (TextScale) {
                tmp_ButtonLabel.transform.localScale = textStartScale;
            }   
            if (TextRotation) {
                tmp_ButtonLabel.transform.localEulerAngles = textStartRotation;
            }
        }
    }

    public void HoverEnter () {
        if (buttonSprite){
            if (ImageColor) {
                buttonSprite.color = imageHighlightColor;
            }
            if (ImageScale) {
                buttonSprite.transform.localScale = imageHighlighedScale;
            }   
            if (ImageRotation) {
                buttonSprite.transform.localEulerAngles = imageHighlightRotation;
            }
        }
        if (tmp_ButtonLabel) {
            if (TextColor) {
                tmp_ButtonLabel.color = textHighlightColor;
            }
            if (TextScale) {
                tmp_ButtonLabel.transform.localScale = texthighlightScale;
            }   
            if (TextRotation) {
                tmp_ButtonLabel.transform.localEulerAngles = textHighlightRotation;
            }
        }
    }

    public void PressedButton () {
        if (buttonSprite){
            if (ImageColor) {
                buttonSprite.color = imagePressedColor;
            }
            if (ImageScale) {
                buttonSprite.transform.localScale = imagePressedScale;
            }   
            if (ImageRotation) {
                buttonSprite.transform.localEulerAngles = imagePressedRotation;
            }
        }
        if (tmp_ButtonLabel) {
            if (TextColor) {
                tmp_ButtonLabel.color = textPressedColor;
            }
            if (TextScale) {
                tmp_ButtonLabel.transform.localScale = textPressedScale;
            }   
            if (TextRotation) {
                tmp_ButtonLabel.transform.localEulerAngles = textPressedRotation;
            }
        }
    }
}
