﻿#pragma checksum "..\..\..\..\Pages\SeeObject\SeeDriverPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "67B2EA087E9B3C66C30D458E21AB2BA13A19CB6F20637CA8B2A0AB2793A9D3E4"
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
using TrafficPoliceProject.Pages.SeeObject;


namespace TrafficPoliceProject.Pages.SeeObject {
    
    
    /// <summary>
    /// SeeDriverPage
    /// </summary>
    public partial class SeeDriverPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 35 "..\..\..\..\Pages\SeeObject\SeeDriverPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Search;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Pages\SeeObject\SeeDriverPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchDataTB;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Pages\SeeObject\SeeDriverPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListDrivers;
        
        #line default
        #line hidden
        
        
        #line 225 "..\..\..\..\Pages\SeeObject\SeeDriverPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/TrafficPoliceProject;component/pages/seeobject/seedriverpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\SeeObject\SeeDriverPage.xaml"
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
            
            #line 10 "..\..\..\..\Pages\SeeObject\SeeDriverPage.xaml"
            ((TrafficPoliceProject.Pages.SeeObject.SeeDriverPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Search = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.SearchDataTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\..\Pages\SeeObject\SeeDriverPage.xaml"
            this.SearchDataTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchDataTB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ListDrivers = ((System.Windows.Controls.ListView)(target));
            
            #line 55 "..\..\..\..\Pages\SeeObject\SeeDriverPage.xaml"
            this.ListDrivers.KeyDown += new System.Windows.Input.KeyEventHandler(this.ListDrivers_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 229 "..\..\..\..\Pages\SeeObject\SeeDriverPage.xaml"
            this.AddBtn.Click += new System.Windows.RoutedEventHandler(this.AddBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 5:
            
            #line 215 "..\..\..\..\Pages\SeeObject\SeeDriverPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnEdit_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

