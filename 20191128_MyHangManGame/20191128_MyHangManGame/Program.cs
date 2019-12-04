using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20191128_MyHangManGame.Entity;

namespace _20191128_MyHangManGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //docFunction();
            docFunctionObject();
            

        }

        static void docFunctionObject()
        {
            GameManager gameManager = new GameManager();
            Player player = new Player();
            Board board = new Board();

            gameManager.SetSecretWord("lapTop");

            while (gameManager.isPlaying)
            {
                board.Clear();
                board.Draw(player.Life());

                //OPTION2
                if (player.IsDead()) {
                    board.BeepStarWars();
                    board.Draw("GAME OVER!!!");
                    break;
                }

                if (gameManager.IsWin())
                {
                    board.BeepMario();
                    board.Draw("YOU WIN!!!");
                    break;
                }

                board.Draw(gameManager.publicWord);
                string letter = player.EnterWord();
                if (gameManager.CheckLetter(letter))
                {
                    gameManager.UpdatePublicWord(letter);
                }
                else
                {
                    player.Damage();
                }
                
                //OPTION1
                //if (player.IsDead()) {
                //    gameManager.isPlaying = false;
                //}
            }

            //OPTION1
            //board.Clear();
            //board.Draw(player.Life());
            //board.Draw("GAME OVER!!!");
            board.Close();
        }

        static void docFunction()
        {
            string secretWord = "zapatos";
            string publicWord = "";
            string tempWord = "";
            string letter = "";
            int hp = 3;

            for (int i = 0; i < secretWord.Length; i++) {
                tempWord += "*";
            }
            publicWord = tempWord;
            Console.WriteLine(publicWord);

            while (hp > 0) {
                Console.WriteLine("HP:" + hp);
                Console.WriteLine("Ingrese una letra:");
                letter = Console.ReadLine();

                Console.Clear();
                // Console.ReadLine(">"+letter);

                tempWord = "";
                //foreach (char c in secretWord)
                //{
                //    if (letter == "" + c)
                //    {
                //        tempWord += c; //tempWord = tempWord + c;
                //    }
                //    else
                //    {
                //        tempWord += "*";
                //    }
                //}

                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (letter == "" + secretWord[i])
                    {
                        tempWord += letter;
                    }
                    else
                    {
                        tempWord += publicWord[i];
                        //if (publicWord[i] != '*') tempWord += publicWord[i];
                        //else tempWord += "*";
                    }
                }
                if (publicWord == tempWord) { hp--; }

                if (secretWord == tempWord)
                {
                    Console.WriteLine(tempWord);
                    Console.WriteLine("YOU WIN!!");
                    break;
                }

                publicWord = tempWord;
                Console.WriteLine(publicWord);
            }
            //if (secretWord != tempWord)
            if (hp <= 0)
            {
                Console.WriteLine("GAME OVER");
            }
            Console.ReadLine();
        }

        static void myFunction()
        {
            //string secretWord = "zapato";
            string secretWord = "";
            string letter = "";
            string player = "";
            int hp = 3;

            Console.WriteLine("Hola, bienvenido a HangMan, cual es tu nombre? ");
            player = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine(string.Format("Bienvenido {0}, empezemos el juego, ingresa una palabra:", player));
            secretWord = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine(string.Format("La cantidad de vida es : {0}", hp));
            Console.WriteLine(string.Format("La palabra elegida es : {0}", secretWord));
            for (int i=0;i< secretWord.Length;i++) Console.Write(" _ ");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Ingrese una letra que corresponde a la palabra");
            letter = Console.ReadLine();

            if (myExisteLetraEnPalabra(secretWord, letter))
            {
                Console.WriteLine(string.Format("La cantidad de vida es : {0}", hp));
                Console.WriteLine(string.Format("La palabra elegida es : {0}", secretWord));
                for (int i = 0; i < secretWord.Length; i++)
                {
                    Console.Write(secretWord[i] == letter[0] ? " " + letter + " " : " _ ");
                }
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Ingrese una letra que corresponde a la palabra");
                letter = Console.ReadLine();
            }
            else {
                hp--;
                myInitGame(hp, secretWord);
                Console.WriteLine("Ingrese una letra que corresponde a la palabra");
                letter = Console.ReadLine();
            }
            /*For...*/

            //Console.WriteLine(">" + letter);

            Console.ReadLine();

        }
         
        static void myInitGame(int hp, string secretWord) {
            Console.WriteLine(string.Format("La cantidad de vida es : {0}", hp));
            Console.WriteLine(string.Format("La palabra elegida es : {0}", secretWord));
            for (int i = 0; i < secretWord.Length; i++) Console.Write(" _ ");
            Console.WriteLine();
            Console.WriteLine();
        }

        static bool myExisteLetraEnPalabra(string palabra, string letra) {
            bool existe = false;
            for (int i = 0; i < palabra.Length; i++) {
                if (palabra[i] == letra[0]) { existe = true; break; }
            }
            return existe;
        }
    }
}
