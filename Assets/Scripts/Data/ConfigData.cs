using UnityEngine;

namespace Data
{
    [System.Serializable]
    public enum GameType
    {
        None,
        CardsGame,
        QuizGame
    }
    [System.Serializable]
    public enum QuestionDifficulty
    {
        None,
        Easy,
        Medium,
        Hard
    }
    
    [System.Serializable]
    public enum QuestionTopic
    {
        None,
        PlSql,
        Algebra
    }

    [System.Serializable]
    public enum QuestionType
    {
        
        //PlSQL
        TiposDatosDeclaraciones, OperacionManipulacionDatos, ControlFlujoBucles,ManejoExcepciones,FuncionesOperadores,TiposDatosColecciones,EstructuraManejoDatos,FuncionesProcedimientos,

        //Algebra
        Seleccion, Proyeccion,SeleccionCondicion,ProyeccionCondicion,Union,Diferencia,Interseccion, JoinNatural,UnionCodicion,JoinNaturalCondicion,AgregacionAgrupamiento,AgregacionCondicion,Agregacion
    }
    
    [System.Serializable]
    public class ConfigData 
    {
        public int currentLevel;
        public string currentGameType;
        public string currentTopic;
        public int currentDifficulty;
        public bool isMusicOn;
        public bool isSoundOn;
    }
}