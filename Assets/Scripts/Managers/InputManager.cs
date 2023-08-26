using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public ArrowPatternGenerator ArrowPatternGenerator;
    public bool isHit;
    private int[] swipeDirections; 
    private Vector2 StartPosition;
    private double CirleDeltaX;
    private double CirleDeltaY;
    
    public CharacterAnimation CharacterAnimation;
    public List<Directions> InputDirections;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
   

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            StartPosition = Input.mousePosition;
            CirleDeltaX = 0;
            CirleDeltaY = 0;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 delta = StartPosition - (Vector2)Input.mousePosition;
            double result = delta.sqrMagnitude;

            if (result > 0.4 && CirleDeltaX == 0)
            {
                CirleDeltaX = delta.x;
                CirleDeltaY = delta.y;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mouseUpPosition = Input.mousePosition;
            Vector2 swipeDistance = StartPosition - mouseUpPosition;

            double result = swipeDistance.sqrMagnitude;

            if (result > 0.4)
            {
                GetSwipeDirection();
            }
        }
    }

    public void GetSwipeDirection()
    {
        isHit = true;
        if (Math.Abs(CirleDeltaX) > Math.Abs(CirleDeltaY) && !ArrowPatternGenerator.displayingArrows)
        {
            if (CirleDeltaX > 0)
            {
                InputDirections.Add(Directions.LeftArrow);
            }
            else
            {
                InputDirections.Add(Directions.RightArrow);
            }
        }
        else
        {
            if (CirleDeltaY > 0 && !ArrowPatternGenerator.displayingArrows)
            {
                InputDirections.Add(Directions.DownArrow);
            }
            else if (!ArrowPatternGenerator.displayingArrows)
            {
                InputDirections.Add(Directions.UpArrow);
            }
            
        }

        isHit = false;
    }

}

public enum Directions
{
    RightArrow,
    LeftArrow,
    UpArrow,
    DownArrow,
}