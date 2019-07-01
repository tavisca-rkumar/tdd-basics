using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] rollScore = new int[21];
        private int[] frameScore = new int[10];
        private int currentRoll = 0;

        public void Roll(int pins)
        {
            rollScore[currentRoll] = pins;
            currentRoll++;
        }

        public int GetScore()
        {
            var totalScore = 0;
            CalculateFrameScore(0);
            for (var index = 0; index < 10; index++)
            {
                totalScore += frameScore[index];
            }
            return totalScore;
        }

        public void CalculateFrameScore(int rollScoreIndex)
        {
            for (var index = 0; index < 10; index++)
            {
                if (IsStrike(rollScoreIndex))
                {
                    frameScore[index] = 10 + rollScore[rollScoreIndex + 1] + rollScore[rollScoreIndex + 2];
                    rollScoreIndex += 1;
                }
                else if (IsSpare(rollScoreIndex))
                {
                    frameScore[index] = 10 + rollScore[rollScoreIndex + 2];
                    rollScoreIndex += 2;
                }
                else
                {
                    frameScore[index] = rollScore[rollScoreIndex] + rollScore[rollScoreIndex + 1];
                    rollScoreIndex += 2;
                }
            }
        }

        public bool IsSpare(int index)
        {
            if (rollScore[index] + rollScore[index + 1] == 10)
                return true;
            else
                return false;
        }

        public bool IsStrike(int index)
        {

            if (rollScore[index] == 10)
                return true;
            else
                return false;
        }

    }
}
