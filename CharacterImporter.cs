﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Carnage
{
    public class CharacterImporter
    {
        RNG rng = new RNG();

        public int characterCount(string charID)
        {
            string sql = "Server=sql5.freesqldatabase.com;Database=sql5693000;Uid=sql5693000;Pwd=yD7AbEqn2I;";
            MySqlConnection con = new MySqlConnection(sql);

            string strSQL = "SELECT COUNT(CharID) FROM Characters WHERE CharID = '" + charID + "';";

            MySqlCommand sqlComd = new MySqlCommand(strSQL, con);
            DataSet dsSQLDataSet = new DataSet();
            MySqlDataAdapter daAdapter = new MySqlDataAdapter(strSQL, con);

            con.Open();
            daAdapter.Fill(dsSQLDataSet);

            int num = Int32.Parse(dsSQLDataSet.Tables[0].Rows[0][0].ToString());

            con.Close();
            return num;
        }

        public int totalCount()
        {
            string sql = "Server=sql5.freesqldatabase.com;Database=sql5693000;Uid=sql5693000;Pwd=yD7AbEqn2I;";
            MySqlConnection con = new MySqlConnection(sql);

            string strSQL = "SELECT COUNT(*) FROM Characters;";

            MySqlCommand sqlComd = new MySqlCommand(strSQL, con);
            DataSet dsSQLDataSet = new DataSet();
            MySqlDataAdapter daAdapter = new MySqlDataAdapter(strSQL, con);

            con.Open();
            daAdapter.Fill(dsSQLDataSet);

            int num = Int32.Parse(dsSQLDataSet.Tables[0].Rows[0][0].ToString());

            con.Close();
            return num;
        }

        public int searchTagCount(string tag, int number)
        {
            string sql = "Server=sql5.freesqldatabase.com;Database=sql5693000;Uid=sql5693000;Pwd=yD7AbEqn2I;";
            MySqlConnection con = new MySqlConnection(sql);

            string strSQL = "SELECT COUNT(Tag" + number + ") FROM Characters WHERE Tag" + number + " = '" + tag + "';";

            MySqlCommand sqlComd = new MySqlCommand(strSQL, con);
            DataSet dsSQLDataSet = new DataSet();
            MySqlDataAdapter daAdapter = new MySqlDataAdapter(strSQL, con);

            con.Open();
            daAdapter.Fill(dsSQLDataSet);

            int num = Int32.Parse(dsSQLDataSet.Tables[0].Rows[0][0].ToString());

            con.Close();
            return num;
        }

        public string searchTag(string tag)
        {
            string sql = "Server=sql5.freesqldatabase.com;Database=sql5693000;Uid=sql5693000;Pwd=yD7AbEqn2I;";
            MySqlConnection con = new MySqlConnection(sql);

            int intTag1Count = searchTagCount(tag, 1);
            int intTag2Count = searchTagCount(tag, 2);
            int intTag3Count = searchTagCount(tag, 3);

            string strTag1 = "SELECT * FROM Characters WHERE Tag1 = '" + tag + "' ORDER BY CharID;";
            string strTag2 = "SELECT * FROM Characters WHERE Tag2 = '" + tag + "' ORDER BY CharID;";
            string strTag3 = "SELECT * FROM Characters WHERE Tag3 = '" + tag + "' ORDER BY CharID;";


            StringBuilder sb = new StringBuilder();

            if (intTag1Count > 0 && intTag2Count == 0)
            {
                MySqlCommand sqlComd = new MySqlCommand(strTag1, con);
                DataSet dsSQLDataSet = new DataSet();
                MySqlDataAdapter daAdapter = new MySqlDataAdapter(strTag1, con);

                con.Open();
                daAdapter.Fill(dsSQLDataSet);

                for (int i = 0; i < intTag1Count; i++)
                {
                    sb.AppendLine(dsSQLDataSet.Tables[0].Rows[i][0].ToString());
                }
                con.Close();
                return sb.ToString();
            }
            else if (intTag2Count > 0 && intTag1Count == 0 && intTag3Count == 0)
            {
                MySqlCommand sqlComd = new MySqlCommand(strTag2, con);
                DataSet dsSQLDataSet = new DataSet();
                MySqlDataAdapter daAdapter = new MySqlDataAdapter(strTag2, con);

                con.Open();
                daAdapter.Fill(dsSQLDataSet);

                for (int i = 0; i < intTag2Count; i++)
                {
                    sb.AppendLine(dsSQLDataSet.Tables[0].Rows[i][0].ToString());
                }
                con.Close();
                return sb.ToString();
            }
            else if (intTag3Count > 0 && intTag2Count == 0 && intTag1Count == 0)
            {
                MySqlCommand sqlComd = new MySqlCommand(strTag3, con);
                DataSet dsSQLDataSet = new DataSet();
                MySqlDataAdapter daAdapter = new MySqlDataAdapter(strTag3, con);

                con.Open();
                daAdapter.Fill(dsSQLDataSet);

                for (int i = 0; i < intTag3Count; i++)
                {
                    sb.AppendLine(dsSQLDataSet.Tables[0].Rows[i][0].ToString());
                }
                con.Close();
                return sb.ToString();
            }
            else if (intTag1Count > 0 && intTag2Count > 0)
            {
                MySqlCommand sqlComd = new MySqlCommand(strTag1, con);
                DataSet dsSQLDataSet = new DataSet();
                MySqlDataAdapter daAdapter = new MySqlDataAdapter(strTag1, con);

                con.Open();
                daAdapter.Fill(dsSQLDataSet);

                for (int i = 0; i < intTag1Count; i++)
                {
                    sb.AppendLine(dsSQLDataSet.Tables[0].Rows[i][0].ToString());
                }
                con.Close();

                sqlComd = new MySqlCommand(strTag2, con);
                dsSQLDataSet = new DataSet();
                daAdapter = new MySqlDataAdapter(strTag2, con);

                con.Open();
                daAdapter.Fill(dsSQLDataSet);

                for (int i = 0; i < intTag2Count; i++)
                {
                    sb.AppendLine(dsSQLDataSet.Tables[0].Rows[i][0].ToString());
                }
                con.Close();
                return sb.ToString();
            }
            else if (intTag2Count > 0 && intTag3Count > 0)
            {
                MySqlCommand sqlComd = new MySqlCommand(strTag2, con);
                DataSet dsSQLDataSet = new DataSet();
                MySqlDataAdapter daAdapter = new MySqlDataAdapter(strTag2, con);

                con.Open();
                daAdapter.Fill(dsSQLDataSet);

                for (int i = 0; i < intTag2Count; i++)
                {
                    sb.AppendLine(dsSQLDataSet.Tables[0].Rows[i][0].ToString());
                }
                con.Close();

                sqlComd = new MySqlCommand(strTag3, con);
                dsSQLDataSet = new DataSet();
                daAdapter = new MySqlDataAdapter(strTag3, con);

                con.Open();
                daAdapter.Fill(dsSQLDataSet);

                for (int i = 0; i < intTag3Count; i++)
                {
                    sb.AppendLine(dsSQLDataSet.Tables[0].Rows[i][0].ToString());
                }
                con.Close();
                return sb.ToString();
            }
            else
            {
                con.Close();
                return "No characters found with that tag.";
            };
        }

        public string ShowAll()
        {
            string sql = "Server=sql5.freesqldatabase.com;Database=sql5693000;Uid=sql5693000;Pwd=yD7AbEqn2I;";
            MySqlConnection con = new MySqlConnection(sql);

            string strAll = "SELECT * FROM Characters ORDER BY CharID;";

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.totalCount(); i++)
            {
                MySqlCommand sqlComd = new MySqlCommand(strAll, con);
                DataSet dsSQLDataSet = new DataSet();
                MySqlDataAdapter daAdapter = new MySqlDataAdapter(strAll, con);

                con.Open();
                daAdapter.Fill(dsSQLDataSet);

                sb.AppendLine(dsSQLDataSet.Tables[0].Rows[i][0].ToString());

                con.Close();
            }

            return sb.ToString();
        }

        public List<string> Randomize(int number)
        {
            List<string> stringList = new List<string>();
            List<int> intList = new List<int>();
            int total = this.totalCount(), i=0;

            intList=rng.RandomIntList(total-1, number);

            string sql = "Server=sql5.freesqldatabase.com;Database=sql5693000;Uid=sql5693000;Pwd=yD7AbEqn2I;";
            MySqlConnection con = new MySqlConnection(sql);
            string strAll = "SELECT CharID FROM Characters;";

            MySqlCommand sqlComd = new MySqlCommand(strAll, con);
            DataSet dsSQLDataSet = new DataSet();
            MySqlDataAdapter daAdapter = new MySqlDataAdapter(strAll, con);

            con.Open();
            daAdapter.Fill(dsSQLDataSet);

            while (i<number) 
            {
                stringList.Add((dsSQLDataSet.Tables[0].Rows[intList[i]][0].ToString()));    
                i++;
            }
            
            con.Close();

            return stringList;
        }

        private List<string> pronounList(List<string> list, int number)
        {
            List<string> pronounList = new List<string>();
            string strName;

            string sql = "Server=sql5.freesqldatabase.com;Database=sql5693000;Uid=sql5693000;Pwd=yD7AbEqn2I;";
            MySqlConnection con = new MySqlConnection(sql);

            for (int i=0; i<number; i++)
            {
                strName = "SELECT Pronoun FROM Characters WHERE CharID = '" + list[i] + "';";
                MySqlCommand sqlComd = new MySqlCommand(strName, con);
                DataSet dsSQLDataSet = new DataSet();
                MySqlDataAdapter daAdapter = new MySqlDataAdapter(strName, con);

                con.Open();
                daAdapter.Fill(dsSQLDataSet);

                pronounList.Add(dsSQLDataSet.Tables[0].Rows[0][0].ToString());

                con.Close();
            }
            return pronounList;
        }

        private List<double> speedList(List<string> list, int number)
        {
            List<double> speedList = new List<double>();
            string strName;

            string sql = "Server=sql5.freesqldatabase.com;Database=sql5693000;Uid=sql5693000;Pwd=yD7AbEqn2I;";
            MySqlConnection con = new MySqlConnection(sql);

            for (int i = 0; i < number; i++)
            {
                strName = "SELECT Speed FROM Characters WHERE CharID = '" + list[i] + "';";
                MySqlCommand sqlComd = new MySqlCommand(strName, con);
                DataSet dsSQLDataSet = new DataSet();
                MySqlDataAdapter daAdapter = new MySqlDataAdapter(strName, con);

                con.Open();
                daAdapter.Fill(dsSQLDataSet);

                speedList.Add(double.Parse(dsSQLDataSet.Tables[0].Rows[0][0].ToString()));

                con.Close();
            }
            return speedList;
        }

        private List<double> strengthList(List<string> list, int number)
        {
            List<double> strengthList = new List<double>();
            string strName;

            string sql = "Server=sql5.freesqldatabase.com;Database=sql5693000;Uid=sql5693000;Pwd=yD7AbEqn2I;";
            MySqlConnection con = new MySqlConnection(sql);

            for (int i = 0; i < number; i++)
            {
                strName = "SELECT Strength FROM Characters WHERE CharID = '" + list[i] + "';";
                MySqlCommand sqlComd = new MySqlCommand(strName, con);
                DataSet dsSQLDataSet = new DataSet();
                MySqlDataAdapter daAdapter = new MySqlDataAdapter(strName, con);

                con.Open();
                daAdapter.Fill(dsSQLDataSet);

                strengthList.Add(double.Parse(dsSQLDataSet.Tables[0].Rows[0][0].ToString()));

                con.Close();
            }
            return strengthList;
        }

        private List<double> moralList(List<string> list, int number)
        {
            List<double> moralList = new List<double>();
            string strName;

            string sql = "Server=sql5.freesqldatabase.com;Database=sql5693000;Uid=sql5693000;Pwd=yD7AbEqn2I;";
            MySqlConnection con = new MySqlConnection(sql);

            for (int i = 0; i < number; i++)
            {
                strName = "SELECT MoralityLevel FROM Characters WHERE CharID = '" + list[i] + "';";
                MySqlCommand sqlComd = new MySqlCommand(strName, con);
                DataSet dsSQLDataSet = new DataSet();
                MySqlDataAdapter daAdapter = new MySqlDataAdapter(strName, con);

                con.Open();
                daAdapter.Fill(dsSQLDataSet);

                moralList.Add(double.Parse(dsSQLDataSet.Tables[0].Rows[0][0].ToString()));

                con.Close();
            }
            return moralList;
        }

        public string CheckList(List<string> list, int number)
        {
            StringBuilder sb1 = new StringBuilder();

            for (int i = 0;i < number;i++)
            {
                if (this.characterCount(list[i])==0)
                {
                    sb1.AppendLine("Character " + list[i] + " not found. Please enter a valid character name to continue.");
                }
            }
            
            return sb1.ToString();
        }

        public List<character> ConvertToCharacters(List<string> list, string gameMode, int numPlayers)
        {
            List<character> charList = new List<character>();
            List<string> pronounList = new List<string>();
            List<double> strengthList = new List<double>();
            List<double> moralList = new List<double>();
            List<double> speedList = new List<double>();

            pronounList = this.pronounList(list, numPlayers);

            if (gameMode=="Realistic")
            {
                strengthList = this.strengthList(list, numPlayers);
                moralList = this.moralList(list, numPlayers);
                speedList = this.speedList(list, numPlayers);
            }

            if (gameMode == "Classic" && numPlayers == 24)
            {
                //instantiates all 24 characters and adds them to list
                //
                //District 1
                character charD1C1 = new character(list[0], pronounList[0] ,1);
                charList.Add(charD1C1);
                character charD1C2 = new character(list[1], pronounList[1], 1);
                charList.Add(charD1C2);
                //District 2
                character charD2C1 = new character(list[2], pronounList[2], 2);
                charList.Add(charD2C1);
                character charD2C2 = new character(list[3], pronounList[3], 2);
                charList.Add(charD2C2);
                //District 3
                character charD3C1 = new character(list[4], pronounList[4], 3);
                charList.Add(charD3C1);
                character charD3C2 = new character(list[5], pronounList[5], 3);
                charList.Add(charD3C2);
                //District 4
                character charD4C1 = new character(list[6], pronounList[6], 4);
                charList.Add(charD4C1);
                character charD4C2 = new character(list[7], pronounList[7], 4);
                charList.Add(charD4C2);
                //District 5
                character charD5C1 = new character(list[8], pronounList[8], 5);
                charList.Add(charD5C1);
                character charD5C2 = new character(list[9], pronounList[9], 5);
                charList.Add(charD5C2);
                //District 6
                character charD6C1 = new character(list[10], pronounList[10], 6);
                charList.Add(charD6C1);
                character charD6C2 = new character(list[11], pronounList[11], 6);
                charList.Add(charD6C2);
                //District 7
                character charD7C1 = new character(list[12], pronounList[12], 7);
                charList.Add(charD7C1);
                character charD7C2 = new character(list[13], pronounList[13], 7);
                charList.Add(charD7C2);
                //District 8
                character charD8C1 = new character(list[14], pronounList[14], 8);
                charList.Add(charD8C1);
                character charD8C2 = new character(list[15], pronounList[15], 8);
                charList.Add(charD8C2);
                //District 9
                character charD9C1 = new character(list[16], pronounList[16], 9);
                charList.Add(charD9C1);
                character charD9C2 = new character(list[17], pronounList[17], 9);
                charList.Add(charD9C2);
                //District 10
                character charD10C1 = new character(list[18], pronounList[18], 10);
                charList.Add(charD10C1);
                character charD10C2 = new character(list[19], pronounList[19], 10);
                charList.Add(charD10C2);
                //District 11
                character charD11C1 = new character(list[20], pronounList[20], 11);
                charList.Add(charD11C1);
                character charD11C2 = new character(list[21], pronounList[21], 11);
                charList.Add(charD11C2);
                //District 12
                character charD12C1 = new character(list[22], pronounList[22], 12);
                charList.Add(charD12C1);
                character charD12C2 = new character(list[23], pronounList[23], 12);
                charList.Add(charD12C2);
            }
            else if (gameMode == "Realistic" && numPlayers == 24)
            {
                //instantiates all 24 characters and adds them to list
                //
                //District 1
                character charD1C1 = new character(list[0], pronounList[0], strengthList[0], moralList[0], speedList[0], 1);
                charList.Add(charD1C1);
                character charD1C2 = new character(list[1], pronounList[1], strengthList[1], moralList[1], speedList[1], 1);
                charList.Add(charD1C2);
                //District 2
                character charD2C1 = new character(list[2], pronounList[2], strengthList[2], moralList[2], speedList[2], 2);
                charList.Add(charD2C1);
                character charD2C2 = new character(list[3], pronounList[3], strengthList[3], moralList[3], speedList[3], 2);
                charList.Add(charD2C2);
                //District 3
                character charD3C1 = new character(list[4], pronounList[4], strengthList[4], moralList[4], speedList[4], 3);
                charList.Add(charD3C1);
                character charD3C2 = new character(list[5], pronounList[5], strengthList[5], moralList[5], speedList[5], 3);
                charList.Add(charD3C2);
                //District 4
                character charD4C1 = new character(list[6], pronounList[6], strengthList[6], moralList[6], speedList[6], 4);
                charList.Add(charD4C1);
                character charD4C2 = new character(list[7], pronounList[7], strengthList[7], moralList[7], speedList[7], 4);
                charList.Add(charD4C2);
                //District 5
                character charD5C1 = new character(list[8], pronounList[8], strengthList[8], moralList[8], speedList[8], 5);
                charList.Add(charD5C1);
                character charD5C2 = new character(list[9], pronounList[9], strengthList[9], moralList[9], speedList[9], 5);
                charList.Add(charD5C2);
                //District 6
                character charD6C1 = new character(list[10], pronounList[10], strengthList[10], moralList[10], speedList[10], 6);
                charList.Add(charD6C1);
                character charD6C2 = new character(list[11], pronounList[11], strengthList[11], moralList[11], speedList[11], 6);
                charList.Add(charD6C2);
                //District 7
                character charD7C1 = new character(list[12], pronounList[12], strengthList[12], moralList[12], speedList[12], 7);
                charList.Add(charD7C1);
                character charD7C2 = new character(list[13], pronounList[13], strengthList[13], moralList[13], speedList[13], 7);
                charList.Add(charD7C2);
                //District 8
                character charD8C1 = new character(list[14], pronounList[14], strengthList[14], moralList[14], speedList[14], 8);
                charList.Add(charD8C1);
                character charD8C2 = new character(list[15], pronounList[15], strengthList[15], moralList[15], speedList[15], 8);
                charList.Add(charD8C2);
                //District 9
                character charD9C1 = new character(list[16], pronounList[16], strengthList[16], moralList[16], speedList[16], 9);
                charList.Add(charD9C1);
                character charD9C2 = new character(list[17], pronounList[17], strengthList[17], moralList[17], speedList[17], 9);
                charList.Add(charD9C2);
                //District 10
                character charD10C1 = new character(list[18], pronounList[18], strengthList[18], moralList[18], speedList[18], 10);
                charList.Add(charD10C1);
                character charD10C2 = new character(list[19], pronounList[19], strengthList[19], moralList[19], speedList[19], 10);
                charList.Add(charD10C2);
                //District 11
                character charD11C1 = new character(list[20], pronounList[20], strengthList[20], moralList[20], speedList[20], 11);
                charList.Add(charD11C1);
                character charD11C2 = new character(list[21], pronounList[21], strengthList[21], moralList[21], speedList[21], 11);
                charList.Add(charD11C2);
                //District 12
                character charD12C1 = new character(list[22], pronounList[22], strengthList[22], moralList[22], speedList[22], 12);
                charList.Add(charD12C1);
                character charD12C2 = new character(list[23], pronounList[23], strengthList[23], moralList[23], speedList[23], 12);
                charList.Add(charD12C2);
            }
            else if (gameMode == "Classic" && numPlayers == 48)
            {
                //instantiates all 48 characters and adds them to list
                //
                //District 1
                character charD1C1 = new character(list[0], pronounList[0], 1);
                charList.Add(charD1C1);
                character charD1C2 = new character(list[1], pronounList[1], 1);
                charList.Add(charD1C2);
                character charD1C3 = new character(list[2], pronounList[2], 1);
                charList.Add(charD1C3);
                character charD1C4 = new character(list[3], pronounList[3], 1);
                charList.Add(charD1C4);
                //District 2
                character charD2C1 = new character(list[4], pronounList[4], 2);
                charList.Add(charD2C1);
                character charD2C2 = new character(list[5], pronounList[5], 2);
                charList.Add(charD2C2);
                character charD2C3 = new character(list[6], pronounList[6], 2);
                charList.Add(charD2C3);
                character charD2C4 = new character(list[7], pronounList[7], 2);
                charList.Add(charD2C4);
                //District 3
                character charD3C1 = new character(list[8], pronounList[8], 3);
                charList.Add(charD3C1);
                character charD3C2 = new character(list[9], pronounList[9], 3);
                charList.Add(charD3C2);
                character charD3C3 = new character(list[10], pronounList[10], 3);
                charList.Add(charD3C3);
                character charD3C4 = new character(list[11], pronounList[11], 3);
                charList.Add(charD3C4);
                //District 4
                character charD4C1 = new character(list[12], pronounList[12], 4);
                charList.Add(charD4C1);
                character charD4C2 = new character(list[13], pronounList[13], 4);
                charList.Add(charD4C2);
                character charD4C3 = new character(list[14], pronounList[14], 4);
                charList.Add(charD4C3);
                character charD4C4 = new character(list[15], pronounList[15], 4);
                charList.Add(charD4C4);
                //District 5
                character charD5C1 = new character(list[16], pronounList[16], 5);
                charList.Add(charD5C1);
                character charD5C2 = new character(list[17], pronounList[17], 5);
                charList.Add(charD5C2);
                character charD5C3 = new character(list[18], pronounList[18], 5);
                charList.Add(charD5C3);
                character charD5C4 = new character(list[19], pronounList[19], 5);
                charList.Add(charD5C4);
                //District 6
                character charD6C1 = new character(list[20], pronounList[20], 6);
                charList.Add(charD6C1);
                character charD6C2 = new character(list[21], pronounList[21], 6);
                charList.Add(charD6C2);
                character charD6C3 = new character(list[22], pronounList[22], 6);
                charList.Add(charD6C3);
                character charD6C4 = new character(list[23], pronounList[23], 6);
                charList.Add(charD6C4);
                //District 7
                character charD7C1 = new character(list[24], pronounList[24], 7);
                charList.Add(charD7C1);
                character charD7C2 = new character(list[25], pronounList[25], 7);
                charList.Add(charD7C2);
                character charD7C3 = new character(list[26], pronounList[26], 7);
                charList.Add(charD7C3);
                character charD7C4 = new character(list[27], pronounList[27], 7);
                charList.Add(charD7C4);
                //District 8
                character charD8C1 = new character(list[28], pronounList[28], 8);
                charList.Add(charD8C1);
                character charD8C2 = new character(list[29], pronounList[29], 8);
                charList.Add(charD8C2);
                character charD8C3 = new character(list[30], pronounList[30], 8);
                charList.Add(charD8C3);
                character charD8C4 = new character(list[31], pronounList[31], 8);
                charList.Add(charD8C4);
                //District 9
                character charD9C1 = new character(list[32], pronounList[32], 9);
                charList.Add(charD9C1);
                character charD9C2 = new character(list[33], pronounList[33], 9);
                charList.Add(charD9C2);
                character charD9C3 = new character(list[34], pronounList[34], 9);
                charList.Add(charD9C3);
                character charD9C4 = new character(list[35], pronounList[35], 9);
                charList.Add(charD9C4);
                //District 10
                character charD10C1 = new character(list[36], pronounList[36], 10);
                charList.Add(charD10C1);
                character charD10C2 = new character(list[37], pronounList[37], 10);
                charList.Add(charD10C2);
                character charD10C3 = new character(list[38], pronounList[38], 10);
                charList.Add(charD10C3);
                character charD10C4 = new character(list[39], pronounList[39], 10);
                charList.Add(charD10C4);
                //District 11
                character charD11C1 = new character(list[40], pronounList[40], 11);
                charList.Add(charD11C1);
                character charD11C2 = new character(list[41], pronounList[41], 11);
                charList.Add(charD11C2);
                character charD11C3 = new character(list[42], pronounList[42], 11);
                charList.Add(charD11C3);
                character charD11C4 = new character(list[43], pronounList[43], 11);
                charList.Add(charD11C4);
                //District 12
                character charD12C1 = new character(list[44], pronounList[44], 12);
                charList.Add(charD12C1);
                character charD12C2 = new character(list[45], pronounList[45], 12);
                charList.Add(charD12C2);
                character charD12C3 = new character(list[46], pronounList[46], 12);
                charList.Add(charD12C3);
                character charD12C4 = new character(list[47], pronounList[47], 12);
                charList.Add(charD12C4);
            }
            else if (gameMode == "Realistic" && numPlayers == 48)
            {
                //instantiates all 48 characters and adds them to list
                //
                //District 1
                character charD1C1 = new character(list[0], pronounList[0], strengthList[0], moralList[0], speedList[0], 1);
                charList.Add(charD1C1);
                character charD1C2 = new character(list[1], pronounList[1], strengthList[1], moralList[1], speedList[1], 1);
                charList.Add(charD1C2);
                character charD1C3 = new character(list[2], pronounList[2], strengthList[2], moralList[2], speedList[2], 1);
                charList.Add(charD1C3);
                character charD1C4 = new character(list[3], pronounList[3], strengthList[3], moralList[3], speedList[3], 1);
                charList.Add(charD1C4);
                //District 2
                character charD2C1 = new character(list[4], pronounList[4], strengthList[4], moralList[4], speedList[4], 2);
                charList.Add(charD2C1);
                character charD2C2 = new character(list[5], pronounList[5], strengthList[5], moralList[5], speedList[5], 2);
                charList.Add(charD2C2);
                character charD2C3 = new character(list[6], pronounList[6], strengthList[6], moralList[6], speedList[6], 2);
                charList.Add(charD2C3);
                character charD2C4 = new character(list[7], pronounList[7], strengthList[7], moralList[7], speedList[7], 2);
                charList.Add(charD2C4);
                //District 3
                character charD3C1 = new character(list[8], pronounList[8], strengthList[8], moralList[8], speedList[8], 3);
                charList.Add(charD3C1);
                character charD3C2 = new character(list[9], pronounList[9], strengthList[9], moralList[9], speedList[9], 3);
                charList.Add(charD3C2);
                character charD3C3 = new character(list[10], pronounList[10], strengthList[10], moralList[10], speedList[10], 3);
                charList.Add(charD3C3);
                character charD3C4 = new character(list[11], pronounList[11], strengthList[11], moralList[11], speedList[11], 3);
                charList.Add(charD3C4);
                //District 4
                character charD4C1 = new character(list[12], pronounList[12], strengthList[12], moralList[12], speedList[12], 4);
                charList.Add(charD4C1);
                character charD4C2 = new character(list[13], pronounList[13], strengthList[13], moralList[13], speedList[13], 4);
                charList.Add(charD4C2);
                character charD4C3 = new character(list[14], pronounList[14], strengthList[14], moralList[14], speedList[14], 4);
                charList.Add(charD4C3);
                character charD4C4 = new character(list[15], pronounList[15], strengthList[15], moralList[15], speedList[15], 4);
                charList.Add(charD4C4);
                //District 5
                character charD5C1 = new character(list[16], pronounList[16], strengthList[16], moralList[16], speedList[16], 5);
                charList.Add(charD5C1);
                character charD5C2 = new character(list[17], pronounList[17], strengthList[17], moralList[17], speedList[17], 5);
                charList.Add(charD5C2);
                character charD5C3 = new character(list[18], pronounList[18], strengthList[18], moralList[18], speedList[18], 5);
                charList.Add(charD5C3);
                character charD5C4 = new character(list[19], pronounList[19], strengthList[19], moralList[19], speedList[19], 5);
                charList.Add(charD5C4);
                //District 6
                character charD6C1 = new character(list[20], pronounList[20], strengthList[20], moralList[20], speedList[20], 6);
                charList.Add(charD6C1);
                character charD6C2 = new character(list[21], pronounList[21], strengthList[21], moralList[21], speedList[21], 6);
                charList.Add(charD6C2);
                character charD6C3 = new character(list[22], pronounList[22], strengthList[22], moralList[22], speedList[22], 6);
                charList.Add(charD6C3);
                character charD6C4 = new character(list[23], pronounList[23], strengthList[23], moralList[23], speedList[23], 6);
                charList.Add(charD6C4);
                //District 7
                character charD7C1 = new character(list[24], pronounList[24], strengthList[24], moralList[24], speedList[24], 7);
                charList.Add(charD7C1);
                character charD7C2 = new character(list[25], pronounList[25], strengthList[25], moralList[25], speedList[25], 7);
                charList.Add(charD7C2);
                character charD7C3 = new character(list[26], pronounList[26], strengthList[26], moralList[26], speedList[26], 7);
                charList.Add(charD7C3);
                character charD7C4 = new character(list[27], pronounList[27], strengthList[27], moralList[27], speedList[27], 7);
                charList.Add(charD7C4);
                //District 8
                character charD8C1 = new character(list[28], pronounList[28], strengthList[28], moralList[28], speedList[28], 8);
                charList.Add(charD8C1);
                character charD8C2 = new character(list[29], pronounList[29], strengthList[29], moralList[29], speedList[29], 8);
                charList.Add(charD8C2);
                character charD8C3 = new character(list[30], pronounList[30], strengthList[30], moralList[30], speedList[30], 8);
                charList.Add(charD8C3);
                character charD8C4 = new character(list[31], pronounList[31], strengthList[31], moralList[31], speedList[31], 8);
                charList.Add(charD8C4);
                //District 9
                character charD9C1 = new character(list[32], pronounList[32], strengthList[32], moralList[32], speedList[32], 9);
                charList.Add(charD9C1);
                character charD9C2 = new character(list[33], pronounList[33], strengthList[33], moralList[33], speedList[33], 9);
                charList.Add(charD9C2);
                character charD9C3 = new character(list[34], pronounList[34], strengthList[34], moralList[34], speedList[34], 9);
                charList.Add(charD9C3);
                character charD9C4 = new character(list[35], pronounList[35], strengthList[35], moralList[35], speedList[35], 9);
                charList.Add(charD9C4);
                //District 10
                character charD10C1 = new character(list[36], pronounList[36], strengthList[36], moralList[36], speedList[36], 10);
                charList.Add(charD10C1);
                character charD10C2 = new character(list[37], pronounList[37], strengthList[37], moralList[37], speedList[37], 10);
                charList.Add(charD10C2);
                character charD10C3 = new character(list[38], pronounList[38], strengthList[38], moralList[38], speedList[38], 10);
                charList.Add(charD10C3);
                character charD10C4 = new character(list[39], pronounList[39], strengthList[39], moralList[39], speedList[39], 10);
                charList.Add(charD10C4);
                //District 11
                character charD11C1 = new character(list[40], pronounList[40], strengthList[40], moralList[40], speedList[40], 11);
                charList.Add(charD11C1);
                character charD11C2 = new character(list[41], pronounList[41], strengthList[41], moralList[41], speedList[41], 11);
                charList.Add(charD11C2);
                character charD11C3 = new character(list[42], pronounList[42], strengthList[42], moralList[42], speedList[42], 11);
                charList.Add(charD11C3);
                character charD11C4 = new character(list[43], pronounList[43], strengthList[43], moralList[43], speedList[43], 11);
                charList.Add(charD11C4);
                //District 12
                character charD12C1 = new character(list[44], pronounList[44], strengthList[44], moralList[44], speedList[44], 12);
                charList.Add(charD12C1);
                character charD12C2 = new character(list[45], pronounList[45], strengthList[45], moralList[45], speedList[45], 12);
                charList.Add(charD12C2);
                character charD12C3 = new character(list[46], pronounList[46], strengthList[46], moralList[46], speedList[46], 12);
                charList.Add(charD12C3);
                character charD12C4 = new character(list[47], pronounList[47], strengthList[47], moralList[47], speedList[47], 12);
                charList.Add(charD12C4);
            }

            return charList;
        }

    }
}