﻿#pragma checksum "..\..\..\..\Pages\AddAndEditPages\AddAndEditLicencePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0DA4C7534CADF1347170940398B8D161065835107496805D7FB28CE1B521CFA7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TrafficPoliceProject.Pages.AddAndEditPages;


namespace TrafficPoliceProject.Pages.AddAndEditPages {
    
    
    /// <summary>
    /// AddAndEditLicencePage
    /// </summary>
    public partial class AddAndEditLicencePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\..\Pages\AddAndEditPages\AddAndEditLicencePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.DatePickerTextBox dateTB;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Pages\AddAndEditPages\AddAndEditLicencePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox serial;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Pages\AddAndEditPages\AddAndEditLicencePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GenerateSerial;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\Pages\AddAndEditPages\AddAndEditLicencePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox number;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\..\Pages\AddAndEditPages\AddAndEditLicencePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GenerateNumber;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\Pages\AddAndEditPages\AddAndEditLicencePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveData;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TrafficPoliceProject;component/pages/addandeditpages/addandeditlicencepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\AddAndEditPages\AddAndEditLicencePage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dateTB = ((System.Windows.Controls.Primitives.DatePickerTextBox)(target));
            return;
            case 2:
            this.serial = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.GenerateSerial = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\..\Pages\AddAndEditPages\AddAndEditLicencePage.xaml"
            this.GenerateSerial.Click += new System.Windows.RoutedEventHandler(this.GenerateSerial_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.number = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.GenerateNumber = ((System.Windows.Controls.Button)(target));
            
            #line 116 "..\..\..\..\Pages\AddAndEditPages\AddAndEditLicencePage.xaml"
            this.GenerateNumber.Click += new System.Windows.RoutedEventHandler(this.GenerateNumber_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SaveData = ((System.Windows.Controls.Button)(target));
            
            #line 128 "..\..\..\..\Pages\AddAndEditPages\AddAndEditLicencePage.xaml"
            this.SaveData.Click += new System.Windows.RoutedEventHandler(this.SaveData_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

