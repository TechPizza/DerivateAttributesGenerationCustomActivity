using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Linq;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using Microsoft.ResourceManagement.WebServices.WSResourceManagement;
using Microsoft.ResourceManagement.Workflow.Activities;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.DirectoryServices;
using System.Text.RegularExpressions;
using System.Globalization;

namespace FIM.DerivativeAttributesActivity
{
    public partial class DerivativeAttributesGeneration : SequenceActivity
    {
        private Guid requestorGUID;
        private Guid targetGUID;
        private string displayName;
        private string samAccountName;
        private string upn;
        const string FIMADMGUID = "4074f258-a177-42df-b8ca-cba1a0cefb25";

        #region ReadCurrentRequest
        public static DependencyProperty currentRequestActivity1_CurrentRequest1Property = DependencyProperty.Register
            ("currentRequestActivity1_CurrentRequest1", typeof(Microsoft.ResourceManagement.WebServices.WSResourceManagement.RequestType),
            typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public Microsoft.ResourceManagement.WebServices.WSResourceManagement.RequestType currentRequestActivity1_CurrentRequest1
        {
            get
            {
                return ((Microsoft.ResourceManagement.WebServices.WSResourceManagement.RequestType)(base.GetValue
                    (FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.currentRequestActivity1_CurrentRequest1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.currentRequestActivity1_CurrentRequest1Property, value);
            }
        }
        #endregion
        #region ReadResourceActivity
        public static DependencyProperty readResourceActivity1_ActorId1Property = DependencyProperty.Register("readResourceActivity1_ActorId1", typeof(System.Guid), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public Guid readResourceActivity1_ActorId1
        {
            get
            {
                return ((System.Guid)(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.readResourceActivity1_ActorId1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.readResourceActivity1_ActorId1Property, value);
            }
        }

        public static DependencyProperty readResourceActivity1_Resource1Property = DependencyProperty.Register("readResourceActivity1_Resource1", typeof(Microsoft.ResourceManagement.WebServices.WSResourceManagement.ResourceType), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public ResourceType readResourceActivity1_Resource1
        {
            get
            {
                return ((Microsoft.ResourceManagement.WebServices.WSResourceManagement.ResourceType)(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.readResourceActivity1_Resource1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.readResourceActivity1_Resource1Property, value);
            }
        }

        public static DependencyProperty readResourceActivity1_ResourceId1Property = DependencyProperty.Register("readResourceActivity1_ResourceId1", typeof(System.Guid), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public Guid readResourceActivity1_ResourceId1
        {
            get
            {
                return ((System.Guid)(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.readResourceActivity1_ResourceId1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.readResourceActivity1_ResourceId1Property, value);
            }
        }

        public static DependencyProperty readResourceActivity1_SelectionAttributes1Property = DependencyProperty.Register("readResourceActivity1_SelectionAttributes1", typeof(System.String[]), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public String[] readResourceActivity1_SelectionAttributes1
        {
            get
            {
                return ((string[])(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.readResourceActivity1_SelectionAttributes1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.readResourceActivity1_SelectionAttributes1Property, value);
            }
        }
        #endregion
        #region UpdateResource
        public static DependencyProperty updateResourceActivity1_ActorId1Property = DependencyProperty.Register("updateResourceActivity1_ActorId1", typeof(System.Guid), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public Guid updateResourceActivity1_ActorId1
        {
            get
            {
                return ((System.Guid)(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.updateResourceActivity1_ActorId1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.updateResourceActivity1_ActorId1Property, value);
            }
        }

        public static DependencyProperty updateResourceActivity1_ApplyAuthorizationPolicy1Property = DependencyProperty.Register("updateResourceActivity1_ApplyAuthorizationPolicy1", typeof(System.Boolean), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public Boolean updateResourceActivity1_ApplyAuthorizationPolicy1
        {
            get
            {
                return ((bool)(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.updateResourceActivity1_ApplyAuthorizationPolicy1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.updateResourceActivity1_ApplyAuthorizationPolicy1Property, value);
            }
        }

        public static DependencyProperty updateResourceActivity1_ResourceId1Property = DependencyProperty.Register("updateResourceActivity1_ResourceId1", typeof(System.Guid), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public Guid updateResourceActivity1_ResourceId1
        {
            get
            {
                return ((System.Guid)(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.updateResourceActivity1_ResourceId1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.updateResourceActivity1_ResourceId1Property, value);
            }
        }

        public static DependencyProperty updateResourceActivity1_UpdateParameters1Property = DependencyProperty.Register("updateResourceActivity1_UpdateParameters1", typeof(Microsoft.ResourceManagement.WebServices.WSResourceManagement.UpdateRequestParameter[]), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public UpdateRequestParameter[] updateResourceActivity1_UpdateParameters1
        {
            get
            {
                return ((Microsoft.ResourceManagement.WebServices.WSResourceManagement.UpdateRequestParameter[])(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.updateResourceActivity1_UpdateParameters1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.updateResourceActivity1_UpdateParameters1Property, value);
            }
        }

        public static DependencyProperty updateResourceActivity1_AuthorizationWaitTimeInSeconds1Property = DependencyProperty.Register("updateResourceActivity1_AuthorizationWaitTimeInSeconds1", typeof(System.Int32), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public Int32 updateResourceActivity1_AuthorizationWaitTimeInSeconds1
        {
            get
            {
                return ((int)(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.updateResourceActivity1_AuthorizationWaitTimeInSeconds1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.updateResourceActivity1_AuthorizationWaitTimeInSeconds1Property, value);
            }
        }
        #endregion


        public DerivativeAttributesGeneration()
        {
            InitializeComponent();
        }

        private void InitiliazeReadSubject_ExecuteCode(object sender, EventArgs e)
        {
            RequestType currentRequest = this.ReadCurrentRequestActivity.CurrentRequest;
            ReadOnlyCollection<CreateRequestParameter> requestParameters = currentRequest.ParseParameters<CreateRequestParameter>();

            SequentialWorkflow containingWorkflow = null;
            if (!SequentialWorkflow.TryGetContainingWorkflow(this, out containingWorkflow))
            {
                throw new InvalidOperationException("Unable to get Containing Workflow");
            }

            this.readResourceActivity1_ActorId1 = new Guid(FIMADMGUID);
            this.readResourceActivity1_ResourceId1 = containingWorkflow.TargetId;
 
            requestorGUID = containingWorkflow.ActorId;
            targetGUID = containingWorkflow.TargetId;
        }

        private void InitializeUpdate_ExecuteCode(object sender, EventArgs e)
        {
            //displayName = readResourceActivity1_Resource1["firstName"] + " " + readResourceActivity1_Resource1["lastName"];
            string lastName = readResourceActivity1.Resource["LastName"].ToString();
            string firstName = readResourceActivity1.Resource["FirstName"].ToString();
            string domain = readResourceActivity1.Resource["Domain"].ToString();

            displayName = firstName + " " + lastName;
            updateResourceActivity1_ActorId1 = requestorGUID;
            updateResourceActivity1_ResourceId1 = targetGUID;

            //Upn
            upn = firstName + "." + lastName + "1@" + domain;

            //samAccountName 
            samAccountName = (lastName.Length > 5 ? lastName.ToLower().Substring(0, 5) : lastName) + firstName.ToLower().Substring(0,2) +"1";
            updateResourceActivity1.UpdateParameters = new UpdateRequestParameter[]{
                new UpdateRequestParameter("LAB-samAccountName",UpdateMode.Modify,samAccountName),
                new UpdateRequestParameter("DisplayName", UpdateMode.Modify, displayName),
                new UpdateRequestParameter("labUpn",UpdateMode.Modify,upn)
              };
        }
    }
}
