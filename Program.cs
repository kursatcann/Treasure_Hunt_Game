
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    class Program
    {
        static void Main(string[] args)
        {

            //This Boolean Created For Breaking Random Piece Process-Clock and Count Variables For Checking Numbers of Reward And Penalties
            //Array Index variable Created For Sequent Piece Settling
            bool bb = true; int count = 0; int my_array_index = 1; int clock = 0; int round_of_game = 0;
            Console.SetCursorPosition(4, 5); Console.WriteLine("+---+");
            Console.SetCursorPosition(4, 6); Console.WriteLine("|C|P|");
            Console.SetCursorPosition(4, 7); Console.WriteLine("+---+");
            //This Array Created For Game Board
            string[,] myboard = new string[12, 12];
            Console.SetCursorPosition(10, 1); Console.Write("  ----------Round {0} --------- ", round_of_game);
            Console.SetCursorPosition(12, 2); Console.Write("  1 2 3 4 5 6 7 8 9 0 1 2 ");
            Console.SetCursorPosition(12, 3); Console.Write("+ - - - - - - - - - - - - +");
            for (int i = 4; i < 16; i++)
            {
                if (i - 2 <= 10)
                {
                    Console.SetCursorPosition(11, i); Console.Write(i - 3);
                }
                else
                {
                    Console.SetCursorPosition(11, i); Console.Write(i - 13);
                }

                Console.SetCursorPosition(12, i); Console.Write("|");

            }
            for (int i = 4; i < 16; i++)
            {
                Console.SetCursorPosition(38, i); Console.Write("|");

            }


            Console.SetCursorPosition(12, 16); Console.Write("+ - - - - - - - - - - - - +");
            //This loop creat for assign values to array array index
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {

                    myboard[i, j] = ".";

                }
                Console.WriteLine();

            }
            //This Random Machine Created For Random Piece Generator
            Random rnd = new Random();
            //This Array Created For Rewards and  Penalties
            string[] rewards = new string[] { ".", "@", "#", ">", "<", "*", "L", "X", "N", "^", "v" };
            //This loop settling Rewards And Penalties
            while (clock < 10)
            {

                while (count < 4)
                {   //Here we Determine Random Positions For Rewards And Penalties
                    int myclockx = 0; int myclocky = 0;
                    //This Positinal Index Are Created For Random x_axis And y_axis 
                    int myx = rnd.Next(0, 12);
                    int myy = rnd.Next(0, 12);
                    //This Positional Index For Settling T 
                    myboard[11, 11] = "T";
                    //This Gate Looks For Is This Area Empty Or Not 
                    if (myboard[myx, myy] == ".")
                    {
                        //Here we look right side of our position
                        for (int c = myx + 1; c < 12; c++)
                        {

                            if (myboard[c, myy] == rewards[my_array_index])

                            {
                                bb = false;
                                break;
                            }
                        }
                        //Here we look upward of our position
                        for (int d = myy + 1; d < 12; d++)
                        {
                            if (myboard[myx, d] == rewards[my_array_index])
                            {

                                bb = false;
                                break;
                            }


                        }
                        //Here we look left side of our position
                        for (int l = myx - 1; l >= 0; l--)
                        {
                            if (myboard[l, myy] == rewards[my_array_index])

                            {

                                bb = false;
                                break;
                            }
                        }
                        //Here we look downward of our position
                        for (int r = myy - 1; r >= 0; r--)
                        {
                            if (myboard[myx, r] == rewards[my_array_index])

                            {
                                bb = false;
                                break;
                            }
                        }


                        //Here we look right side of our position for less than 5 reward or penalties
                        for (int c = myx + 1; c < 12; c++)
                        {

                            if (myboard[c, myy] == ".")

                            {
                                myclockx++;
                            }
                        }
                        //Here we look right side of our position for less than 5 reward or penalties
                        for (int l = myx - 1; l >= 0; l--)
                        {
                            if (myboard[l, myy] == ".")

                            {
                                myclockx++;
                            }

                        }
                        if (myclockx < 8)

                        {
                            bb = false;
                        }
                        //This Gate Created For Checking Row About Including less than 5 reward or penalties
                        if (myx == 11 && myy == 11)
                        {

                            bb = false;

                        }
                        //This gate created for more effective algorithm which dont spend time more if already row includes more than 4 penalties or rewards
                        if (bb == true)
                        { //Here we look up ward of our position for less than 5 reward or penalties
                            for (int d = myy + 1; d < 12; d++)
                            {
                                if (myboard[myx, d] == ".")
                                {

                                    myclocky++;
                                }


                            }
                            //Here we look down ward of our position for less than 5 reward or penalties
                            for (int r = myy - 1; r >= 0; r--)
                            {
                                if (myboard[myx, r] == ".")

                                {
                                    myclocky++;
                                }
                            }
                            //This gate created for checking position includes more than 4 rewards or penalties in row and column
                            if (myclocky < 8)

                            {
                                bb = false;
                            }


                        }
                        //This Gate Created For If All Conditions Okey Set The Reward Or Penalty
                        if (bb == true && count < 4)
                        {
                            myboard[myx, myy] = rewards[my_array_index];
                            count++;
                        }

                    }
                    //Here bool preapring for next loop processing
                    bb = true;
                }
                count = 0;
                clock++; my_array_index++;

            }
            //It Is for Desing Of Game 

            // Here W,e Write The Game Board



            int board_position_y = 4;
            for (int horizontal = 0; horizontal < myboard.GetLength(0); horizontal++)
            {
                Console.SetCursorPosition(14, board_position_y);
                for (int vertical = 0; vertical < myboard.GetLength(1); vertical++)
                {
                    Console.Write(myboard[horizontal, vertical] + " ");
                }
                board_position_y++;
                Console.WriteLine();
            }



            //Gaming Sector





            int index_player_position_x = -1;
            int index_player_position_y = -1;

            int life_of_player = 1;
            bool combo_for_player = false;
            int round_for_player = 0;
            bool gameworks = true;
            int my_area_holder = 0;
            int dice = 0;
            int direction = 0;
            string myname = "";
            int check_infinity_for_player = 0;
            string turn = "Player";
            string direction_sign = "";
            int index_computer_position_x = -1;
            int index_computer_position_y = -1;
            int wait_for_one_round_player = 0;
            int wait_for_one_round_computer = 0;
            int life_of_computer = 1;
            bool combo_for_computer = false;
            int round_for_computer = 0;
            bool end_of_p = false;
            bool end_of_c = false;
            while (gameworks == true)
            {
                if (index_player_position_x == 11 && index_player_position_y == 11)
                {
                    gameworks = false;
                    end_of_c = true;
                    break;


                }
                if (life_of_player <= 0)

                {
                    gameworks = false;
                    end_of_p = true;
                    break;
                }

                if (index_computer_position_x == 11 && index_computer_position_y == 11)
                {
                    gameworks = false;
                    end_of_p = true;
                    break;


                }
                if (life_of_computer <= 0)

                {
                    gameworks = false;
                    end_of_c = true;
                    break;
                }
                Console.SetCursorPosition(45, 15);
                // myname = Console.ReadLine();
                if (wait_for_one_round_player % 2 == 0)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    {
                        if (combo_for_player == false)
                        {

                            direction = rnd.Next(0, 2);
                            dice = rnd.Next(1, 7);
                            if (direction == 1)
                            {
                                direction_sign = ">";
                            }
                            else if (direction == 0)
                            {
                                direction_sign = "V";


                            }

                            Console.SetCursorPosition(45, 5); Console.Write("Turn: {0}", turn);
                            Console.SetCursorPosition(45, 6); Console.Write("Dice: {0}", dice);
                            Console.SetCursorPosition(45, 7); Console.Write("Direction: {0} ", direction_sign);
                            Console.SetCursorPosition(45, 10); Console.Write("Life Of Player: {0}", life_of_player);
                            Console.SetCursorPosition(45, 11); Console.Write("Life Of Computer: {0}", life_of_computer);

                        }


                        if (direction == 1 && index_player_position_x + dice <= 11)
                        {
                            turn = "Player";
                            Console.SetCursorPosition(7, 6); Console.Write("_");
                            //For ImageİF
                            if (index_player_position_y < 0)
                            {
                                index_player_position_y = 0;
                            }

                            if (round_for_player != 0 && index_player_position_x != -1 && index_player_position_y != -1)
                            {
                                if (my_area_holder != 0)
                                {
                                    switch (my_area_holder)
                                    {
                                        case 1:
                                            myboard[index_player_position_y, index_player_position_x] = "#";
                                            break;
                                        case 2:
                                            myboard[index_player_position_y, index_player_position_x] = ">";
                                            break;
                                        case 3:
                                            myboard[index_player_position_y, index_player_position_x] = "<";
                                            break;
                                        case 4:
                                            myboard[index_player_position_y, index_player_position_x] = "*";
                                            break;
                                        case 5:
                                            myboard[index_player_position_y, index_player_position_x] = "L";
                                            break;
                                        case 6:
                                            myboard[index_player_position_y, index_player_position_x] = "X";
                                            break;
                                        case 7:
                                            myboard[index_player_position_y, index_player_position_x] = "N";
                                            break;
                                        case 8:
                                            myboard[index_player_position_y, index_player_position_x] = "^";
                                            break;
                                        case 9:
                                            myboard[index_player_position_y, index_player_position_x] = "v";
                                            break;


                                    }
                                    my_area_holder = 0;
                                }
                                else
                                    myboard[index_player_position_y, index_player_position_x] = ".";

                            }

                            index_player_position_x = dice + index_player_position_x;


                            if (myboard[index_player_position_y, index_player_position_x] != ".")
                            {
                                combo_for_player = true;
                            }
                        }
                        if (direction == 0 && index_player_position_y + dice <= 11)
                        {
                            Console.SetCursorPosition(7, 6); Console.Write("_");
                            //For ImageİF
                            if (index_player_position_x < 0)
                            {
                                index_player_position_x = 0;
                            }

                            if (round_for_player != 0 && index_player_position_x != -1 && index_player_position_y != -1)
                            {
                                if (my_area_holder != 0)
                                {
                                    switch (my_area_holder)
                                    {
                                        case 1:
                                            myboard[index_player_position_y, index_player_position_x] = "#";
                                            break;
                                        case 2:
                                            myboard[index_player_position_y, index_player_position_x] = ">";
                                            break;
                                        case 3:
                                            myboard[index_player_position_y, index_player_position_x] = "<";
                                            break;
                                        case 4:
                                            myboard[index_player_position_y, index_player_position_x] = "*";
                                            break;
                                        case 5:
                                            myboard[index_player_position_y, index_player_position_x] = "L";
                                            break;
                                        case 6:
                                            myboard[index_player_position_y, index_player_position_x] = "X";
                                            break;
                                        case 7:
                                            myboard[index_player_position_y, index_player_position_x] = "N";
                                            break;
                                        case 8:
                                            myboard[index_player_position_y, index_player_position_x] = "^";
                                            break;
                                        case 9:
                                            myboard[index_player_position_y, index_player_position_x] = "v";
                                            break;


                                    }
                                    my_area_holder = 0;
                                }
                                else
                                    myboard[index_player_position_y, index_player_position_x] = ".";
                            }

                            index_player_position_y += dice;
                            if (myboard[index_player_position_y, index_player_position_x] != ".")
                            {
                                combo_for_player = true;
                            }
                        }
                        //JUST WRITING HERE       
                        check_infinity_for_player = 0;
                        while (combo_for_player == true && check_infinity_for_player < 20)
                        {
                            check_infinity_for_player++;
                            if (check_infinity_for_player == 19)
                            {
                                combo_for_player = false;
                                break;
                            }

                            switch (myboard[index_player_position_y, index_player_position_x])
                            {
                                case "#":
                                    //Will Look Again

                                    
                                    wait_for_one_round_player++;
                                    combo_for_player = false;


                                    my_area_holder = 1;




                                    break;
                                case ">":

                                    if (index_player_position_x + 3 <= 11)
                                    {
                                        index_player_position_x += 3;

                                    }
                                    else
                                    {
                                        if (myboard[index_player_position_y, index_player_position_x] != ".")
                                        {
                                            my_area_holder = 2;
                                        }
                                        combo_for_player = false;

                                    }

                                    break;
                                case "<":

                                    if (index_player_position_x - 3 >= 0)
                                    {

                                        index_player_position_x -= 3;

                                    }
                                    else
                                    {
                                        if (myboard[index_player_position_y, index_player_position_x] != ".")
                                        {
                                            my_area_holder = 3;
                                        }
                                        combo_for_player = false;

                                    }
                                    break;
                                case "*":

                                    if (direction == 1 && index_player_position_x + dice <= 11)
                                    {

                                        index_player_position_x += dice;

                                    }
                                    else if (direction == 0 && index_player_position_y + dice <= 11)
                                    {

                                        index_player_position_y += dice;


                                    }
                                    else

                                    {
                                        if (myboard[index_player_position_y, index_player_position_x] != ".")
                                        {
                                            my_area_holder = 4;
                                        }
                                        combo_for_player = false;


                                    }
                                    break;
                                case "L":
                                    life_of_player += 1; combo_for_player = false;
                                    my_area_holder = 5;

                                    break;
                                case "X":

                                    life_of_player -= 1; combo_for_player = false;
                                    my_area_holder = 6;

                                    break;
                                case "N":


                                    bool stop = false;
                                    
                                    combo_for_player = true;
                                    for (int xx = index_player_position_x - 1; xx < index_player_position_x + 2; xx++)
                                    {
                                        while (xx > 11)
                                        {
                                            xx--;
                                        }
                                        while (xx < 0)
                                        {
                                            xx++;
                                        }
                                        for (int yy = index_player_position_y - 1;yy < index_player_position_y + 2; yy++)
                                            {


                                            while (yy > 11)
                                            {
                                                yy--;
                                            }

                                            while (yy < 0)
                                            {
                                                yy++;
                                            }

                                          
                                             if (myboard[xx, yy] == ">" || myboard[xx, yy] == "<" || myboard[xx, yy] == "^" || myboard[xx, yy] == "v" ||
                                                 myboard[xx, yy] == "X" || myboard[xx, yy] == "L" || myboard[xx, yy] == "*" || myboard[xx, yy] == "#")
                                             {

                                                        index_player_position_x = yy;
                                                        index_player_position_y = xx;
                                                        

                                                        stop = true; break;
                                             }



                                        }

        
                                                if (stop == true)
                                                break;


                                    }                                                                                                                    
                                    if (stop == false)
                                    {
                                        for (int f = index_player_position_x - 2; f < index_player_position_x + 4; f++)
                                        {
                                            while (f < 0)
                                            {
                                                f++;
                                            }
                                            while (f > 11)
                                            {
                                                f--;
                                            }

                                            for (int j = index_player_position_y - 2; j < index_player_position_y + 4; j++)
                                            {

                                                while (j < 0)
                                                {
                                                   j++;
                                                }
                                                while (j > 11)
                                                {
                                                    j--;
                                                }



                                                if (myboard[f, j] == ">" || myboard[f, j] == "<" || myboard[f, j] == "^" || myboard[f, j] == "v" ||
                                                 myboard[f, j] == "X" || myboard[f, j] == "L" || myboard[f, j] == "*" || myboard[f, j] == "#" || myboard[f, j] == "@")
                                                {

                                                        index_player_position_x = j;
                                                        index_player_position_y = f;

                                                        stop = true; break;
                                                    }

                                                    if (stop == true)
                                                    break;

                                                }


                                            }

                                           
                                        }
                                

                                    if (myboard[index_player_position_y, index_player_position_x] != ".")
                                    {
                                        my_area_holder = 7;
                                    }
                                    break;

                                case "^":

                                    if (index_player_position_y - 3 >= 0)
                                    {


                                        index_player_position_y -= 3;

                                    }
                                    else
                                    {
                                        if (myboard[index_player_position_y, index_player_position_x] != ".")
                                        {
                                            my_area_holder = 8;
                                        }
                                        combo_for_player = false;

                                    }
                                    break;
                                case "v":

                                    if (index_player_position_y + 3 <= 11)
                                    {

                                        index_player_position_y += 3;


                                    }
                                    else
                                    {
                                        if (myboard[index_player_position_y, index_player_position_x] != ".")
                                        {
                                            my_area_holder = 9;
                                        }
                                        combo_for_player = false;

                                    }
                                    break;
                                case "C":

                                    myboard[index_player_position_y, index_player_position_x] = "C";
                                    index_player_position_x = -1;
                                    index_player_position_y = -1;
                                    Console.SetCursorPosition(7, 6); Console.Write("P");
                                    combo_for_player = false;
                                    break;

                                case "@":


                                    index_player_position_x = -1;
                                    index_player_position_y = -1;
                                    Console.SetCursorPosition(7, 6); Console.Write("P");
                                    combo_for_player = false;
                                    break;








                            }
                            if (index_player_position_x != -1 && index_player_position_y != -1)
                            {
                                if (myboard[index_player_position_y, index_player_position_x] == "." || myboard[index_player_position_y, index_player_position_x] == "T")
                                {
                                    combo_for_player = false;
                                }

                            }

                        }


                        if (index_player_position_x != -1 && index_player_position_y != -1)
                        {
                            myboard[index_player_position_y, index_player_position_x] = "P";
                        }

                        board_position_y = 4;
                        for (int horizontal = 0; horizontal < myboard.GetLength(0); horizontal++)
                        {

                            Console.SetCursorPosition(14, board_position_y);
                            for (int vertical = 0; vertical < myboard.GetLength(1); vertical++)
                            {

                                Console.Write(myboard[horizontal, vertical] + " ");

                            }
                            board_position_y++;
                            Console.WriteLine();
                        }


                        round_for_player++;
                        turn = "Computer";
                    }
                }
                else if (wait_for_one_round_player % 2 != 0)
                {
                    wait_for_one_round_player++; round_for_player++; turn = "Computer";
                }

                if (wait_for_one_round_computer % 2 == 0)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    {
                        if (combo_for_computer == false)
                        {


                            direction = rnd.Next(0, 2);
                            dice = rnd.Next(1, 7);
                            if (direction == 1)
                            {
                                direction_sign = ">";
                            }
                            else if (direction == 0)
                            {
                                direction_sign = "V";


                            }

                            Console.SetCursorPosition(45, 5); Console.Write("Turn: {0}", turn);
                            Console.SetCursorPosition(45, 6); Console.Write("Dice: {0}", dice);
                            Console.SetCursorPosition(45, 7); Console.Write("Direction: {0} ", direction_sign);
                            Console.SetCursorPosition(45, 10); Console.Write("Life Of Player: {0}", life_of_player);
                            Console.SetCursorPosition(45, 11); Console.Write("Life Of Computer: {0}", life_of_computer);

                        }



                        if (direction == 1 && index_computer_position_x + dice <= 11)
                        {

                            Console.SetCursorPosition(5, 6); Console.Write("_");
                            //For ImageİF
                            if (index_computer_position_y < 0)
                            {
                                index_computer_position_y = 0;
                            }

                            if (round_for_computer != 0 && index_computer_position_x != -1 && index_computer_position_y != -1)
                            {
                                if (my_area_holder != 0)
                                {
                                    switch (my_area_holder)
                                    {
                                        case 1:
                                            myboard[index_computer_position_y, index_computer_position_x] = "#";
                                            break;
                                        case 2:
                                            myboard[index_computer_position_y, index_computer_position_x] = ">";
                                            break;
                                        case 3:
                                            myboard[index_computer_position_y, index_computer_position_x] = "<";
                                            break;
                                        case 4:
                                            myboard[index_computer_position_y, index_computer_position_x] = "*";
                                            break;
                                        case 5:
                                            myboard[index_computer_position_y, index_computer_position_x] = "L";
                                            break;
                                        case 6:
                                            myboard[index_computer_position_y, index_computer_position_x] = "X";
                                            break;
                                        case 7:
                                            myboard[index_computer_position_y, index_computer_position_x] = "N";
                                            break;
                                        case 8:
                                            myboard[index_computer_position_y, index_computer_position_x] = "^";
                                            break;
                                        case 9:
                                            myboard[index_computer_position_y, index_computer_position_x] = "v";
                                            break;


                                    }
                                    my_area_holder = 0;
                                }
                                else
                                    myboard[index_computer_position_y, index_computer_position_x] = ".";

                            }

                            index_computer_position_x = dice + index_computer_position_x;


                            if (myboard[index_computer_position_y, index_computer_position_x] != ".")
                            {
                                combo_for_computer = true;
                            }
                        }
                        if (direction == 0 && index_computer_position_y + dice <= 11)
                        {
                            Console.SetCursorPosition(5, 6); Console.Write("_");
                            //For ImageİF
                            if (index_computer_position_x < 0)
                            {
                                index_computer_position_x = 0;
                            }

                            if (round_for_computer != 0 && index_computer_position_x != -1 && index_computer_position_y != -1)
                            {
                                if (my_area_holder != 0)
                                {
                                    switch (my_area_holder)
                                    {
                                        case 1:
                                            myboard[index_computer_position_y, index_computer_position_x] = "#";
                                            break;
                                        case 2:
                                            myboard[index_computer_position_y, index_computer_position_x] = ">";
                                            break;
                                        case 3:
                                            myboard[index_computer_position_y, index_computer_position_x] = "<";
                                            break;
                                        case 4:
                                            myboard[index_computer_position_y, index_computer_position_x] = "*";
                                            break;
                                        case 5:
                                            myboard[index_computer_position_y, index_computer_position_x] = "L";
                                            break;
                                        case 6:
                                            myboard[index_computer_position_y, index_computer_position_x] = "X";
                                            break;
                                        case 7:
                                            myboard[index_computer_position_y, index_computer_position_x] = "N";
                                            break;
                                        case 8:
                                            myboard[index_computer_position_y, index_computer_position_x] = "^";
                                            break;
                                        case 9:
                                            myboard[index_computer_position_y, index_computer_position_x] = "v";
                                            break;


                                    }
                                    my_area_holder = 0;
                                }
                                else
                                    myboard[index_computer_position_y, index_computer_position_x] = ".";
                            }

                            index_computer_position_y += dice;
                            if (myboard[index_computer_position_y, index_computer_position_x] != ".")
                            {
                                combo_for_computer = true;
                            }
                        }
                        //JUST WRITING HERE       
                        int check_infinity_for_computer = 0;
                        while (combo_for_computer == true && check_infinity_for_computer < 20)
                        {
                            check_infinity_for_computer++;
                            if (check_infinity_for_computer == 19)
                            {
                                combo_for_computer = false;
                                break;
                            }

                            switch (myboard[index_computer_position_y, index_computer_position_x])
                            {
                                case "#":
                                    
                                    wait_for_one_round_computer++;
                                    combo_for_computer = false;


                                    my_area_holder = 1;




                                    break;
                                case ">":

                                    if (index_computer_position_x + 3 <= 11)
                                    {
                                        index_computer_position_x += 3;

                                    }
                                    else
                                    {
                                        if (myboard[index_computer_position_y, index_computer_position_x] != ".")
                                        {
                                            my_area_holder = 2;
                                        }
                                        combo_for_computer = false;

                                    }

                                    break;
                                case "<":

                                    if (index_computer_position_x - 3 >= 0)
                                    {

                                        index_computer_position_x -= 3;

                                    }
                                    else
                                    {
                                        if (myboard[index_computer_position_y, index_computer_position_x] != ".")
                                        {
                                            my_area_holder = 3;
                                        }
                                        combo_for_computer = false;

                                    }
                                    break;
                                case "*":

                                    if (direction == 1 && index_computer_position_x + dice <= 11)
                                    {

                                        index_computer_position_x += dice;

                                    }
                                    else if (direction == 0 && index_computer_position_y + dice <= 11)
                                    {

                                        index_computer_position_y += dice;


                                    }
                                    else

                                    {
                                        if (myboard[index_computer_position_y, index_computer_position_x] != ".")
                                        {
                                            my_area_holder = 4;
                                        }
                                        combo_for_computer = false;


                                    }
                                    break;
                                case "L":
                                    life_of_computer += 1; combo_for_computer = false;
                                    my_area_holder = 5;

                                    break;
                                case "X":

                                    life_of_computer -= 1; combo_for_computer = false;
                                    my_area_holder = 6;

                                    break;
                                case "N":
                                    bool stop = false;
                                    
                                    combo_for_computer = true;
                                    for (int xx = index_computer_position_x - 1; xx < index_computer_position_x + 2; xx++)
                                    {
                                        while (xx > 11)
                                        {
                                            xx--;
                                        }
                                        while (xx < 0)
                                        {
                                            xx++;
                                        }
                                        for (int yy = index_computer_position_y - 1;yy < index_computer_position_y + 2; yy++)
                                        {
                                            while (yy > 11)
                                             {
                                                yy--;
                                             }

                                            while(yy < 0)
                                            {
                                                yy++;
                                            }
                                            
                                          
                                            if (myboard[xx, yy] == ">" || myboard[xx, yy] == "<" || myboard[xx, yy] == "^" || myboard[xx, yy] == "v" ||
                                               myboard[xx, yy] == "X" || myboard[xx, yy] == "L" || myboard[xx, yy] == "*" || myboard[xx, yy] == "#" || myboard[xx, yy] == "@")
                                             {

                                                        index_computer_position_x = yy;
                                                        index_computer_position_y = xx;
                                                Console.SetCursorPosition(45,15); Console.WriteLine(index_computer_position_x);
                                                Console.SetCursorPosition(45, 16); Console.WriteLine(index_computer_position_y);

                                                        stop = true; break;
                                             }



                                        }



                                            if (stop == true)
                                                break;


                                    }                                  

                                    if (stop == false)
                                    {
                                        for (int f = index_computer_position_x - 2; f < index_computer_position_x + 4; f++)
                                        {
                                            while (f > 11)
                                            {
                                                f--;
                                            }
                                            while (f < 0)
                                            {
                                                f++;
                                            }
                                            for (int j = index_computer_position_y - 2; j < index_computer_position_y + 4; j++)
                                            {


                                                while (j < 0)
                                                {
                                                    j++;
                                                }
                                               while(j>11)
                                                {

                                                    j--;
                                                }

                                              if (myboard[f, j] == ">" || myboard[f, j] == "<" || myboard[f, j] == "^" || myboard[f, j] == "v" ||
                                               myboard[f, j] == "X" || myboard[f, j] == "L" || myboard[f, j] == "*" || myboard[f, j] == "#" || myboard[f, j] == "@")
                                                { 
                                                    index_computer_position_x = j;
                                                    index_computer_position_y = f;

                                                        stop = true; break;
                                                }
                                            }
                                                if (stop == true)
                                                break;

                                            }

                                           
                                        }
                                    
                                    

                                    if (myboard[index_computer_position_y, index_computer_position_x] != ".")
                                    {
                                        my_area_holder = 7;
                                    }

                                    break;

                                case "^":

                                    if (index_computer_position_y - 3 >= 0)
                                    {


                                        index_computer_position_y -= 3;

                                    }
                                    else
                                    {
                                        if (myboard[index_computer_position_y, index_computer_position_x] != ".")
                                        {
                                            my_area_holder = 8;
                                        }
                                        combo_for_computer = false;

                                    }
                                    break;
                                case "v":

                                    if (index_computer_position_y + 3 <= 11)
                                    {

                                        index_computer_position_y += 3;


                                    }
                                    else
                                    {
                                        if (myboard[index_computer_position_y, index_computer_position_x] != ".")
                                        {
                                            my_area_holder = 9;
                                        }
                                        combo_for_computer = false;

                                    }
                                    break;
                                case "P":

                                    myboard[index_computer_position_y, index_computer_position_x] = "P";
                                    index_computer_position_x = -1;
                                    index_computer_position_y = -1;
                                    Console.SetCursorPosition(5, 6); Console.Write("C");
                                    combo_for_computer = false;
                                    break;

                                case "@":


                                    index_computer_position_x = -1;
                                    index_computer_position_y = -1;
                                    Console.SetCursorPosition(5, 6); Console.Write("C");
                                    combo_for_computer = false;
                                    break;








                            }
                            if (index_computer_position_x != -1 && index_computer_position_y != -1)
                            {
                                if (myboard[index_computer_position_y, index_computer_position_x] == "." || myboard[index_computer_position_y, index_computer_position_x] == "T")
                                {
                                    combo_for_computer = false;
                                }

                            }

                        }


                        if (index_computer_position_x != -1 && index_computer_position_y != -1)
                        {
                            myboard[index_computer_position_y, index_computer_position_x] = "C";
                        }

                        board_position_y = 4;
                        for (int horizontal = 0; horizontal < myboard.GetLength(0); horizontal++)
                        {

                            Console.SetCursorPosition(14, board_position_y);
                            for (int vertical = 0; vertical < myboard.GetLength(1); vertical++)
                            {

                                Console.Write(myboard[horizontal, vertical] + " ");

                            }
                            board_position_y++;
                            Console.WriteLine();
                        }


                        round_for_computer++; turn = "  Player";

                    }

                }
                else if (wait_for_one_round_computer % 2 != 0)
                {
                    round_for_computer++;
                    wait_for_one_round_computer++; turn = "Player";
                }

                round_of_game++; Console.SetCursorPosition(10, 1); Console.Write("  ----------Round {0} --------- ", round_of_game);
                Console.SetCursorPosition(45, 15); Console.Write(" ");


            }
            if (end_of_p == true)
            {
                Console.SetCursorPosition(45, 5); Console.Write("Turn: {0}", turn);
                Console.SetCursorPosition(45, 6); Console.Write("Dice: {0}", dice);
                Console.SetCursorPosition(45, 7); Console.Write("Direction: {0} ", direction_sign);
                Console.SetCursorPosition(45, 10); Console.Write("Life Of Player: {0}", life_of_player);
                Console.SetCursorPosition(45, 11); Console.Write("Life Of Computer: {0}", life_of_computer);
                Console.SetCursorPosition(45, 12); Console.WriteLine("ComputerWins");
            }
            else
            {
                Console.SetCursorPosition(45, 5); Console.Write("Turn: {0}", turn);
                Console.SetCursorPosition(45, 6); Console.Write("Dice: {0}", dice);
                Console.SetCursorPosition(45, 7); Console.Write("Direction: {0} ", direction_sign);
                Console.SetCursorPosition(45, 10); Console.Write("Life Of Player: {0}", life_of_player);
                Console.SetCursorPosition(45, 11); Console.Write("Life Of Computer: {0}", life_of_computer);
                Console.SetCursorPosition(45, 12); Console.WriteLine("Player Wins");
            }
            Console.ReadLine();


        }
    }
}
