using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Workflow.ComponentModel;
using Microsoft.IdentityManagement.WebUI.Controls;
using Microsoft.ResourceManagement.Workflow.Activities;
using FIM.DerivativeAttributesActivity;

namespace FIM.DerivativeAttributesActivity
{
    class DerivateAttributessGenerationActivitySettingsPart : ActivitySettingsPart
    {
        /// <summary>
        /// Called when a user clicks the Save button in the Workflow Designer. 
        /// Returns an instance of the RequestLoggingActivity class that 
        /// has its properties set to the values entered into the text box controls
        /// used in the UI of the activity. 
        /// </summary>
        public override Activity GenerateActivityOnWorkflow(SequentialWorkflow workflow)
        {
            if (!this.ValidateInputs())
            {
                return null;
            }
            DerivativeAttributesGeneration _calc = new DerivativeAttributesGeneration();
            _calc.UpnSuffix = this.GetText("_upnSuffix");
            // _calc.SetSource1 = this.GetText("_src");
            // _calc.SetDest1 = this.GetText("_dest");
            return _calc;
        }

        /// <summary>
        /// Called by FIM when the UI for the activity must be reloaded.
        /// It passes us an instance of our workflow activity so that we can
        /// extract the values of the properties to display in the UI.
        /// </summary>
        public override void LoadActivitySettings(Activity activity)
        {
            DerivativeAttributesGeneration _calc = activity as DerivativeAttributesGeneration;
            if (null != _calc)
            {
                this.SetText("_upnSuffix", (!string.IsNullOrEmpty(_calc.UpnSuffix)) ? _calc.UpnSuffix : this.GetText("_upnSuffix"));
                // this.SetText("_src", _calc.SetSource1);
                //this.SetText("_dest", _calc.SetDest1);
            }
        }

        /// <summary>
        /// Saves the activity settings.
        /// </summary>
        public override ActivitySettingsPartData PersistSettings()
        {
            ActivitySettingsPartData data = new ActivitySettingsPartData();
            data["_upnSuffix"] = this.GetText("_upnSuffix");
            // data["_src"] = this.GetText("_src");
            //data["_dest"] = this.GetText("_dest");
            return data;
        }

        /// <summary>
        ///  Restores the activity settings in the UI
        /// </summary>
        public override void RestoreSettings(ActivitySettingsPartData data)
        {
            if (null != data)
            {
                //    this.SetText("_src", (string)data["_src"]);
                this.SetText("_upnSuffix", (string)data["_upnSuffix"]);
            }
        }

        /// <summary>
        ///  Switches the activity between read only and read/write mode
        /// </summary>
        public override void SwitchMode(ActivitySettingsPartMode mode)
        {
            bool readOnly = (mode == ActivitySettingsPartMode.View);
            this.SetTextBoxReadOnlyOption("_upnSuffix", readOnly);
            //this.SetTextBoxReadOnlyOption("_dest", readOnly);
        }

        /// <summary>
        ///  Returns the activity name.
        /// </summary>
        public override string Title
        {
            get { return "Derivate Attributes Generation Activity"; }
        }

        /// <summary>
        ///  In general, this method should be used to validate information entered
        ///  by the user when the activity is added to a workflow in the Workflow
        ///  Designer.
        ///  We could add code to verify that the log file path already exists on
        ///  the server that is hosting the FIM Portal and check that the activity
        ///  has permission to write to that location. However, the code
        ///  would only check if the log file path exists when the
        ///  activity is added to a workflow in the workflow designer. This class
        ///  will not be used when the activity is actually run.
        ///  For this activity we will just return true.
        /// </summary>
        public override bool ValidateInputs()
        {
            return true;
        }


        /// <summary>
        ///  Creates a Table that contains the controls used by the activity UI
        ///  in the Workflow Designer of the FIM portal. Adds that Table to the
        ///  collection of Controls that defines each activity that can be selected
        ///  in the Workflow Designer of the FIM Portal. Calls the base class of 
        ///  ActivitySettingsPart to render the controls in the UI.
        /// </summary>
        protected override void CreateChildControls()
        {
            Table controlLayoutTable;
            controlLayoutTable = new Table();

            //Width is set to 100% of the control size
            controlLayoutTable.Width = Unit.Percentage(100.0);
            controlLayoutTable.BorderWidth = 0;
            controlLayoutTable.CellPadding = 2;
            //Add a TableRow for each textbox in the UI 
             controlLayoutTable.Rows.Add(this.AddTableRowTextBox("Upn Suffix:", "_upnSuffix", 400, 100, false, string.Empty));
            //controlLayoutTable.Rows.Add(this.AddTableRowTextBox("DestAttribute:", "_dest", 400, 100, false, "Enter the destination Attribute."));
            this.Controls.Add(controlLayoutTable);

            base.CreateChildControls();
        }

        #region Utility Functions
        //Create a TableRow that contains a label and a textbox.
        private TableRow AddTableRowTextBox(String labelText, String controlID, int width, int
                                             maxLength, Boolean multiLine, String defaultValue)
        {
            TableRow row = new TableRow();
            TableCell labelCell = new TableCell();
            TableCell controlCell = new TableCell();
            Label oLabel = new Label();
            TextBox oText = new TextBox();

            oLabel.Text = labelText;
            oLabel.CssClass = base.LabelCssClass;
            labelCell.Controls.Add(oLabel);
            oText.ID = controlID;
            oText.CssClass = base.TextBoxCssClass;
            oText.Text = defaultValue;
            oText.MaxLength = maxLength;
            oText.Width = width;
            if (multiLine)
            {
                oText.TextMode = TextBoxMode.MultiLine;
                oText.Rows = System.Math.Min(6, (maxLength + 60) / 60);
                oText.Wrap = true;
            }
            controlCell.Controls.Add(oText);
            row.Cells.Add(labelCell);
            row.Cells.Add(controlCell);
            return row;
        }

        string GetText(string textBoxID)
        {
            TextBox textBox = (TextBox)this.FindControl(textBoxID);
            return textBox.Text ?? String.Empty;
        }
        void SetText(string textBoxID, string text)
        {
            TextBox textBox = (TextBox)this.FindControl(textBoxID);
            if (textBox != null)
                textBox.Text = text;
            else
                textBox.Text = "";
        }

        //Set the text box to read mode or read/write mode
        void SetTextBoxReadOnlyOption(string textBoxID, bool readOnly)
        {
            TextBox textBox = (TextBox)this.FindControl(textBoxID);
            textBox.ReadOnly = readOnly;
        }
        #endregion
    }
}
