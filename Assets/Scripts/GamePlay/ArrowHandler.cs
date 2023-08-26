using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArrowPatternGenerator : MonoBehaviour
{
    public float arrowDuration;
    public List<ArrowDirectionSO> ArrowDirectionSo;
    public GameObject Correctİcon;
    public GameObject Falseİcon;
    public GameObject rightArrow;
    public GameObject leftArrow;
    public GameObject upArrow;
    public GameObject downArrow;
    private bool isPlaying;
    private bool allDirectionsMatch;
    private bool isOnNext;
    private int currentSO;
    
    public MainMenuUI _mainMenuUI;
    public InGameUI InGameUI;
    public bool displayingArrows;
    
    private Coroutine _arrowChallengeRoutine;
  

    private void Update()
    {
        if (_mainMenuUI.playClicked)
        {
            StartCoroutine(DisplayArrows());
            _mainMenuUI.playClicked = false;
        }
        

        if (InputManager.instance.InputDirections.Count>=ArrowDirectionSo[currentSO].selectedArrowDirections.Count)
        {
            CheckInputs();
        }

        
    }

    GameObject GetArrowGameObject(Directions direction)
    {
        switch (direction)
        {
            case Directions.RightArrow:
                return rightArrow;
            case Directions.LeftArrow:
                return leftArrow;
            case Directions.UpArrow:
                return upArrow;
            case Directions.DownArrow:
                return downArrow;
            default:
                return null;
        }
    }

    private IEnumerator DisplayArrows()
    {
        for (int i = 0; i < ArrowDirectionSo.Count; i++)
        {
            Correctİcon.SetActive(false);
        
            // Display each arrow direction in the current set
            foreach (var arrowDirection in ArrowDirectionSo[currentSO].selectedArrowDirections)
            {
                displayingArrows = true;
                GameObject arrowToDisplay = GetArrowGameObject(arrowDirection);
                arrowToDisplay.SetActive(true);
                yield return new WaitForSeconds(arrowDuration);
                arrowToDisplay.SetActive(false);
                yield return new WaitForSeconds(arrowDuration);
                displayingArrows = false;
            }

            isPlaying = false;
            yield return new WaitUntil((() => isPlaying));
            yield return new WaitForSeconds(arrowDuration);
        
            if (allDirectionsMatch)
            {
                if (currentSO == ArrowDirectionSo.Count - 1)
                {
                    InGameUI.LevelFinished();
                    break;
                }
                else
                {
                    
                    currentSO++;
                    isOnNext = false;
                    isPlaying = false;
                }
            }
            else
            {
                i--;
                isPlaying = false;
                Falseİcon.SetActive(false);
            }
        }
    }


    

    private void CheckInputs()
    {
        int expectedInputCount = ArrowDirectionSo[currentSO].selectedArrowDirections.Count;
        int currentInputCount = InputManager.instance.InputDirections.Count;

        if (currentInputCount >= expectedInputCount)
        {
             allDirectionsMatch = true;

            for (int i = 0; i < expectedInputCount; i++)
            {
                if (InputManager.instance.InputDirections[i] != ArrowDirectionSo[currentSO].selectedArrowDirections[i])
                {
                    StartCoroutine(DelayedMethodCoroutine2()); // Display Falseİcon
                    InputManager.instance.InputDirections.Clear();
                    allDirectionsMatch = false;
                    isPlaying = true;
                    break;
                }
            }

            if (allDirectionsMatch)
            {
                Correctİcon.SetActive(true);
                StartCoroutine(DelayedMethodCoroutine());
                InputManager.instance.InputDirections.Clear();
                allDirectionsMatch = true;
                isPlaying = true;
                
            }
        }
        
    }

    private IEnumerator DelayedMethodCoroutine()
    {
        yield return new WaitForSeconds(2);
        Correctİcon.SetActive(false);
        
    }

    private IEnumerator DelayedMethodCoroutine2()
    {
        Falseİcon.SetActive(true);
        yield return new WaitForSeconds(2);
        Falseİcon.SetActive(false);

    }
}

