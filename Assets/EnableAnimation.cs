using UnityEngine;

public class EnableAnimation : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        
        animator.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        animator.enabled = true;
    }
}
