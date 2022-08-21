using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMove : MonoBehaviour
{

    private bool isDown = false;
    public Animator animator;
    private AudioSource audioSource;

    private void Update()
    {
        Debug.Log(isDown);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    //����) �ι�° �ε����� �� �ٽ� �ö󰬴� ������.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //if �ȴ��� ������ BtnDown
            //if ���� ������ BtnUp
            if (!isDown)
            {
                animator.SetTrigger("Down");
                isDown = true;
                //audioSource.Play();
                Debug.Log("Down");
            }

            else
            {
                animator.SetTrigger("Up");
                //audioSource.Play();
                isDown = false;

                Debug.Log("Up");
            }
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //isDown = !isDown;
            Debug.Log("Exit");
        }

    }

}
