using UnityEngine;
using System.Collections;

public class FaceUpdate : MonoBehaviour
{
	public AnimationClip[] animations;

	Animator anim;

    Transform player;
    PlayerEmotions playerEmotions;

	public float delayWeight;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerEmotions = player.GetComponent<PlayerEmotions> ();
    }

	void Start ()
	{
		anim = GetComponent<Animator> ();
	}

	void OnGUI ()
	{
		foreach (var animation in animations) {
			if (GUILayout.Button (animation.name)) {
                Debug.Log (animation.name);
                if ("smile1@unitychan" == animation.name)
                    Debug.Log ("Equals");
				anim.CrossFade (animation.name, 0);
			}
		}
	}

	float current = 0;


	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			current = 1;
		} else {
			current = Mathf.Lerp (current, 0, delayWeight);
		}

        anim.SetLayerWeight (1, 1);

        if (playerEmotions.currentSmile > 10) {
            anim.CrossFade ("smile1@unitychan", 0.1f);
        } else if (playerEmotions.currentSmile > 60) {
            anim.CrossFade ("smile2@unitychan", 0.1f);
        } else if (playerEmotions.currentAnger > 10) {
            anim.CrossFade ("angry1@unitychan", 0.1f);
        } else if (playerEmotions.currentSurprise > 5) {
            anim.CrossFade ("sap@unitychan", 0.1f);
        } else if (playerEmotions.currentAnger > 4) {
            anim.CrossFade ("angry1@unitychan", 0.1f);
        } else if (playerEmotions.currentValence > 5) {
            anim.CrossFade ("conf@unitychan", 0.1f);
        }else if (playerEmotions.currentEyeClosure > 20) {
            anim.CrossFade ("eye_close@unitychan", 0.1f);
        }
        else anim.SetLayerWeight (1, current);
	}
}
