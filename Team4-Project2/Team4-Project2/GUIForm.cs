/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Team4_Project2/Team4_Project2
//	File Name:         GUIForm.cs
//	Description:       GUIForm class for program GUI to show visual static pipeline simulation
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team4_Project2
{
    public partial class GUIForm : Form
    {
        //Counter for cycles
        int cycleCounter = 0;

        //0 = not started,
        //1 = fetch phase
        //2 = decode phase
        //3 = execute phase
        //4 = store/finish phase
        int phaseCounterOne = 0;                              
        int phaseCounterTwo;
        int phaseCounterThree;
        int phaseCounterFour;
        int fStall, dStall, eStall, sStall =0;
        int progCount = 0;
        List<string> instructions = new List<string>();
        int programIndex = 0;
        int stallF = 0;
        List<Instruction> pipeFetch = new List<Instruction>();
        List<Instruction> pipeDecode = new List<Instruction>();
        List<Instruction> pipeExecute = new List<Instruction>();
        List<Instruction> pipeStore = new List<Instruction>();
        string instLit = string.Empty;
        int stopF = 0;



        public GUIForm()
        {
            InitializeComponent();
        }

        #region Dropdown Menu Buttons
        /// <summary>
        /// Opens instruction set information
        /// </summary>
        /// <param name="sender">object that raised the event (auto-generated, unused here)</param>
        /// <param name="e">arguments for event (auto-generated, unused here)</param>
        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramController.openInformation();
        }

        /// <summary>
        /// Exits program
        /// </summary>
        /// <param name="sender">object that raised the event (auto-generated, unused here)</param>
        /// <param name="e">arguments for event (auto-generated, unused here)</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramController.exitProgram();
        }
        #endregion

        #region Assembly TextBox Buttons
        /// <summary>
        /// Clears assembly language text box
        /// </summary>
        /// <param name="sender">object that raised the event (auto-generated, unused here)</param>
        /// <param name="e">arguments for event (auto-generated, unused here)</param>
        private void clearAssemblyButton_Click(object sender, EventArgs e)
        {
            assemblyTextBox.Text = "";
        }

        /// <summary>
        /// Loads content from file to assembly language text box
        /// </summary>
        /// <param name="sender">object that raised the event (auto-generated, unused here)</param>
        /// <param name="e">arguments for event (auto-generated, unused here)</param>
        private void loadAssemblyButton_Click(object sender, EventArgs e)
        {
            assemblyTextBox.Text = ProgramController.openFile();
        }

        /// <summary>
        /// Saves content inside of assembly language text box into a file
        /// </summary>
        /// <param name="sender">object that raised the event (auto-generated, unused here)</param>
        /// <param name="e">arguments for event (auto-generated, unused here)</param>
        private void saveAssemblyButton_Click(object sender, EventArgs e)
        {
            ProgramController.saveFile(assemblyTextBox.Text);
        }
        #endregion

        #region Pipeline TextBox Buttons
        /// <summary>
        /// Clears pipeline output text box
        /// </summary>
        /// <param name="sender">object that raised the event (auto-generated, unused here)</param>
        /// <param name="e">arguments for event (auto-generated, unused here)</param>
        private void clearPipelineOutputButton_Click(object sender, EventArgs e)
        {
            pipelineOutputTextBox.Text = "";
        }

        /// <summary>
        /// Loads content from file to pipeline output text box
        /// </summary>
        /// <param name="sender">object that raised the event (auto-generated, unused here)</param>
        /// <param name="e">arguments for event (auto-generated, unused here)</param>
        private void loadPipelineOutputButton_Click(object sender, EventArgs e)
        {
            pipelineOutputTextBox.Text = ProgramController.openFile();
        }

        /// <summary>
        /// Saves content inside of pipeline output text box into a file
        /// </summary>
        /// <param name="sender">object that raised the event (auto-generated, unused here)</param>
        /// <param name="e">arguments for event (auto-generated, unused here)</param>
        private void savePipelineOutputButton_Click(object sender, EventArgs e)
        {
            ProgramController.saveFile(pipelineOutputTextBox.Text);
        }
        #endregion

        #region Pipeline Simulation GUI Buttons
        /// <summary>
        /// Starts Static Pipeline Simulation
        /// </summary>
        /// <param name="sender">object that raised the event (auto-generated, unused here)</param>
        /// <param name="e">arguments for event (auto-generated, unused here)</param>
        private void startButton_Click(object sender, EventArgs e)
        {
            //If assemblyTextBox has no code in it, show error message
            if (String.IsNullOrWhiteSpace(assemblyTextBox.Text) == true)
            {
                MessageBox.Show("There is no assembly code to start the simulation.", 
                                "Error - No Code To Process", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
            //Else, start static pipeline simulation
            else
            {
                foreach (string var in assemblyTextBox.Text.Split())
                {
                    instructions.Add(var);
                }


                assemblyTextBox.ReadOnly = true;
                //Sets counter to 1, equal to fetch phase
                phaseCounterOne++;

                //Sets fetch phase label to red to signify we are in that phase
                fetchLabel.ForeColor = Color.Red;

                //Enables nextPhaseButton to be pressed when simulation has began and disables startButton
                nextCycleButton.Enabled = true;
                startButton.Enabled = false;
            }
        }

        /// <summary>
        /// Goes to next cycle within simulation
        /// </summary>
        /// <param name="sender">object that raised the event (auto-generated, unused here)</param>
        /// <param name="e">arguments for event (auto-generated, unused here)</param>
        private void nextCycleButton_Click(object sender, EventArgs e)
        {
            //Increase cycle counter by one
            incrementCycleCounter();

            if (pipeFetch.Count >= 1)
            {
                if (pipeFetch[0].Fetch == 0)
                {
                    if (pipeDecode.Count >= 3)
                    {
                        stallF = 1; 
                    }
                    else
                    {
                        stallF = 0;
                        pipeDecode.Add(pipeFetch[0]);
                        pipeFetch.RemoveAt(0);
                    }
                }
                if(pipeFetch.Count>=1)
                pipeFetch[0].Fetch--;                //decrement fetch counter for instruction at top of que
            }
            if (pipeDecode.Count >= 1)
            {         
                if (pipeDecode[0].Decode == 0)
                {
                    if (pipeExecute.Count >=3)
                    {
                        stallF = 1;
                    }
                    else 
                    {
                        stallF = 0;
                        pipeExecute.Add(pipeDecode[0]);
                        pipeDecode.RemoveAt(0);
                    }
                }
                if (pipeDecode.Count >= 1)
                    pipeDecode[0].Decode--;
            }
            if (pipeExecute.Count >= 1)
            {
                if (pipeExecute[0].Execute == 0)
                {
                    if (pipeStore.Count >= 3)
                    {
                        stallF = 1;
                    }
                    else
                    {
                        stallF = 0;
                        pipeStore.Add(pipeExecute[0]);
                        pipeExecute.RemoveAt(0);
                    }
                }
                if (pipeExecute.Count >= 1)
                    pipeExecute[0].Execute--;
            }
            if (pipeStore.Count >= 1)
            {
                
                if (pipeStore[0].Store == 0)
                {
                    pipeStore.RemoveAt(0);
                }
                if (pipeStore.Count >= 1)
                    pipeStore[0].Store--;
            }
            if (stopF == 0 && stallF == 0)
            {
                (pipeFetch, progCount, programIndex, stopF) = ProgramController.fetch(instructions, pipeFetch, progCount, programIndex);
            }
            if (pipeFetch.Count >= 1)
            {
                instructOneText.Text = pipeFetch[0].InstLit;
            }
            if (pipeDecode.Count >= 1)
            {
                decodeTextBox.Text = pipeDecode[0].InstLit;
            }
            if (pipeExecute.Count >= 1)
            {
                executeTextBox.Text = pipeExecute[0].InstLit;
            }
            if (pipeStore.Count>=1)
            {
                storeTextBox.Text = pipeStore[0].InstLit;
            }
            
        }
        #endregion

        private void pipelineOutputTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void assemblyTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        #region incrementCycleCounter() Method
        /// <summary>
        /// Method for incrementing cycle counter and updating gui to reflect it
        /// </summary>
        public void incrementCycleCounter()
        {
            cycleCounter++;
            counterTextBox.Text = cycleCounter.ToString();
            counterTextBox.SelectionAlignment = HorizontalAlignment.Center;

        }//end incrementCycleCounter()
        #endregion
    }
}
