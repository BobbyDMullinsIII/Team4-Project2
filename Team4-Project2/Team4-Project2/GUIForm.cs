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
        int phaseCounter = 0;   //0 = not started,
                                //1 = fetch phase
                                //2 = decode phase
                                //3 = execute phase
                                //4 = store/finish phase

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
                string instructionsText = assemblyTextBox.Text;
                String[] instructions = instructionsText.Split();
                



                //Sets counter to 1, equal to fetch phase
                phaseCounter++;

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
            //==========================================================//
            //Currently, each phase is only 1 clock cycle, but will need//
            //to be changed depending on what instruction and registers //
            //==========================================================//

            //If phaseCounter is not on final phase, count up to next phase
            if (phaseCounter < 4)
            {
                phaseCounter++;
            }
            //Else, restart to go to first phase for next instruction
            else
            {
                phaseCounter = 1;
            }

            string placeholder = "";
            string fetchOutput = "";
            string decodeOutput = "";
            string executeOutput = "";
            string storeOutput = "";
            string instructionsText = assemblyTextBox.Text;
            String[] instructions = instructionsText.Split();
            int i = 0;
            switch (instructions[i])
            {
                case string n when (n == "LDRE"):
                    break;
                case string n when (n == "STRE"):
                    break;
                case string n when (n == "COMP"):
                    break;
                case string n when (n == "ANDD"):
                    break;
                case string n when (n == "OORR"):
                    break;
                case string n when (n == "BRLT"):
                    break;
                case string n when (n == "BRGT"):
                    break;
                case string n when (n == "BREQ"):
                    break;
                case string n when (n == "BRAN"):
                    break;
                case string n when (n == "ADDI"):
                    break;
                case string n when (n == "SUBT"):
                    break;
                case string n when (n == "FADD"):
                    break;
                case string n when (n == "FSUB"):
                    break;
                case string n when (n == "FMUL"):
                    break;
                case string n when (n == "FDIV"):
                    break;
                case string n when (n == "NOOP"):
                    break;
                case string n when (n == "STOP"):

                 
                    break;
            }

            //Switch selects which phase we are in currently
            switch (phaseCounter)
            {
                //Fetch phase
                case 1:
                    resetPhaseLabelColors();
                    fetchLabel.ForeColor = Color.Red;
                    ProgramController.fetch(placeholder);
                    break;

                //Decode phase
                case 2:
                    resetPhaseLabelColors();
                    decodeLabel.ForeColor = Color.Red;
                    ProgramController.decode(placeholder);
                    break;

                //Execute phase
                case 3:
                    resetPhaseLabelColors();
                    executeLabel.ForeColor = Color.Red;
                    ProgramController.execute(placeholder);
                    break;

                //Store/Finish phase
                case 4:
                    resetPhaseLabelColors();
                    storeLabel.ForeColor = Color.Red;
                    ProgramController.store(placeholder);
                    break;

                default:
                    //Do nothing (might insert code here in future)
                    break;
            }
        }
        #endregion

        #region resetPhaseLabelColors() Method
        /// <summary>
        /// Method for resetting all phase label colors on the form
        /// </summary>
        private void resetPhaseLabelColors()
        {
            fetchLabel.ForeColor = Color.White;
            decodeLabel.ForeColor = Color.White;
            executeLabel.ForeColor = Color.White;
            storeLabel.ForeColor = Color.White;

        }//end resetLabelColors()
        #endregion

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pipelineOutputTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void assemblyTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
