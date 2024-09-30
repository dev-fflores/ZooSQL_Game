using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace SpinWheel
{
    public class WheelOfFortune : MonoBehaviour
    {
        
        private SpriteRenderer wheelSpriteRenderer;
        
        [SerializeField] private float[] m_numbersForWheel;
        Sequence sequence;
        
        [SerializeField] private GameObject m_iconPrefab;
        public int numberOfIcons = 10;
        private readonly List<GameObject> icons = new ();
        private float radiusWheel;
        public float rotationSpeed;
        private bool isSpinning = false;
        private bool isOnSegment = false;
        private int currentSegment = 0;
        private bool isFinished = false;

        private void Awake()
        {
            wheelSpriteRenderer = GetComponent<SpriteRenderer>();
            sequence = DOTween.Sequence();
        }

        void Start()
        {
            m_numbersForWheel = new float[] { 89, 97, 104, 111, 117, 123 };
            var random = new Random();
            var randomIndex = random.Next(m_numbersForWheel.Length);
            rotationSpeed = m_numbersForWheel[randomIndex];
            
            InitializeWheel();
            AnimateIconsToEdges();
            
            sequence.Play().onComplete += SpinWheel;
        }

        private void InitializeWheel()
        {
            for (int i = 0; i < numberOfIcons; i++)
            {
                GameObject icon = Instantiate(m_iconPrefab, transform.position, Quaternion.identity, transform);

                // icon.GetComponent<Image>().sprite = GameManager.Instance.m_IsCorrectAnswer[i] ? correctAnswerSprite : incorrectAnswerSprite;
                icon.gameObject.name = "Icon" + (9 - i);
                
                // agregar el gameobject icon como hijo del gameobject que tiene este script
                icon.transform.SetParent(transform);
                icons.Add(icon);
            }
            radiusWheel = GetSpriteRadius(wheelSpriteRenderer);
        }

        void Update()
        {
            if (isSpinning)
            {
                transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
                if (!isOnSegment)
                {
                    currentSegment = SelectSegment();
                    icons[9 - currentSegment].transform.DOPunchScale(Vector3.one * 1.4f, 0.3f, 3, 0f);
                    // Debug.Log(icons[9 - currentSegment].name);
                    // sDebug.Log(selectedSegment);
                    // Debug.Log(currentSegment);
                }

                if (currentSegment != SelectSegment())
                {
                    isOnSegment = false;
                }

            }
            if (rotationSpeed == 0 && !isSpinning && !isFinished)
            {
                HandleWheelResult(currentSegment);
            }
        }
        
        private void AnimateIconsToEdges()
        {
            for (int i = 0; i < icons.Count; i++)
            {
                float angle = i * 360f / numberOfIcons;
                Vector3 endPos = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0f) * radiusWheel; // 0.5f is the radius of the wheel
                // icons[i].transform.DOLocalMove(endPos, 0.15f).SetEase(Ease.OutBack);
                sequence.Append(icons[i].transform.DOLocalMove(endPos, 0.15f).SetEase(Ease.OutBack));
            }
        }
        
        private float GetSpriteRadius(SpriteRenderer pSpriteRenderer)
        {
            // Asumiendo que el sprite es circular, el radio es la mitad del tamaño más grande
            float width = pSpriteRenderer.bounds.size.x;
            float height = pSpriteRenderer.bounds.size.y;
            float radius = Mathf.Max(width, height) / 2f;
            return radius;
        }
        
        public void SpinWheel()
        {
            // AudioController.Instance.PlaySound(backgroundSound, true);
            if (isSpinning)
            {
                // Si la ruleta ya está girando, detén la rotación y selecciona un segmento.
                isSpinning = false;
            }
            else
            {
                // Si la ruleta no está girando, inicia la rotación.
                isSpinning = true;
                StartCoroutine(SlowDownRotation());
            }
        }
        
        IEnumerator SlowDownRotation()
        {
            while (rotationSpeed > 0)
            {
                rotationSpeed -= Time.deltaTime * 10;  // Ajusta este valor para controlar la rapidez con la que se desacelera la ruleta.
                yield return null;
            }
            rotationSpeed = 0;
            isSpinning = false;
            // SelectSegment();
        }

        private int SelectSegment()
        {
            int numberOfSegments = icons.Count;
            float segmentRotation = 360f / numberOfSegments;
            int selectedSegment = Mathf.FloorToInt(transform.eulerAngles.z / segmentRotation);
            // Debug.Log("selectedSegment: " + icons[selectedSegment].name);
            // sDebug.Log(selectedSegment);
            isOnSegment = true; 

            return selectedSegment;
            // HandleWheelResult(selectedSegment);
        }
        
        private void HandleWheelResult(int selectedSegmentIndex)
        {
            // AudioController.Instance.StopSound();
            
            // Si el segmento seleccionado tiene el sprite de respuesta correcta, avanza al siguiente nivel
            // var correctAnswer = GameManager.Instance.m_IsCorrectAnswer[9 - selectedSegmentIndex];
            // if (correctAnswer)
            // {
            //     // GameManager.Instance.currentLevel++;
            //     //
            //     // if (GameManager.Instance.currentLevel >= 6)
            //     // {
            //     //     GameManager.Instance.currentLevel = 5;
            //     //     GameManager.Instance.isGameOver = true;
            //     // }
            //     
            //     // DataManager.Instance.Tema = GameManager.Instance.difficultyLevel[GameManager.Instance.currentLevel].Item1;
            //     // DataManager.Instance.Dificultad = GameManager.Instance.difficultyLevel[GameManager.Instance.currentLevel].Item2;
            //     
            //     // Debug.LogError("Correct answer! Current level: " + GameManager.Instance.currentLevel);
            // }
            // else
            // {
            //     // Si el segmento seleccionado tiene el sprite de respuesta incorrecta, retrocede al nivel anterior
            //     // DataManager.Instance.Tema = GameManager.Instance.difficultyLevel[GameManager.Instance.currentLevel].Item1;
            //     // DataManager.Instance.Dificultad = GameManager.Instance.difficultyLevel[GameManager.Instance.currentLevel].Item2;
            //     
            //     // Debug.LogError("Incorrect answer! Current level: " + GameManager.Instance.currentLevel);
            // }
            sequence.Kill();
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            // resultUI.OpenPanel();
            isFinished = true;
        }

    }
}