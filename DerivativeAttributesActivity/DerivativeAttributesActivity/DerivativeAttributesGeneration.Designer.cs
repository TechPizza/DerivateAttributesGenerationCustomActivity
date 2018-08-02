using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Reflection;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace FIM.DerivativeAttributesActivity
{
    public partial class DerivativeAttributesGeneration
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("", "")]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind11 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind13 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind14 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind15 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind16 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind17 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind18 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind19 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind20 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind21 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind22 = new System.Workflow.ComponentModel.ActivityBind();
            this.updateResourceActivity1 = new Microsoft.ResourceManagement.Workflow.Activities.UpdateResourceActivity();
            this.InitializeUpdate = new System.Workflow.Activities.CodeActivity();
            this.enumerateResourcesActivity2 = new Microsoft.ResourceManagement.Workflow.Activities.EnumerateResourcesActivity();
            this.InitializeSamEnumerateActivity = new System.Workflow.Activities.CodeActivity();
            this.enumerateResourcesActivity1 = new Microsoft.ResourceManagement.Workflow.Activities.EnumerateResourcesActivity();
            this.InitializeUpnEnumerateActivity = new System.Workflow.Activities.CodeActivity();
            this.readResourceActivity1 = new Microsoft.ResourceManagement.Workflow.Activities.ReadResourceActivity();
            this.InitializeReadSubject = new System.Workflow.Activities.CodeActivity();
            this.ReadCurrentRequestActivity = new Microsoft.ResourceManagement.Workflow.Activities.CurrentRequestActivity();
            // 
            // updateResourceActivity1
            // 
            activitybind1.Name = "DerivativeAttributesGeneration";
            activitybind1.Path = "updateResourceActivity1_ActorId1";
            activitybind2.Name = "DerivativeAttributesGeneration";
            activitybind2.Path = "updateResourceActivity1_ApplyAuthorizationPolicy1";
            activitybind3.Name = "DerivativeAttributesGeneration";
            activitybind3.Path = "updateResourceActivity1_AuthorizationWaitTimeInSeconds1";
            this.updateResourceActivity1.Name = "updateResourceActivity1";
            activitybind4.Name = "DerivativeAttributesGeneration";
            activitybind4.Path = "updateResourceActivity1_ResourceId1";
            activitybind5.Name = "DerivativeAttributesGeneration";
            activitybind5.Path = "updateResourceActivity1_UpdateParameters1";
            this.updateResourceActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.UpdateResourceActivity.ActorIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.updateResourceActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.UpdateResourceActivity.ApplyAuthorizationPolicyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.updateResourceActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.UpdateResourceActivity.ResourceIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.updateResourceActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.UpdateResourceActivity.UpdateParametersProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.updateResourceActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.UpdateResourceActivity.AuthorizationWaitTimeInSecondsProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // InitializeUpdate
            // 
            this.InitializeUpdate.Name = "InitializeUpdate";
            this.InitializeUpdate.ExecuteCode += new System.EventHandler(this.InitializeUpdate_ExecuteCode);
            // 
            // enumerateResourcesActivity2
            // 
            activitybind6.Name = "DerivativeAttributesGeneration";
            activitybind6.Path = "enumerateResourcesActivity2_ActorId1";
            this.enumerateResourcesActivity2.Name = "enumerateResourcesActivity2";
            activitybind7.Name = "DerivativeAttributesGeneration";
            activitybind7.Path = "enumerateResourcesActivity2_PageSize1";
            activitybind8.Name = "DerivativeAttributesGeneration";
            activitybind8.Path = "enumerateResourcesActivity2_Selection1";
            activitybind9.Name = "DerivativeAttributesGeneration";
            activitybind9.Path = "enumerateResourcesActivity2_SortingAttributes1";
            activitybind10.Name = "DerivativeAttributesGeneration";
            activitybind10.Path = "enumerateResourcesActivity2_TotalResultsCount1";
            activitybind11.Name = "DerivativeAttributesGeneration";
            activitybind11.Path = "enumerateResourcesActivity2_XPathFilter1";
            this.enumerateResourcesActivity2.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.EnumerateResourcesActivity.ActorIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.enumerateResourcesActivity2.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.EnumerateResourcesActivity.PageSizeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.enumerateResourcesActivity2.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.EnumerateResourcesActivity.SelectionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.enumerateResourcesActivity2.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.EnumerateResourcesActivity.SortingAttributesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            this.enumerateResourcesActivity2.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.EnumerateResourcesActivity.TotalResultsCountProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            this.enumerateResourcesActivity2.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.EnumerateResourcesActivity.XPathFilterProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            // 
            // InitializeSamEnumerateActivity
            // 
            this.InitializeSamEnumerateActivity.Name = "InitializeSamEnumerateActivity";
            this.InitializeSamEnumerateActivity.ExecuteCode += new System.EventHandler(this.InitializeSamEnumerateActivity_ExecuteCode);
            // 
            // enumerateResourcesActivity1
            // 
            activitybind12.Name = "DerivativeAttributesGeneration";
            activitybind12.Path = "enumerateResourcesActivity1_ActorId1";
            this.enumerateResourcesActivity1.Name = "enumerateResourcesActivity1";
            activitybind13.Name = "DerivativeAttributesGeneration";
            activitybind13.Path = "enumerateResourcesActivity1_PageSize1";
            activitybind14.Name = "DerivativeAttributesGeneration";
            activitybind14.Path = "enumerateResourcesActivity1_Selection1";
            activitybind15.Name = "DerivativeAttributesGeneration";
            activitybind15.Path = "enumerateResourcesActivity1_SortingAttributes1";
            activitybind16.Name = "DerivativeAttributesGeneration";
            activitybind16.Path = "enumerateResourcesActivity1_TotalResultsCount1";
            activitybind17.Name = "DerivativeAttributesGeneration";
            activitybind17.Path = "enumerateResourcesActivity1_XPathFilter1";
            this.enumerateResourcesActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.EnumerateResourcesActivity.ActorIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            this.enumerateResourcesActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.EnumerateResourcesActivity.PageSizeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            this.enumerateResourcesActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.EnumerateResourcesActivity.SelectionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            this.enumerateResourcesActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.EnumerateResourcesActivity.SortingAttributesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            this.enumerateResourcesActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.EnumerateResourcesActivity.TotalResultsCountProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            this.enumerateResourcesActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.EnumerateResourcesActivity.XPathFilterProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            // 
            // InitializeUpnEnumerateActivity
            // 
            this.InitializeUpnEnumerateActivity.Name = "InitializeUpnEnumerateActivity";
            this.InitializeUpnEnumerateActivity.ExecuteCode += new System.EventHandler(this.InitializeUpnEnumerateActivity_ExecuteCode);
            // 
            // readResourceActivity1
            // 
            activitybind18.Name = "DerivativeAttributesGeneration";
            activitybind18.Path = "readResourceActivity1_ActorId1";
            this.readResourceActivity1.Name = "readResourceActivity1";
            activitybind19.Name = "DerivativeAttributesGeneration";
            activitybind19.Path = "readResourceActivity1_Resource1";
            activitybind20.Name = "DerivativeAttributesGeneration";
            activitybind20.Path = "readResourceActivity1_ResourceId1";
            activitybind21.Name = "DerivativeAttributesGeneration";
            activitybind21.Path = "readResourceActivity1_SelectionAttributes1";
            this.readResourceActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.ReadResourceActivity.ActorIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind18)));
            this.readResourceActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.ReadResourceActivity.ResourceProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind19)));
            this.readResourceActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.ReadResourceActivity.ResourceIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind20)));
            this.readResourceActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.ReadResourceActivity.SelectionAttributesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind21)));
            // 
            // InitializeReadSubject
            // 
            this.InitializeReadSubject.Name = "InitializeReadSubject";
            this.InitializeReadSubject.ExecuteCode += new System.EventHandler(this.InitiliazeReadSubject_ExecuteCode);
            // 
            // ReadCurrentRequestActivity
            // 
            activitybind22.Name = "DerivativeAttributesGeneration";
            activitybind22.Path = "currentRequestActivity1_CurrentRequest1";
            this.ReadCurrentRequestActivity.Name = "ReadCurrentRequestActivity";
            this.ReadCurrentRequestActivity.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.CurrentRequestActivity.CurrentRequestProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind22)));
            // 
            // DerivativeAttributesGeneration
            // 
            this.Activities.Add(this.ReadCurrentRequestActivity);
            this.Activities.Add(this.InitializeReadSubject);
            this.Activities.Add(this.readResourceActivity1);
            this.Activities.Add(this.InitializeUpnEnumerateActivity);
            this.Activities.Add(this.enumerateResourcesActivity1);
            this.Activities.Add(this.InitializeSamEnumerateActivity);
            this.Activities.Add(this.enumerateResourcesActivity2);
            this.Activities.Add(this.InitializeUpdate);
            this.Activities.Add(this.updateResourceActivity1);
            this.Name = "DerivativeAttributesGeneration";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.ResourceManagement.Workflow.Activities.EnumerateResourcesActivity enumerateResourcesActivity2;

        private CodeActivity InitializeSamEnumerateActivity;

        private CodeActivity InitializeUpnEnumerateActivity;

        private Microsoft.ResourceManagement.Workflow.Activities.EnumerateResourcesActivity enumerateResourcesActivity1;

        private Microsoft.ResourceManagement.Workflow.Activities.UpdateResourceActivity updateResourceActivity1;

        private CodeActivity InitializeUpdate;

        private Microsoft.ResourceManagement.Workflow.Activities.ReadResourceActivity readResourceActivity1;

        private CodeActivity InitializeReadSubject;

        private Microsoft.ResourceManagement.Workflow.Activities.CurrentRequestActivity ReadCurrentRequestActivity;















    }
}
