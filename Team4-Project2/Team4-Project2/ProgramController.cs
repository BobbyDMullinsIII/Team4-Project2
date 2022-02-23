///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Team4_Project2/Team4_Project2
//	File Name:         ProgramController.cs
//	Description:       ProgramController class for controlling majority of program functionality
//	Course:            CSCI-4717-201 - Comp Architecture
//	Authors:           Zachary Lykins, lykinsz@etsu.edu            
//	                   Bobby Mullins, mullinsbd@etsu.edu
//	                   Christopher Poteet, poteetc1@etsu.edu
//	                   William Simmons, simmonswa@etsu.edu
//                     Isaiah Jayne, jaynei@etsu.edu
//	Created:           Monday, February  14, 2022
//	Copyright:         Team 4
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team4_Project2
{
    /// <summary>
    ///  ProgramController class for controlling majority of program functionality
    /// </summary>
    public class ProgramController
    {
        public static GUIForm guiForm;    //MainForm instance to open program to

        #region startProgram() Method
        /// <summary>
        /// Method for starting program
        /// </summary>
        public static void startProgram()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Opens application to mainForm
            guiForm = new GUIForm();
            Application.Run(guiForm);

        }//end startProgram()
        #endregion

        #region assemble() Method
        /// <summary>
        /// Master Method for assembling custom assembly language instruction set into machine code
        /// </summary>        
        /// <param name="assemblyString">Input assembly code to assemble</param>
        /// <returns>Final assemble output (Machine Code)</returns>
        public static string assemble(string assemblyString)
        {
            string assembleOutput = "";

            string disassembledText = assemblyString;


            disassembledText = Regex.Replace(disassembledText, @"\d{4}[\t]*\s+", "");
            disassembledText = Regex.Replace(disassembledText, @"\s+", "");
            int numConverts = disassembledText.Count(f => f == '#');


            int wFlag = 0;
            int counter = 0;
            while (wFlag == 0)
            {
                Int32 macInstruct = 0;
                string instruction = string.Empty;
                instruction += disassembledText[counter];
                counter++;
                instruction += disassembledText[counter];
                counter++;
                instruction += disassembledText[counter];
                counter++;
                instruction += disassembledText[counter];
                counter++;
                switch (instruction)
                {
                    case string n when (n == "LDRE"):

                        counter += 3;
                        if (disassembledText[counter] == 'R')
                        {
                            macInstruct += 0;
                        }
                        else if (disassembledText[counter] == '#')
                        {
                            macInstruct += 8;
                        }
                        else
                        {
                            macInstruct += 16;
                        }

                        counter -= 3;
                        break;
                    case string n when (n == "STRE"):
                        macInstruct += 24;
                        break;
                    case string n when (n == "MOVE"):
                        macInstruct += 32;
                        break;
                    case string n when (n == "COMP"):
                        macInstruct += 40;
                        break;
                    case string n when (n == "ANDD"):
                        macInstruct += 48;
                        break;
                    case string n when (n == "OORR"):
                        macInstruct += 56;
                        break;
                    case string n when (n == "BRLT"):
                        macInstruct += 64;
                        break;
                    case string n when (n == "BRGT"):
                        macInstruct += 72;
                        break;
                    case string n when (n == "BREQ"):
                        macInstruct += 80;
                        break;
                    case string n when (n == "BRAN"):
                        macInstruct += 88;
                        break;
                    case string n when (n == "ADDI"):
                        macInstruct += 96;
                        break;
                    case string n when (n == "SUBT"):
                        macInstruct += 104;
                        break;
                    case string n when (n == "STOP"):
                        macInstruct += 255;
                        string hexValue = macInstruct.ToString("X2");
                        hexValue = hexValue.Insert(2, " ");
                        assembleOutput += hexValue;
                        wFlag = 1;
                        break;
                    default:
                        wFlag = 1;
                        MessageBox.Show("There was an invalid Mnemonic", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                }

                if (wFlag == 0)
                {
                    string register = "";
                    register += disassembledText[counter];
                    counter++;
                    register += disassembledText[counter];
                    counter++;
                    switch (register)
                    {
                        case string n when (n == "R0"):
                            macInstruct += 0;
                            break;
                        case string n when (n == "R1"):
                            macInstruct += 1;
                            break;
                        case string n when (n == "R2"):
                            macInstruct += 2;
                            break;
                        case string n when (n == "R3"):
                            macInstruct += 3;
                            break;
                        case string n when (n == "R4"):
                            macInstruct += 4;
                            break;
                        case string n when (n == "R5"):
                            macInstruct += 5;
                            break;
                        case string n when (n == "R6"):
                            macInstruct += 6;
                            break;
                        case string n when (n == "R7"):
                            macInstruct += 7;
                            break;

                    }
                    counter++;
                    string hexValue = macInstruct.ToString("X2");
                    hexValue = hexValue.Insert(2, " ");
                    assembleOutput += hexValue;
                    Int32 dataInstruct = 0;
                    string addressingMode = "";
                    addressingMode = Convert.ToString(disassembledText[counter]);
                    switch (addressingMode)
                    {
                        case string n when (n == "R"):
                            counter += 2;
                            if (disassembledText[counter] == 'R')
                            {
                                counter--;
                                counter--;
                                dataInstruct += 3;
                                switch (disassembledText[counter])
                                {
                                    case char i when (i == '0'):
                                        dataInstruct += 0;
                                        break;
                                    case char i when (i == '1'):
                                        dataInstruct += 2097152;
                                        break;
                                    case char i when (i == '2'):
                                        dataInstruct += 4194304;
                                        break;
                                    case char i when (i == '3'):
                                        dataInstruct += 6291456;
                                        break;
                                    case char i when (i == '4'):
                                        dataInstruct += 8388608;
                                        break;
                                    case char i when (i == '5'):
                                        dataInstruct += 10485760;
                                        break;
                                    case char i when (i == '6'):
                                        dataInstruct += 12582912;
                                        break;
                                    case char i when (i == '7'):
                                        dataInstruct += 14680064;
                                        break;

                                }
                                counter++;
                                counter++;
                                counter++;
                                switch (disassembledText[counter])
                                {
                                    case char i when (i == '0'):
                                        dataInstruct += 0;
                                        break;
                                    case char i when (i == '1'):
                                        dataInstruct += 262144;
                                        break;
                                    case char i when (i == '2'):
                                        dataInstruct += 524288;
                                        break;
                                    case char i when (i == '3'):
                                        dataInstruct += 786432;
                                        break;
                                    case char i when (i == '4'):
                                        dataInstruct += 1048576;
                                        break;
                                    case char i when (i == '5'):
                                        dataInstruct += 1310720;
                                        break;
                                    case char i when (i == '6'):
                                        dataInstruct += 1572864;
                                        break;
                                    case char i when (i == '7'):
                                        dataInstruct += 1835008;
                                        break;

                                }
                                counter--;
                            }
                            else
                            {
                                counter--;
                                dataInstruct += 0;
                                switch (disassembledText[counter])
                                {
                                    case char i when (i == '0'):
                                        dataInstruct += 0;
                                        break;
                                    case char i when (i == '1'):
                                        dataInstruct += 2097152;
                                        break;
                                    case char i when (i == '2'):
                                        dataInstruct += 4194304;
                                        break;
                                    case char i when (i == '3'):
                                        dataInstruct += 6291456;
                                        break;
                                    case char i when (i == '4'):
                                        dataInstruct += 8388608;
                                        break;
                                    case char i when (i == '5'):
                                        dataInstruct += 10485760;
                                        break;
                                    case char i when (i == '6'):
                                        dataInstruct += 12582912;
                                        break;
                                    case char i when (i == '7'):
                                        dataInstruct += 14680064;
                                        break;

                                }
                                counter++;

                            }
                            counter -= 2;
                            break;
                        case string n when (n == "#"):
                            dataInstruct += 1;
                            counter++;
                            string immediate = "";
                            int counter2 = 0;
                            while (Char.IsNumber(disassembledText, counter) == true)
                            {
                                immediate += disassembledText[counter];
                                counter++;
                                counter2++;
                            }
                            dataInstruct += Int32.Parse(immediate);
                            counter -= counter2;
                            counter--;
                            break;
                        case string n when (n == "&"):
                            dataInstruct += 2;
                            counter++;
                            string memory = "";
                            counter2 = 0;
                            while (Char.IsNumber(disassembledText, counter) == true)
                            {
                                memory += disassembledText[counter];
                                counter++;
                                counter2++;
                            }
                            dataInstruct += Int32.Parse(memory);
                            counter -= counter2;
                            counter--;
                            break;
                    }
                    hexValue = dataInstruct.ToString("X6");

                    hexValue = hexValue.Insert(2, " ");
                    hexValue = hexValue.Insert(5, " ");
                    hexValue = hexValue.Insert(8, " ");
                    assembleOutput += hexValue;
                }

                counter += 2;
            }

            return assembleOutput;
        }//end assemble()
        #endregion

        #region disassemble() Method
        /// <summary>
        /// Master Method for disassembling machine code into assembly
        /// </summary>
        /// <param name="machineString">Input machine code</param>
        /// <returns>Disassembled assembly code</returns>
        public static string disassemble(string machineString)
        {
            string disassembleOutput = "";

            Int32[] opTokens = new Int32[2];
            string[] machineCode = machineString.Split(' ');

            int wFlag = 0;
            int counter = 0;
            while (wFlag == 0)
            {
                string opcode = machineCode[counter];
                counter++;

                opTokens = ProgramController.disassembleTokens(opcode);
                string counterOutput = counter.ToString("D4");

                switch (opTokens[0])
                {
                    case Int32 n when (n == 0):     //  LDRE    R,R
                        disassembleOutput += counterOutput + "\tLDRE";
                        break;
                    case Int32 n when (n == 8):     //  LDRE    R, Immediate
                        disassembleOutput += counterOutput + "\tLDRE";
                        break;
                    case Int32 n when (n == 16):    //  LDRE    R, Memory
                        disassembleOutput += counterOutput + "\tLDRE";
                        break;
                    case Int32 n when (n == 24):    //  STRE    &R, R
                        disassembleOutput += counterOutput + "\tSTRE";
                        break;
                    case Int32 n when (n == 32):    //  MOVE    R, R
                        disassembleOutput += counterOutput + "\tMOVE";
                        break;
                    case Int32 n when (n == 40):    //  COMP    R, R, R
                        disassembleOutput += counterOutput + "\tCOMP";
                        break;
                    case Int32 n when (n == 48):    //  ANDD    R, R, R
                        disassembleOutput += counterOutput + "\tANDD";
                        break;
                    case Int32 n when (n == 56):    //  OORR    R, R
                        disassembleOutput += counterOutput + "\tOORR";
                        break;
                    case Int32 n when (n == 64):    //  BRLT    R, R
                        disassembleOutput += counterOutput + "\tBRLT";
                        break;
                    case Int32 n when (n == 72):    //  BRGT    R, R
                        disassembleOutput += counterOutput + "\tBRGT";
                        break;
                    case Int32 n when (n == 80):    //  BREQ    R, R
                        disassembleOutput += counterOutput + "\tBREQ";
                        break;
                    case Int32 n when (n == 88):    //  BRAN    R, R
                        disassembleOutput += counterOutput + "\tBRAN";
                        break;
                    case Int32 n when (n == 96):    //  ADDI    R, R, R
                        disassembleOutput += counterOutput + "\tADDI";
                        break;
                    case Int32 n when (n == 104):   //  SUBT    R, R, R
                        disassembleOutput += counterOutput + "\tSUBT";
                        break;
                    case Int32 n when (n == 248):   //  STOP 
                        disassembleOutput += counterOutput + "\tSTOP";
                        wFlag = 1;
                        break;
                    default:                        // Nothing matches invalid instruction
                        wFlag = 1;
                        disassembleOutput += counterOutput + "\tERROR: INVALID INSTRUCTION";
                        MessageBox.Show("There was an invalid machine code instruction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                if (wFlag == 0)
                {
                    switch (opTokens[1])
                    {
                        case Int32 n when (n == 0):     // R0
                            disassembleOutput += "   R0";
                            break;
                        case Int32 n when (n == 1):     // R1
                            disassembleOutput += "   R1";
                            break;
                        case Int32 n when (n == 2):     // R2
                            disassembleOutput += "   R2";
                            break;
                        case Int32 n when (n == 3):     // R3
                            disassembleOutput += "   R3";
                            break;
                        case Int32 n when (n == 4):     // R4
                            disassembleOutput += "   R4";
                            break;
                        case Int32 n when (n == 5):     // R5
                            disassembleOutput += "   R5";
                            break;
                        case Int32 n when (n == 6):     // R6
                            disassembleOutput += "   R6";
                            break;
                        case Int32 n when (n == 7):     // R7
                            disassembleOutput += "   R7";
                            break;
                    }

                    Int32[] dataTokens = new Int32[3];
                    string data = string.Empty;

                    data = machineCode[counter];
                    counter++;
                    data += machineCode[counter];
                    counter++;
                    data += machineCode[counter];
                    counter++;

                    dataTokens = ProgramController.disassembleData(data);
                    switch (dataTokens[0])
                    {
                        case Int32 n when (n == 0):
                            disassembleOutput += $", R{dataTokens[1] >> 21} \r\n";
                            break;
                        case Int32 n when (n == 1):
                            disassembleOutput += $", #{dataTokens[1] >> 6}\r\n";
                            break;
                        case Int32 n when (n == 2):
                            disassembleOutput += $", &{dataTokens[1] >> 2}\r\n";
                            break;
                        case Int32 n when (n == 3):
                            disassembleOutput += $", R{dataTokens[1] >> 21}";
                            disassembleOutput += $", R{dataTokens[2] >> 18} \r\n";
                            break;
                    }
                }
            }

            return disassembleOutput;
        }//end disassemble()
        #endregion

        #region disassembleTokens() Method
        /// <summary>
        /// Master Method for disassembling opcode into assembly
        /// </summary>
        /// <param name="opcodeString">Input machine code opcode</param>
        /// <returns>Opcode disassemble output</returns>
        public static Int32[] disassembleTokens(string opcodeString)
        {
            Int32[] tokens = new Int32[2];

            Int32 inp = Convert.ToInt32(opcodeString, 16);
            tokens[0] = (inp & 248);                            // AND with binary (11111000) to keep all 1 and get 5 bytes of opcode
            tokens[1] = (inp & 7);                              // AND  with binary (00000111) to keep all 1 and get 3 bytes for registers

            return tokens;

        }//end disassembleTokens()
        #endregion

        #region dissassembleData() Method
        /// <summary>
        /// Method for calculating tokens based on instruction parameters/registers
        /// </summary>
        /// <param name="machineString">Input machine code line after instruction to convert to tokens</param>
        /// <returns>Int32 token array from instruction parameters/registers</returns>
        public static Int32[] disassembleData(string machineString)
        {
            Int32[] tokens = new Int32[3];
            Int32 data = Convert.ToInt32(machineString, 16);
            tokens[0] = (data & 3);
            switch (tokens[0])
            {
                case Int32 n when (n == 0):
                    tokens[1] = (data & 14680064);
                    break;
                case Int32 n when (n == 1):
                    tokens[1] = (data & 16777152);
                    break;
                case Int32 n when (n == 2):
                    tokens[1] = (data & 16777212);
                    break;
                case Int32 n when (n == 3):
                    tokens[1] = (data & 14680064);
                    tokens[2] = (data & 1835008);
                    break;

            }
            return tokens;
        }
        #endregion

        #region openFile() Method
        /// <summary>
        /// Method for inputting an entire text file into one string
        /// </summary>
        /// <returns>Input string from entire text file</returns>
        public static string openFile()
        {
            OpenFileDialog fd = new OpenFileDialog();
            StreamReader reader;

            String Path;
            String FileContent = "";

            fd.InitialDirectory = "c:\\";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                Path = fd.FileName;

                var FileStream = fd.OpenFile();

                reader = new StreamReader(FileStream);

                FileContent = reader.ReadToEnd();

                return FileContent;
            }

            return FileContent;

        }//end openFile()
        #endregion

        #region saveFile() Method
        /// <summary>
        /// Method for outputting a text file from a string
        /// </summary>
        /// <param name="outputString">String to be output to a text file</param>
        public static void saveFile(string outputString)
        {
            SaveFileDialog sf = new SaveFileDialog();

            sf.ShowDialog();

            if (sf.FileName != "")
            {
                File.WriteAllText(sf.FileName, outputString);
            }

        }//end saveFile()
        #endregion

        #region openInformation() Method
        /// <summary>
        /// Method for opening instruction set information
        /// </summary>
        public static void openInformation()
        {
            //Get the current directory
            string filePath = Directory.GetCurrentDirectory();

            //Move up two parent directories
            filePath = Directory.GetParent(filePath).FullName;
            filePath = Directory.GetParent(filePath).FullName;

            filePath += "\\Files\\Information.txt";

            //Open the file located at filePath (which is InstructionSet.txt
            Process.Start(filePath);

        }//end openInformation()
        #endregion

    }//end ProgramController class

}//end Team4_Project2 namespace
