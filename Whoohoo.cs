using System;
using System.Drawing;
using System.Windows.Forms;

namespace WhoohoGame
{
    /*  
          Project- Whoohoo (Dice Game)
          Purpose of the code: Whoohoo game (A player can play alone, two players can play with each other, A player can play with program) 
          this is dice game like real game but this is computerized. */
    public partial class Whoohoo : Form
    {

        //declaration of variables
        Image[] diceImage;
        int[] dice;
        Random r;
        int Roundnumber = 1;
        int count = 0;
        int RoundScore1;
        int RoundScore2;
        int cRoundNumber;
        int Score;
        int FinalScore = 0;
        int BonusScore;
        Boolean checkChange = false;
        int RoundNop1 = 0;
        int RoundNop2 = 0;
        int RoundNumberp1;
        int RoundNumberp2;
        int FinalScorep1 = 0;
        int FinalScorep2 = 0;
        int win1;
        int win2;
        int dice1;
        int dice2;
        int dice3;
        public Whoohoo()
        {
            InitializeComponent();
        }
        private void RollDice()
        {


            // Reference P1: Externally Dice Images 
            // Purpose: Dice Images to show the dices in the game 
            // Date: 19 October
            // Source: Online Website from google 
            //  https://www.flaticon.com/free-icon/die-face_165?term=dice&page=1&position=14 
            // Assistance: from online website, this help to get pictures of dice to use in the game Whoohoo.

            cRoundNumber = 0;
            diceImage = new Image[7];
            diceImage[0] = Properties.Resources._0_blank;     // location of image
            diceImage[1] = Properties.Resources._1_One;         // dice images that I took from online website 
            diceImage[2] = Properties.Resources._2_two;
            diceImage[3] = Properties.Resources._3_three;
            diceImage[4] = Properties.Resources._4_Four;
            diceImage[5] = Properties.Resources._5_Five;
            diceImage[6] = Properties.Resources._6_six;
            Random r = new Random();
            int dicevalue = r.Next(1, 6);

            dice = new int[3] { 0, 0, 0 }; // dice Array 

            for (int n = 1; n <= 10; n++)  //using for loop // 10 times dice rolled the show up with last vale // Animation
            {
                for (int i = 0; i < 3; i++)  // increament of loop // condition is till 1 
                {
                    if (chbxhold_1.Checked == true && chbxhold_2.Checked == true && chbxhold_3.Checked == true)   // if 3 chechboxes are checked together
                    {
                        string message = "You can not roll out";
                        string title = "Close Window";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, title, buttons);
                        if (result == DialogResult.Yes)
                        {
                            this.Close();
                        }


                    }
                    else
                    {
                        dice[i] = r.Next(1, 7);   
                        if (chbxhold_1.Checked == true)   // hold 1st dice
                        {
                            chbxfor3_Dice.Checked = false;
                            if (i == 0)
                            {
                                dice[0] = dice1;
                            }
                        }
                        if (chbxhold_2.Checked == true) // holds 2nd dice
                        {
                            chbxfor3_Dice.Checked = false;
                            if (i == 1)
                            {
                                dice[1] = dice2;
                            }
                        }
                        if (chbxhold_3.Checked == true)   // holds 3rd dice
                        {
                            chbxfor3_Dice.Checked = false;
                            if (i == 2)
                            {
                                dice[2] = dice3;
                            }
                        }
                       

                        if (chbxfor3_Dice.Checked == true)
                        {
                            picbxDice_1.Image = diceImage[dice[0]];       // Using pictureBox to show Image of Dice
                            picbxDice_2.Image = diceImage[dice[1]];      // Image will be showing up depends on the value of number of dice 
                            picbxDice_3.Image = diceImage[dice[2]];

                        }
                        if (chbxhold_1.Checked == false)
                        {
                            picbxDice_1.Image = diceImage[dice[0]];
                            dice1 = dice[0];
                            lblDiceRolledSc.Text = "" + dice1 + " | " + dice2 + " | " + dice3 + "";

                        }
                        if (chbxhold_2.Checked == false)
                        {
                            picbxDice_2.Image = diceImage[dice[1]];
                            dice2 = dice[1];
                            lblDiceRolledSc.Text = "" + dice1 + " | " + dice2 + " | " + dice3 + "";
                        }
                        if (chbxhold_3.Checked == false)
                        {
                            picbxDice_3.Image = diceImage[dice[2]];
                            dice3 = dice[2];
                            lblDiceRolledSc.Text = "" + dice1 + " | " + dice2 + " | " + dice3 + "";
                        }
                    }


                    System.Threading.Thread.Sleep(50);      // slower the dice rolled 
                    Application.DoEvents();


                    if (chbxhold_1.Checked == true || chbxhold_2.Checked == true || chbxhold_3.Checked == true)
                    {
                        chbxfor3_Dice.Checked = false;
                    }

                }
                if (rbtnSinglePlayer.Checked)
                {
                    lblDiceRolledSc.Text = "" + dice1 + " | " + dice2 + " | " + dice3 + "";   // display the dice numbers
                }

                if (rbtnDoublePlayer.Checked)
                {
                    if (rbtnPlayer1.Checked)
                    {

                        lblDiceRolledp2.Text = "" + dice1 + " | " + dice2 + " | " + dice3 + "";

                    }
                    else
                    {
                        lblDiceRolledp1.Text = "" + dice1 + " | " + dice2 + " | " + dice3 + "";

                    }
                }

                if (rbtnComputer.Checked)
                {
                    if (rbtnPlayerVsp.Checked)
                    { lblDiceRolledp1.Text = "" + dice1 + " | " + dice2 + " | " + dice3 + ""; }
                    else { lblDiceRolledp2.Text = "" + dice1 + " | " + dice2 + " | " + dice3 + ""; }
                }


            }

            if (rbtnDoublePlayer.Checked)  // for 2 players 
            {

                {
                    if (count == 3 && rbtnPlayer2.Checked)
                    {
                        foreach (int dvalue1 in dice)

                        {
                            if (dvalue1 == RoundNop2)
                            {
                                RoundNumberp1 += 1;    // round number will be increased by 1
                                RoundScore1 = RoundNop2 * RoundNumberp1;   // the roundscore for 2 players

                            }
                            lblRoundScorep1.Text = RoundScore1.ToString();
                        }
                    }

                    else
                    {
                        RoundScore1 = 0;
                        lblRoundScorep1.Text = RoundScore1.ToString();
                    }
                    FinalScorep1 = FinalScorep1 + RoundScore1;  // game score for 2 players 
                    lblGamescp1.Text = FinalScorep1.ToString();
                }


                if (count == 3 && rbtnPlayer1.Checked)
                {
                    foreach (int dvalue2 in dice)

                    {
                        if (dvalue2 == RoundNop1)                  // if any dice value is a 1 then it would be calculated through number_of_1s !
                        {
                            RoundNumberp2 += 1;
                            RoundScore2 = RoundNop1 * RoundNumberp2;
                            lblRoundScorep2.Text = RoundScore2.ToString();


                        }

                    }
                }
                else
                {
                    RoundScore2 = 0;
                    lblRoundScorep2.Text = RoundScore2.ToString();
                }
                FinalScorep2 = FinalScorep2 + RoundScore2;
                lblGamescp2.Text = FinalScorep2.ToString();


            }

            if (rbtnComputer.Checked) // for program vs player
            {
                if (count == 3 && rbtnPlayerVsp.Checked)    // when rolls 3 round score will be calculated
                {
                    foreach (int dvalue in dice)
                    {
                        if (dvalue == RoundNop1) // if round number and dice number matches
                        {
                            RoundNumberp1 += 1;  // roundscore will be increased by 1 
                            RoundScore1 = RoundNop1 * RoundNumberp1;

                        }
                        lblRoundScorep1.Text = RoundScore1.ToString();

                    }

                }
                else
                {
                    RoundScore1 = 0;
                    lblRoundScorep1.Text = RoundScore1.ToString();
                }
                FinalScorep1 = FinalScorep1 + RoundScore1;
                lblGamescp1.Text = FinalScorep1.ToString();

                if (count == 3 && rbtnProgram.Checked)  // for program 
                {
                    foreach (int dvalue in dice)
                    {
                        if (dvalue == RoundNop2)
                        {
                            RoundNumberp2 += 1;
                            RoundScore2 = RoundNop2 * RoundNumberp2;

                        }
                        lblRoundScorep2.Text = RoundScore2.ToString();

                    }

                }
                else
                {
                    RoundScore2 = 0;
                    lblRoundScorep2.Text = RoundScore2.ToString();
                }
                FinalScorep2 = FinalScorep2 + RoundScore2;
                lblGamescp2.Text = FinalScorep2.ToString();
            }


            if (rbtnSinglePlayer.Checked)
            {
                foreach (int dvalue in dice)   // using for loop to  recognice all values in the dice 
                {
                    //int x = 0;
                    if ((dvalue == dice1 && dvalue == dice1 + 1 && dvalue == dice1 + 2) || (dvalue == dice1 && dvalue == dice1 - 1 && dvalue == dice1 - 2)) // for sequence bonus score
                    {
                        BonusScore = 10;
                        lblComment1.Text = "Player gets a sequence bonus!";
                        lblBonusScore.Text = BonusScore.ToString();
                    }

                }
                if (count == 3 || chbxFinishRound.Checked)
                {
                    foreach (int dvalue in dice)   // using for loop to  recognice all values in the dice 
                    {
                        if (dvalue == Roundnumber)
                        {
                            cRoundNumber++;
                            Score = Roundnumber * cRoundNumber;
                        }

                        RoundScore.Text = Score + "";


                    }
                }
                else
                {
                    Score = 0;
                    RoundScore.Text = Score + "";
                }
                FinalScore = FinalScore + Score;
                lblFinalScore.Text = FinalScore.ToString();

                if (cRoundNumber == 3)    // calculatig whoohoo bonus score 
                {
                    Score = Roundnumber * 3;
                    BonusScore = 20;
                    Roundnumber++;
                    count = 0;
                    lblComment1.Text = "Whoohoo: all three dice rolled, and " +
                        "all three display" + "" +
                        " the round number. Turn ends automatically.";
                    RoundScore.Text = Score + "";
                    lblBonusScore.Text = BonusScore.ToString();
                }
                else
                {
                    BonusScore = 0;
                    lblBonusScore.Text = BonusScore.ToString();
                }
                FinalScore = FinalScore + BonusScore;
            }

        }


        private void Comment()  // all the comments for the game 
        {
            if (rbtnSinglePlayer.Checked)
            {
                if (chbxfor3_Dice.Checked)
                { lblComment1.Text = "Player rolls all 3 dice again"; }
                if (chbxhold_1.Checked)
                {
                    lblComment1.Text = "Player decides to hold the 1";

                }
                if (chbxhold_2.Checked)
                {
                    lblComment1.Text = "Player decides to hold the 2";
                }
                if (chbxhold_3.Checked)
                {
                    lblComment1.Text = "Player decides to hold the 3";
                }
            }
            if (rbtnDoublePlayer.Checked)
            {
                if (rbtnPlayer1.Checked)
                {

                    if (chbxfor3_Dice.Checked)
                    {
                        lblCommentp2.Text = "Player rolls all 3 dice again";

                    }
                    if (chbxhold_1.Checked)
                    {
                        lblCommentp2.Text = "Player decides to hold the 1";

                    }
                    if (chbxhold_2.Checked)
                    {
                        lblCommentp2.Text = "Player decides to hold the 2";
                    }
                    if (chbxhold_3.Checked)
                    {
                        lblCommentp2.Text = "Player decides to hold the 3";
                    }
                }
                else
                {

                    if (chbxfor3_Dice.Checked)
                    {
                        lblCommentp1.Text = "Player rolls all 3 dice again";

                    }
                    if (chbxhold_1.Checked)
                    {
                        lblCommentp1.Text = "Player decides to hold the 1";

                    }
                    if (chbxhold_2.Checked)
                    {
                        lblCommentp1.Text = "Player decides to hold the 2";
                    }
                    if (chbxhold_3.Checked)
                    {
                        lblCommentp1.Text = "Player decides to hold the 3";
                    }
                }
            }
            if (rbtnComputer.Checked)
            {
                if (rbtnPlayerVsp.Checked)
                {
                    if (chbxfor3_Dice.Checked)
                    {
                        lblCommentp1.Text = "Player rolls all 3 dice again";

                    }
                    if (chbxhold_1.Checked)
                    {
                        lblCommentp1.Text = "Player decides to hold the 1";

                    }
                    if (chbxhold_2.Checked)
                    {
                        lblCommentp1.Text = "Player decides to hold the 2";
                    }
                    if (chbxhold_3.Checked)
                    {
                        lblCommentp1.Text = "Player decides to hold the 3";
                    }
                }
                else

                  if (chbxfor3_Dice.Checked)
                {
                    lblCommentp2.Text = "Player rolls all 3 dice again";

                }

                if (chbxhold_1.Checked)
                {
                    lblCommentp2.Text = "Player decides to hold the 1";

                }
                if (chbxhold_2.Checked)
                {
                    lblCommentp2.Text = "Player decides to hold the 2";
                }
                if (chbxhold_3.Checked)
                {
                    lblCommentp2.Text = "Player decides to hold the 3";
                }
            }



        }


        public void swap(ref int count, ref int Roundnumber) // to calculate a rolls and round number for single player, double player
        {

            count++;
            if (count == 4)
            {
                Roundnumber++;
                count = 1;
                lblRollsScore.Text = count.ToString();
                lblRoundScore.Text = Roundnumber.ToString();



            }
            if (chbxFinishRound.Checked)
            {
                Roundnumber++;

                count = 1;
                lblRollsScore.Text = count.ToString();
                lblRoundScore.Text = Roundnumber.ToString();
                chbxFinishRound.Checked = false;
            }

            if (Roundnumber == 6 && count == 3 && rbtnSinglePlayer.Checked || chbxFinishRound.Checked && Roundnumber == 6 && rbtnSinglePlayer.Checked)
            {
                FinalScore = FinalScore + Score;
                btnRollDice.Enabled = false;
                lblInstructions.Visible = true;
                lblInstructions.Text = " Player wins – but that’s easy in a 1-player game!";

                lblGameScore.Visible = true;
                lblFinalScore.Visible = true;
            }
            if (rbtnDoublePlayer.Checked)
            {
                if (count == 3 && rbtnPlayer1.Checked && RoundNop1 == 6)
                {
                    if (FinalScorep1 > FinalScorep2)
                    {
                        win1++;

                        string player2 = Convert.ToString(tbxPlayer1name.Text);
                        lblPlayersInstructions.Text = "Game Over! " + player2 + "  Won";

                    }
                    if (FinalScorep2 > FinalScorep1)
                    {
                        win2++;
                        string player1 = Convert.ToString(tbxPlayer2Name.Text);
                        lblPlayersInstructions.Text = "Game Over! " + player1 + "  Won";

                    }

                    rbtnPlayer1.Checked = false;
                    rbtnPlayer2.Checked = false;
                    lblGamescp1.Visible = true;
                    lblGamescp2.Visible = true;
                    WinsPlayer2.Text = win2.ToString();
                    WinsPlayer1.Text = win1.ToString();
                    btnRollDice.Enabled = false;
                }
            }
        }


        private void chbx_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox chkbx = (CheckBox)sender;
            if (chbxhold_1.Checked && chbxhold_2.Checked)
            {
                chbxhold_3.Checked = false;
            }
            if (chbxhold_2.Checked && chbxhold_3.Checked)
            {
                chbxhold_1.Checked = false;
            }
            if (chbxhold_1.Checked && chbxhold_3.Checked)
            {
                chbxhold_2.Checked = false;
            }
        }



        private void btnRollDice_Click_1(object sender, EventArgs e)
        {
            if (chbxhold_1.Checked == false && chbxhold_2.Checked == false && chbxhold_3.Checked == false && chbxfor3_Dice.Checked == false)
            {
                chbxfor3_Dice.Checked = true;
            }

            swap(ref count, ref Roundnumber);
            lblRollsScore.Text = count.ToString();
            lblRoundScore.Text = Roundnumber.ToString();
            //lblFinalScore.Text = FinalScore.ToString();
            Comment();

            if (rbtnDoublePlayer.Checked == true)      // code for alternate player's turn accordingly ! // check change 
            {

                if (checkChange == true)
                {

                    if (count == 1)
                    {
                        rbtnPlayer1.Checked = true;
                        rbtnPlayer2.Checked = false;
                        RoundNop1++;
                        lblRoundscp2.Text = RoundNop1.ToString();
                        chbxhold_1.Checked = false;
                        chbxhold_2.Checked = false;
                        chbxhold_3.Checked = false;

                    }

                }
                else
                {
                    if (count == 1)
                    {
                        rbtnPlayer1.Checked = false;
                        rbtnPlayer2.Checked = true;
                        RoundNop2++;
                        lblRoundscp1.Text = RoundNop2.ToString();
                        chbxhold_1.Checked = false;
                        chbxhold_2.Checked = false;
                        chbxhold_3.Checked = false;
                    }

                }
                RollDice();              // callig  Rolldice method 
                if (checkChange == true) checkChange = false;
                else checkChange = true;
            }

            if (rbtnComputer.Checked == true)    // code for alternate player and program 
            {
                if (rbtnPlayerVsp.Checked == true)
                {

                    lblRollsp1.Text = count.ToString();
                    lblRollsp2.Text = "0";
                    Comment();
                    RollDice();

                    if (count == 1)
                    {
                        RoundNop1++;
                        lblRoundscp1.Text = RoundNop1.ToString();
                    }


                    if (count == 3)
                    {
                        rbtnPlayerVsp.Checked = false;
                        rbtnProgram.Checked = true;
                        btnRollDice.Enabled = false;
                        chbxhold_1.Checked = false;
                        chbxhold_2.Checked = false;
                        chbxhold_3.Checked = false;

                    }
                }
            }

            if (rbtnProgram.Checked == true)                  //if program is playing with user the following steps will be followed
            {


                System.Threading.Thread.Sleep(1000);     // 1 second gap between player & program's dice rolled up
                {
                    count = 1; lblRollsp2.Text = count.ToString();
                    RoundNop2++;
                    lblRoundscp2.Text = RoundNop2.ToString();
                }
                RollDice();         // rolling the dice !
                Comment();


                System.Threading.Thread.Sleep(1000);
                { count = 2; lblRollsp2.Text = count.ToString(); }
                RollDice();
                Comment();

                System.Threading.Thread.Sleep(1000);
                { count = 3; lblRollsp2.Text = count.ToString(); }
                RollDice();
                Comment();

                if (RoundNop2 == 6 && count == 3)
                {
                    if (FinalScorep1 > FinalScorep2)
                    {
                        win1++;
                        string player1 = Convert.ToString(tbxPlayer1name.Text);
                        lblPlayersInstructions.Text = "Game Over! " + player1 + "  Won";

                    }
                    if (FinalScorep2 > FinalScorep1)
                    {
                        win2++;
                        lblPlayersInstructions.Text = "Game Over! " + "Computer" + "  Won";
                    }

                    rbtnProgram.Checked = false;
                    rbtnPlayerVsp.Checked = false;
                    lblGamescp1.Visible = true;
                    lblGamescp2.Visible = true;
                    WinsPlayer2.Text = win2.ToString();
                    WinsPlayer1.Text = win1.ToString();
                    btnRollDice.Enabled = false;
                }


            }


            if (rbtnComputer.Checked == true)    // code for alternate player and program 
            {
                if (rbtnProgram.Checked == true)
                {


                    if (count == 3)
                    {
                        rbtnProgram.Checked = false;
                        rbtnPlayerVsp.Checked = true;
                        btnRollDice.Enabled = true;
                        chbxhold_1.Checked = false;
                        chbxhold_2.Checked = false;
                        chbxhold_3.Checked = false;

                    }
                }
            }


            if (rbtnSinglePlayer.Checked)
            {
                RollDice();
            }

            if (rbtnDoublePlayer.Checked)
            {
                if (rbtnPlayer1.Checked)     // code for instruction label showing player's turn and what to do
                {
                    string player1 = Convert.ToString(tbxPlayer2Name.Text);
                    lblPlayersInstructions.Text = player1 + "'s turn !";

                    lblRollsp2.Text = count.ToString();
                    lblRollsp1.Text = "0";
                    Comment();
                    if (count == 3)
                    {

                        string p2 = Convert.ToString(tbxPlayer1name.Text);
                        lblPlayersInstructions.Text = p2 + "'s turn ! ";
                    }

                }
                if (rbtnPlayer2.Checked == true)          // code for instruction label and player's turn & what to do 
                {

                    string p2 = Convert.ToString(tbxPlayer1name.Text);
                    lblPlayersInstructions.Text = p2 + "'s turn ! ";

                    lblRollsp1.Text = count.ToString();
                    lblRollsp2.Text = "0";
                    Comment();
                    if (count == 3)
                    {
                        string player1 = Convert.ToString(tbxPlayer2Name.Text);
                        lblPlayersInstructions.Text = player1 + "'s turn !";
                    }

                }
            }



        }

        private void rbtnSinglePlayer_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbtnSinglePlayer.Checked)  // for single player
            {
                ChooseOnegrp.Visible = false;
                DiceControlgrp.Visible = true;
                SinglePlayergrp.Visible = true;
                lblInstructions.Visible = false;
                lblRoundScore.Text = Roundnumber.ToString();
                PlayerVSprogramgrp.Enabled = false;
                PlayerVSprogramgrp.Visible = false;
                Playersgrp.Enabled = false;
                Playersgrp.Visible = false;


            }
        }

        private void rbtnDoublePlayer_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbtnDoublePlayer.Checked)  // when double player radio button clicks // for 2 players
            {
                ChooseOnegrp.Visible = false;
                DiceControlgrp.Visible = true;
                SinglePlayergrp.Visible = false;
                lblInstructions.Visible = false;
                lblRoundScore.Text = Roundnumber.ToString();
                DoublePlayersgrp.Visible = true;
                PlayerVSprogramgrp.Enabled = false;
                PlayerVSprogramgrp.Visible = false;
                string player1 = Convert.ToString(tbxPlayer1name.Text);
                lblPlayer1.Text = player1;
                string player2 = Convert.ToString(tbxPlayer2Name.Text);
                lblPlayer2.Text = player2;
                lblPlayersInstructions.Text = player1 + "'s turn!";

            }
        }

        private void rbtnComputer_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbtnComputer.Checked) //  for Program Vs player
            {
                rbtnPlayerVsp.Checked = true;
                ChooseOnegrp.Visible = false;
                DiceControlgrp.Visible = true;
                SinglePlayergrp.Visible = false;
                lblInstructions.Visible = false;
                lblRoundScore.Text = Roundnumber.ToString();
                DoublePlayersgrp.Visible = true;
                Playersgrp.Enabled = false;
                Playersgrp.Visible = false;
                tbxPlayer2Name.Text = "Computer";
                lblPlayer2.Text = "Computer";
                string player1 = Convert.ToString(tbxPlayer1name.Text);
                lblPlayer1.Text = player1;

            }
        }



        private void btnNewGane_Click_1(object sender, EventArgs e)
        {
            Application.Restart();    // new gamee 
        }

        private void tbxPlayerName_MouseLeave_1(object sender, EventArgs e)  // for names using mouse leave handler 
        {
            string playerName = Convert.ToString(tbxPlayerName.Text);          // taking player 1's name to label to show name   
            lblSinglePlayer.Text = playerName;                       //player enter names in text box it will appear in label accordingly !!
            if (playerName == "")              // if player name empty the message box will appear & give message to user
                MessageBox.Show("Please enter player 1 Name");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void tbxPlayer1name_MouseLeave(object sender, EventArgs e)
        {
            string player1 = Convert.ToString(tbxPlayer1name.Text);
            lblPlayer1.Text = player1;
            lblPlayersInstructions.Text = player1 + "'s turn!";

        }

        private void tbxPlayer2Name_MouseLeave(object sender, EventArgs e)
        {
            if (rbtnDoublePlayer.Checked)
            {
                string player2 = Convert.ToString(tbxPlayer2Name.Text);
                lblPlayer2.Text = player2;

            }

        }

        private void rbtnPlayerVsp_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPlayerVsp.Checked == true)  // when player is playing rules will be implemented acordingly 
            {
                // int goalScore = Convert.ToInt32(tbx_GoalScore.Text);   // taking user input goal score to compare with score 
                string player1 = Convert.ToString(tbxPlayer1name.Text);             // taking input name of player 1
                                                                                    //if (Score2 < goalScore)                // if program score is less than goal score then following instruction will be printed and player will take the turn
                lblPlayersInstructions.Text = player1 + "'s turn!";           // instructions

            }
            else
            {
                string player2 = Convert.ToString(tbxPlayer2Name.Text);             // taking input name of player 2

                lblPlayersInstructions.Text = player2 + "'s turn!";
            }

        }

        private void Whoohoo_Load(object sender, EventArgs e)
        {
            Playersgrp.Visible = false;
            PlayerVSprogramgrp.Visible = false;
        }

        private void btnReplay_Click(object sender, EventArgs e) // for reply a game // all sets back to 0 
        {

            RoundNop1 = 0;
            RoundNop2 = 0;
            FinalScorep1 = 0;
            FinalScorep2 = 0;
            RoundScore1 = 0;
            RoundScore2 = 0;
            lblRoundscp1.Text = RoundNop1.ToString();
            lblRoundscp2.Text = RoundNop2.ToString();
            lblRoundScorep1.Text = RoundScore1.ToString();
            lblRoundScorep2.Text = RoundScore2.ToString();
            lblGamescp1.Visible = false;
            lblGamescp2.Visible = false;
            count = 0;
            btnRollDice.Enabled = true;
            if (rbtnComputer.Checked)
            {
                rbtnPlayerVsp.Checked = true;
            }
            if (rbtnDoublePlayer.Checked)
            {
                rbtnPlayer1.Checked = true;

            }


        }


    }
}
