using System;


namespace fixit.TheGame
{
    public class Score
    {
        private String[] scoreNames = new String[4];
        private int[] scorePoints = new int[4];

        private bool asking = false;

        private int actualScore;
        private int MAX_SCORE_AMOUNT = 4;
        private static Score score = new Score();

        private Score()
        {
            readFromFile();
            actualScore = 0;
        }

        public static Score getScore()
        {
            return score;
        }

        public void readFromFile()
        {
            
            for(int i=0;i< scoreNames.Length; i++)
            {

                scoreNames[i] = "Score Name" + i;
                scorePoints[i] = 10 + 10 * i;
            }
            
        }



        public void useFileWriter()
        {

            // TODO: write scores
        }



        public void printScores()
        {

            for (int i = 0; i < scorePoints.Length; i++)
            {
                System.Diagnostics.Debug.WriteLine(scoreNames[i] + ", " + scorePoints[i]);
            }
        }

        //Agrega el score a la lista en la pos correcta
        public void add(int score, String name)
        {
            for (int i = 0; i < MAX_SCORE_AMOUNT; i++)
            {
                if (scorePoints[i] < score)
                {
                    int aux = scorePoints[i];
                    String auxName = scoreNames[i];
                    scorePoints[i] = score;
                    scoreNames[i] = name;
                    score = aux;
                    name = auxName;
                }
            }
        }



        public void saveScore()
        {
            asking = true;
            Game.Instance.OnNeedToSartScorePage?.Invoke(100);
         
        }

        public int getActualScore()
        {
            return actualScore;
        }


        public int getHighScore()
        {
            return scorePoints[0];
        }


        public int getCertainScore(int i)
        {
            return scorePoints[i];
        }


        public String getCertainName(int i)
        {
            return scoreNames[i];
        }


        public bool askName()
        {
            return asking;
        }


        public void fixWindow()
        {
            actualScore += 100;
        }


        public void nextSector()
        {
            actualScore += 500;
        }


        public void loseHP()
        {
            if (actualScore > 800)
                actualScore -= 500;
            else
                actualScore = 0;
        }


        public void reset()
        {
            actualScore = 0;
        }

    }
}
