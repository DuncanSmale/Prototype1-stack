using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Control Variables")]
        public GameObject LeftMotionSprite;
        public GameObject RightMotionSprite;
        public Vector3[] Positions;

        [SerializeField] private int PositionIndex;
        public float delay;
    

    // Update is called once per frame
    void Update()
    {
        if (PositionIndex < Positions.Length && PositionIndex >= 0) 
            transform.position = Positions[PositionIndex];


        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            BackToMainMenu();
        }

    }

    public void MoveRight () {
        PositionIndex ++;
        if (PositionIndex >= Positions.Length) {
            PositionIndex = 0;
        }
        StartCoroutine(DeactivateSprite(RightMotionSprite));

    }

    public void MoveLeft () {
        PositionIndex --;
        if (PositionIndex < 0) {
            PositionIndex = Positions.Length - 1;
        }
        StartCoroutine(DeactivateSprite(LeftMotionSprite));
    }

    private IEnumerator DeactivateSprite (GameObject that) {
        that.SetActive(true);
        yield return new WaitForSecondsRealtime (delay);
        that.SetActive(false);
    }

    public void BackToMainMenu () {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
