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
using System.Threading;

namespace FIM.DerivativeAttributesActivity
{
    public partial class DerivativeAttributesGeneration : SequenceActivity
    {
        private static object _lock = new object();

        private Guid requestorGUID;
        private Guid targetGUID;
        private string displayName;
        private string baseSamAccountName;
        private string samAccountName;
        private string baseUpn;
        private string upn;
        private string firstName;
        private string lastName;
        private string domain;
        private int countUpn;
        private int countSam;
        private Guid FIMADMGUID = new Guid("4074f258-a177-42df-b8ca-cba1a0cefb25");

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
        #region enumerateResource
        public static DependencyProperty enumerateResourcesActivity1_ActorId1Property = DependencyProperty.Register("enumerateResourcesActivity1_ActorId1", typeof(System.Guid), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public Guid enumerateResourcesActivity1_ActorId1
        {
            get
            {
                return ((System.Guid)(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity1_ActorId1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity1_ActorId1Property, value);
            }
        }

        public static DependencyProperty enumerateResourcesActivity1_PageSize1Property = DependencyProperty.Register("enumerateResourcesActivity1_PageSize1", typeof(System.Int32), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public Int32 enumerateResourcesActivity1_PageSize1
        {
            get
            {
                return ((int)(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity1_PageSize1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity1_PageSize1Property, value);
            }
        }

        public static DependencyProperty enumerateResourcesActivity1_Selection1Property = DependencyProperty.Register("enumerateResourcesActivity1_Selection1", typeof(System.String[]), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public String[] enumerateResourcesActivity1_Selection1
        {
            get
            {
                return ((string[])(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity1_Selection1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity1_Selection1Property, value);
            }
        }

        public static DependencyProperty enumerateResourcesActivity1_SortingAttributes1Property = DependencyProperty.Register("enumerateResourcesActivity1_SortingAttributes1", typeof(Microsoft.ResourceManagement.WebServices.WSEnumeration.SortingAttribute[]), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public Microsoft.ResourceManagement.WebServices.WSEnumeration.SortingAttribute[] enumerateResourcesActivity1_SortingAttributes1
        {
            get
            {
                return ((Microsoft.ResourceManagement.WebServices.WSEnumeration.SortingAttribute[])(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity1_SortingAttributes1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity1_SortingAttributes1Property, value);
            }
        }

        public static DependencyProperty enumerateResourcesActivity1_TotalResultsCount1Property = DependencyProperty.Register("enumerateResourcesActivity1_TotalResultsCount1", typeof(System.Int32), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public Int32 enumerateResourcesActivity1_TotalResultsCount1
        {
            get
            {
                return ((int)(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity1_TotalResultsCount1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity1_TotalResultsCount1Property, value);
            }
        }

        public static DependencyProperty enumerateResourcesActivity1_XPathFilter1Property = DependencyProperty.Register("enumerateResourcesActivity1_XPathFilter1", typeof(System.String), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public String enumerateResourcesActivity1_XPathFilter1
        {
            get
            {
                return ((string)(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity1_XPathFilter1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity1_XPathFilter1Property, value);
            }
        }
        #endregion
        #region EnumerateResource2
        public static DependencyProperty enumerateResourcesActivity2_ActorId1Property = DependencyProperty.Register("enumerateResourcesActivity2_ActorId1", typeof(System.Guid), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public Guid enumerateResourcesActivity2_ActorId1
        {
            get
            {
                return ((System.Guid)(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity2_ActorId1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity2_ActorId1Property, value);
            }
        }

        public static DependencyProperty enumerateResourcesActivity2_PageSize1Property = DependencyProperty.Register("enumerateResourcesActivity2_PageSize1", typeof(System.Int32), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public Int32 enumerateResourcesActivity2_PageSize1
        {
            get
            {
                return ((int)(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity2_PageSize1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity2_PageSize1Property, value);
            }
        }

        public static DependencyProperty enumerateResourcesActivity2_Selection1Property = DependencyProperty.Register("enumerateResourcesActivity2_Selection1", typeof(System.String[]), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public String[] enumerateResourcesActivity2_Selection1
        {
            get
            {
                return ((string[])(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity2_Selection1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity2_Selection1Property, value);
            }
        }

        public static DependencyProperty enumerateResourcesActivity2_SortingAttributes1Property = DependencyProperty.Register("enumerateResourcesActivity2_SortingAttributes1", typeof(Microsoft.ResourceManagement.WebServices.WSEnumeration.SortingAttribute[]), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public Microsoft.ResourceManagement.WebServices.WSEnumeration.SortingAttribute[] enumerateResourcesActivity2_SortingAttributes1
        {
            get
            {
                return ((Microsoft.ResourceManagement.WebServices.WSEnumeration.SortingAttribute[])(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity2_SortingAttributes1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity2_SortingAttributes1Property, value);
            }
        }

        public static DependencyProperty enumerateResourcesActivity2_TotalResultsCount1Property = DependencyProperty.Register("enumerateResourcesActivity2_TotalResultsCount1", typeof(System.Int32), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public Int32 enumerateResourcesActivity2_TotalResultsCount1
        {
            get
            {
                return ((int)(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity2_TotalResultsCount1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity2_TotalResultsCount1Property, value);
            }
        }

        public static DependencyProperty enumerateResourcesActivity2_XPathFilter1Property = DependencyProperty.Register("enumerateResourcesActivity2_XPathFilter1", typeof(System.String), typeof(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public String enumerateResourcesActivity2_XPathFilter1
        {
            get
            {
                return ((string)(base.GetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity2_XPathFilter1Property)));
            }
            set
            {
                base.SetValue(FIM.DerivativeAttributesActivity.DerivativeAttributesGeneration.enumerateResourcesActivity2_XPathFilter1Property, value);
            }
        }
        #endregion

        public DerivativeAttributesGeneration()
        {
            InitializeComponent();
        }

        private void MutexLock_ExecuteCode(object sender, EventArgs e)
        {
            Monitor.Enter(_lock);
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

            this.readResourceActivity1_ActorId1 = FIMADMGUID;
            this.readResourceActivity1_ResourceId1 = containingWorkflow.TargetId;

            requestorGUID = containingWorkflow.ActorId;
            targetGUID = containingWorkflow.TargetId;
        }

        private void LoopWhileUniqueUpn_ExecuteCode(object sender, ConditionalEventArgs e)
        {
            bool keepLooping = true;

            if (string.IsNullOrEmpty(baseUpn))
            {
                lastName = readResourceActivity1.Resource["LastName"].ToString();
                firstName = readResourceActivity1.Resource["FirstName"].ToString();
                domain = readResourceActivity1.Resource["Domain"].ToString();
                baseUpn = firstName.ToLower() + "." + lastName.ToLower();

                if (readResourceActivity1.Resource["labSource"].ToString() == "INTERNAL")
                    upn = baseUpn + "@" + domain;
                else
                    upn = baseUpn + ".ex@" + domain;
                countUpn = 1;
                this.enumerateResourcesActivity1_ActorId1 = FIMADMGUID;
                this.enumerateResourcesActivity1_PageSize1 = 100;
                this.enumerateResourcesActivity1_XPathFilter1 = "/Person[(labUpn='" + upn + "')]";
            }
            else if (enumerateResourcesActivity1_TotalResultsCount1 > 0)
            {
                if (readResourceActivity1.Resource["labSource"].ToString() == "INTERNAL")
                    upn = baseUpn + (++countUpn) + "@" + domain;
                else
                    upn = baseUpn + (++countUpn) + ".ex@" + domain;
                this.enumerateResourcesActivity1_ActorId1 = FIMADMGUID;
                this.enumerateResourcesActivity1_PageSize1 = 100;
                this.enumerateResourcesActivity1_XPathFilter1 = "/Person[(labUpn='" + upn + "')]";
            }
            else
            {
                keepLooping = false;
            }

            e.Result = keepLooping;
        }

        private void LoopWhileUnique_ExecuteCode(object sender, ConditionalEventArgs e)
        {
            bool keepLooping = true;

            if (string.IsNullOrEmpty(baseSamAccountName))
            {
                countSam = 1;
                if (readResourceActivity1.Resource["labSource"].ToString() == "INTERNAL")
                    baseSamAccountName = CalculateSamAccountName(lastName, firstName);
                else
                    baseSamAccountName = "X_" + CalculateSamAccountName(lastName, firstName);
                samAccountName = baseSamAccountName + countSam.ToString();
                this.enumerateResourcesActivity2_ActorId1 = FIMADMGUID;
                this.enumerateResourcesActivity2_PageSize1 = 100;
                this.enumerateResourcesActivity2_XPathFilter1 = "/Person[(LAB-samAccountName=" + samAccountName + ")]";
            }
            else if (enumerateResourcesActivity2_TotalResultsCount1 > 0)
            {
                samAccountName = baseSamAccountName + (++countSam);
                this.enumerateResourcesActivity2_ActorId1 = FIMADMGUID;
                this.enumerateResourcesActivity2_PageSize1 = 100;
                this.enumerateResourcesActivity2_XPathFilter1 = "/Person[(LAB-samAccountName=" + samAccountName + ")]";
            }
            else
            {
                keepLooping = false;
            }

            e.Result = keepLooping;
        }

        private void InitializeUpdate_ExecuteCode(object sender, EventArgs e)
        {
            if (readResourceActivity1.Resource["labSource"].ToString() == "INTERNAL")
            {
                if (countUpn <= 1)
                    displayName = firstName + " " + lastName;
                else
                    displayName = firstName + " " + lastName + countUpn.ToString();
            }
            else
            {
                if (countUpn <= 1)
                    displayName = firstName + " " + lastName + ",EX";
                else
                    displayName = firstName + " " + lastName + countUpn.ToString() + ",EX";
            }

            updateResourceActivity1_ActorId1 = requestorGUID;
            updateResourceActivity1_ResourceId1 = targetGUID;
            updateResourceActivity1.UpdateParameters = new UpdateRequestParameter[]{
                new UpdateRequestParameter("LAB-samAccountName",UpdateMode.Modify,samAccountName),
                new UpdateRequestParameter("DisplayName", UpdateMode.Modify, displayName),
                new UpdateRequestParameter("labUpn",UpdateMode.Modify,upn)
              };
        }

        private void MutexUnlock_ExecuteCode(object sender, EventArgs e)
        {
            Monitor.Exit(_lock);
        }

        private string CalculateSamAccountName(string lastName, string firstName)
        {
            return (lastName.Length > 5 ? lastName.ToLower().Substring(0, 5) : lastName.ToLower()) + firstName.ToLower().Substring(0, 2);
        }
    }
}
