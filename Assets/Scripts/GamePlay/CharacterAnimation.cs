using UnityEngine;

using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    
    [SerializeField] private Animator anim;
    public bool isAttacking = false;
    private float attackDuration = 2.2f; 
    private float attackTimer = 0.0f;
    private const float animationThreshold = 0.99f;
    public bool onAnimation;
    

    private void Update()
    {
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDuration)
            {
                SetFalse();
                isAttacking = false;
                attackTimer = 0.0f;
               
            }
        }

    }

    private void SetFalse()
    {
        anim.SetBool("isAttacking", false);
    }

    private bool CanPlayNewAnimation()
    {
        return !isAttacking;
    }

    public void OnRight()
    {
        if (CanPlayNewAnimation())
        {
            attackDuration = 2.2f;
            PlayAttackAnimation("Attack");
           
        }
    }

    public void OnLeft()
    {
        if (CanPlayNewAnimation())
        {
            attackDuration = 2.4f;
            PlayAttackAnimation("Hook");
        }
    }
    
    public void OnUp()
    {
        if (CanPlayNewAnimation())
        {
            attackDuration = 2.0f;
            PlayAttackAnimation("elbowUPC");
        }
    }

    public void OnDown()
    {
        if (CanPlayNewAnimation())
        {
            attackDuration = 3f;
            PlayAttackAnimation("Kick2");
        }
    }

    private void PlayAttackAnimation(string animationName)
    {
       
        anim.SetBool("isAttacking", true);
        anim.Play(animationName, 0, 0);
        isAttacking = true;
        attackTimer = 0.0f;
    }
}