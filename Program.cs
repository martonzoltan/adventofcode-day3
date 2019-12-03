using System;
using System.Linq;
using System.Numerics;
using System.IO;

namespace day3
{
    class Program
    {
        static int[,] circuitBoard = new int[28000,20000];
        static int initX = 8000;
        static int initY = 8000;
        public static void Main(string[] args)
        {
            Console.WriteLine("Mapping wires and calculaing nearest meeting node..");
            FirstPart();
            //SecondPart();
        }
        private static void FirstPart()
        {
            var input = GetInput();
            var firstWire = input[0];
            var secondWire = input[1];
            MapWire(firstWire,1);
            MapWire(secondWire,2);
            var bestDistance = 32000;
            for(var i = 0; i < 26000 ; i++){
                for(var j = 0; j < 20000; j++){
                    if(circuitBoard[i,j] == 5){
                        if(ManhattanDistance(initX, i, j, initY) < bestDistance){
                            bestDistance = ManhattanDistance(initX, i, j, initY);
                        }
                    }
                }
            }
            Console.WriteLine(bestDistance);
        }

        public static int ManhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        private static void MapWire(string wire, int order){
            var stepsInWire = wire.Split(",");
            var currentXPosition = initX;
            var currentYPosition = initY;
            foreach(var instuction in stepsInWire){
                var direction = instuction.Substring(0, 1);
                var steps = Convert.ToInt32(instuction.Substring(1));
                //Console.WriteLine(currentXPosition + "+" + currentYPosition); 
                switch (direction) { 
                    case "R": 
                        for(var i = currentXPosition+1; i <= currentXPosition+steps; i++){
                            if(circuitBoard[i,currentYPosition] == 0){
                                circuitBoard[i,currentYPosition] = order;
                            }
                            else{
                                if(circuitBoard[i,currentYPosition] != order)
                                {
                                    circuitBoard[i,currentYPosition] = 5;
                                }
                                else{
                                    circuitBoard[i,currentYPosition] = order;
                                }
                                
                            }
                        }
                        currentXPosition = currentXPosition+steps;
                        break; 
            
                    case "L": 
                        for(var i = currentXPosition-1; i >= currentXPosition-steps; i--){
                            if(circuitBoard[i,currentYPosition] == 0){
                                circuitBoard[i,currentYPosition] = order;
                            }
                            else{
                                if(circuitBoard[i,currentYPosition] != order){
                                    circuitBoard[i,currentYPosition] = 5;
                                }
                                else{
                                    circuitBoard[i,currentYPosition] = order;
                                }
                                
                            }
                        }
                        currentXPosition = currentXPosition-steps;
                        break; 
            
                    case "U": 
                        for(var i = currentYPosition+1; i <= currentYPosition+steps; i++){
                            if(circuitBoard[currentXPosition,i] == 0 ){
                                circuitBoard[currentXPosition,i] = order;
                            }
                            else{
                                if(circuitBoard[currentXPosition,i] != order){
                                    circuitBoard[currentXPosition,i] = 5;
                                }
                                else{
                                    circuitBoard[currentXPosition,i] = order;
                                }
                            }
                        }
                        currentYPosition = currentYPosition+steps;
                        break; 
                    
                    case "D":                   
                        for(var i = currentYPosition-1; i >= currentYPosition-steps; i--){
                            if(circuitBoard[currentXPosition,i] == 0){
                                circuitBoard[currentXPosition,i] = order;
                            }
                            else{
                                if(circuitBoard[currentXPosition,i] != order){
                                    circuitBoard[currentXPosition,i] = 5;
                                }
                                else{
                                    circuitBoard[currentXPosition,i] = order;
                                }
                            }
                        }
                        currentYPosition = currentYPosition-steps;
                        break; 

                    default: 
                        Console.WriteLine("Nothing"); 
                        break; 
                } 
            }
            Console.WriteLine(currentXPosition); 
            Console.WriteLine(currentYPosition); 
            
        }

        private static void SecondPart()
        {
            
        }

        private static string[] GetInput(){
            var input = System.IO.File.ReadAllLines(@"input.txt");
            return input;
        }
    }
}
