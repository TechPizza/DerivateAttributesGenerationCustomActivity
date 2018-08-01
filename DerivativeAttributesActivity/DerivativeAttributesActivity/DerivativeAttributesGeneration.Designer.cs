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
            this.updateResourceActivity1 = new Microsoft.ResourceManagement.Workflow.Activities.UpdateResourceActivity();
            this.InitializeUpdate = new System.Workflow.Activities.CodeActivity();
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
            // readResourceActivity1
            // 
            activitybind6.Name = "DerivativeAttributesGeneration";
            activitybind6.Path = "readResourceActivity1_ActorId1";
            this.readResourceActivity1.Name = "readResourceActivity1";
            activitybind7.Name = "DerivativeAttributesGeneration";
            activitybind7.Path = "readResourceActivity1_Resource1";
            activitybind8.Name = "DerivativeAttributesGeneration";
            activitybind8.Path = "readResourceActivity1_ResourceId1";
            activitybind9.Name = "DerivativeAttributesGeneration";
            activitybind9.Path = "readResourceActivity1_SelectionAttributes1";
            this.readResourceActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.ReadResourceActivity.ActorIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.readResourceActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.ReadResourceActivity.ResourceProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.readResourceActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.ReadResourceActivity.ResourceIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.readResourceActivity1.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.ReadResourceActivity.SelectionAttributesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            // 
            // InitializeReadSubject
            // 
            this.InitializeReadSubject.Name = "InitializeReadSubject";
            this.InitializeReadSubject.ExecuteCode += new System.EventHandler(this.InitiliazeReadSubject_ExecuteCode);
            // 
            // ReadCurrentRequestActivity
            // 
            activitybind10.Name = "DerivativeAttributesGeneration";
            activitybind10.Path = "currentRequestActivity1_CurrentRequest1";
            this.ReadCurrentRequestActivity.Name = "ReadCurrentRequestActivity";
            this.ReadCurrentRequestActivity.SetBinding(Microsoft.ResourceManagement.Workflow.Activities.CurrentRequestActivity.CurrentRequestProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            // 
            // DerivativeAttributesGeneration
            // 
            this.Activities.Add(this.ReadCurrentRequestActivity);
            this.Activities.Add(this.InitializeReadSubject);
            this.Activities.Add(this.readResourceActivity1);
            this.Activities.Add(this.InitializeUpdate);
            this.Activities.Add(this.updateResourceActivity1);
            this.Name = "DerivativeAttributesGeneration";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.ResourceManagement.Workflow.Activities.UpdateResourceActivity updateResourceActivity1;

        private CodeActivity InitializeUpdate;

        private Microsoft.ResourceManagement.Workflow.Activities.ReadResourceActivity readResourceActivity1;

        private CodeActivity InitializeReadSubject;

        private Microsoft.ResourceManagement.Workflow.Activities.CurrentRequestActivity ReadCurrentRequestActivity;







    }
}
