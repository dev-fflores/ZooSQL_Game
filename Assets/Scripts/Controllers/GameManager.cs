using Extras;
using UnityEngine;

namespace Controllers
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("Answer Sprites")]
        [SerializeField] private Sprite _correctAnswerSprite;
        [SerializeField] private Sprite _wrongAnswerSprite;
    }
}
