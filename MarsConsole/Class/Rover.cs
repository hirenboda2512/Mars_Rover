using MarsConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsConsole.Class
{
    public class Rover : IRover
    {
        private readonly List<string> direction = new List<string>() { "N", "E", "S", "W", "N" };
        private int xPos { get; set; }
        private int yPos { get; set; }
        private string currentDir { get; set; }

        public string currentPos { get; set; }

        public string movement { get; set; }

        public bool isOutOfGrid { get; set; }
        private int maxX { get; set; }
        private int maxY { get; set; }

        public Rover()
        {

        }

        public Rover(string pos, string movementInput, int maxXValue, int maxYValue)
        {
            var currentPos = pos.Split(' ');
            xPos = Convert.ToInt32(currentPos[0]);
            yPos = Convert.ToInt32(currentPos[1]);
            currentDir = currentPos[2];
            movement = movementInput;
            maxX = maxXValue;
            maxY = maxYValue;
        }

        public void ProcessInPutData(int maxXValue, int maxYValue)
        {
            var currentPosArray = currentPos.Split(' ');
            xPos = Convert.ToInt32(currentPosArray[0]);
            yPos = Convert.ToInt32(currentPosArray[1]);
            currentDir = currentPosArray[2];
            maxX = maxXValue;
            maxY = maxYValue;
        }

        public string Process()
        {
            for (int j = 0; j < movement.Length; j++)
            {
                switch (movement[j])
                {
                    case ('L'):
                        TurnLeft();
                        break;
                    case ('R'):
                        TurnRight();
                        break;
                    case ('M'):
                        Move();
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid value: {0}", movement[j]));
                }
            }
            if (isOutOfGrid)
            {
                return $"Rover move out of site:Rover Final Position -> {xPos} {yPos} {currentDir}";

            }
            else
            {
                return $"Rover Final Position -> {xPos} {yPos} {currentDir}";
            }
        }

        public string Process(string movementData)
        {
            for (int j = 0; j < movementData.Length; j++)
            {
                switch (movementData[j])
                {
                    case ('L'):
                        TurnLeft();
                        break;
                    case ('R'):
                        TurnRight();
                        break;
                    case ('M'):
                        Move();
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid value: {0}", movementData[j]));
                }
            }
            if (isOutOfGrid)
            {
                return $"Rover move out of site:Rover Final Position -> {xPos} {yPos} {currentDir}";

            }
            else
            {
                return $"Rover Final Position -> {xPos} {yPos} {currentDir}";
            }
        }

        private void TurnLeft()
        {
            if (currentDir == "N")
            {
                currentDir = "W";
            }
            else
            {
                for (int j = 0; j < direction.Count; j++)
                {
                    if (direction[j] == currentDir)
                    {
                        currentDir = direction[j - 1];
                        break;
                    }
                }
            }
        }
        private void TurnRight()
        {
            for (int j = 0; j < direction.Count; j++)
            {
                if (direction[j] == currentDir)
                {
                    currentDir = direction[j + 1];
                    break;
                }
            }
        }

        private void Move()
        {
            switch (currentDir)
            {
                case "N":
                    yPos = yPos + 1;
                    break;
                case "E":
                    xPos = xPos + 1;
                    break;
                case "S":
                    yPos = yPos - 1;
                    break;
                case "W":
                    xPos = xPos - 1;
                    break;
                default:

                    break;
            }
            if (xPos < 0 || yPos < 0 || xPos > maxX || yPos > maxY)
                isOutOfGrid = true;
            else
                isOutOfGrid = false;
        }
    }
}
