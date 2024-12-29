using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public List<GameObject> canvases;
    public int currentActiveCanvas = 0;
    public void SetActiveCanvas(int target) {
        canvases[currentActiveCanvas].SetActive(false);
        canvases[target].SetActive(true);
        currentActiveCanvas = target;
    }
}
