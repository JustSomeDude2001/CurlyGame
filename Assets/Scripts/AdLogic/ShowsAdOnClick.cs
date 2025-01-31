using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class ShowsAdOnClick : MonoBehaviour
{
    public void ShowAd() {
        Debug.Log("Trying to show ad");
        YG2.PauseGame(true);
        YG2.InterstitialAdvShow();
        YG2.PauseGame(false);
    }
}
