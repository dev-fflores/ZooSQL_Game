using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Controllers
{
    public class PointBarController : MonoBehaviour
    {
        public GameObject[] pointsBar;
        public int currentPointIndex;
        public float pointScale = 1.4f;
        public float pointScaleDuration = 0.4f;
        [SerializeField] private bool[] questionsAnswered;

        private void Awake()
        {
            // pointsBar = GameObject.FindGameObjectsWithTag("PointAnswer");
            // Array.Reverse(pointsBar);    
        }

        private void Start()
        {
            currentPointIndex = 0;
            questionsAnswered = new bool[10];
            foreach (var pointBar in pointsBar)
            {
                pointBar.transform.DOScale(0, 0);
            }
        }

        public void AddPoint(bool isCorrect)
        {
            if (currentPointIndex > pointsBar.Length - 1)
            {
                return;
            }
            
            Image pointImage = pointsBar[currentPointIndex].GetComponent<Image>();
            pointImage.sprite = isCorrect ? GameManager.Instance.correctAnswerSprite : GameManager.Instance.incorrectAnswerSprite;
            questionsAnswered[currentPointIndex] = isCorrect;
            
            // pointsBar[currentPointIndex].transform.DOScale(1, 0.5f).SetEase(Ease.InBounce);
            pointsBar[currentPointIndex].transform.localScale = Vector3.one;
            pointsBar[currentPointIndex].transform.DOPunchScale(Vector3.one * pointScale, pointScaleDuration, 1, 0);
            currentPointIndex++;
        }

        public void ResetPointsBar()
        {
            DOTween.KillAll();
            currentPointIndex = 0;
            for (var i = 0; i < pointsBar.Length; i++)
            {
                pointsBar[i].transform.localScale = Vector3.zero;
            }

            GameManager.Instance.questionsAnswered = questionsAnswered;
        }
    }
}
