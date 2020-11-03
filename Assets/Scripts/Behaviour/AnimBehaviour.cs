using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimBehaviour : MonoBehaviour
{
    private Animator anims;

    private void Start()
    {
        anims = GetComponent<Animator>();
        anims.SetTrigger("Left");
    }
}
