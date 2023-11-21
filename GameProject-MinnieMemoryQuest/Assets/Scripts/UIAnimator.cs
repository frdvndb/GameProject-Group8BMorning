using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
     // Start is called before the first frame update
    public void Open()
    {
		gameObject.SetActive(true);
		animator.SetBool("isOpen", true);
    }

	// Update is called once per frame
	public void Close()
    {
		animator.SetBool("isOpen", false);
	}
}
