﻿#pragma checksum "..\..\..\AnaMenu_.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51BD92915FF1A22160FBF322DC7768EF77E2FC78"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ClientWPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ClientWPF {
    
    
    /// <summary>
    /// AnaMenu_
    /// </summary>
    public partial class AnaMenu_ : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\AnaMenu_.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ClientWPF.AnaMenu_ anamenu;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\AnaMenu_.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdAnaMenu;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\AnaMenu_.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnparacekme;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\AnaMenu_.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btniade;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\AnaMenu_.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnparayatırma;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\AnaMenu_.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnbakiye;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ClientWPF;component/anamenu_.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AnaMenu_.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.anamenu = ((ClientWPF.AnaMenu_)(target));
            return;
            case 2:
            this.grdAnaMenu = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.btnparacekme = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\AnaMenu_.xaml"
            this.btnparacekme.Click += new System.Windows.RoutedEventHandler(this.btnparacekme_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btniade = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\AnaMenu_.xaml"
            this.btniade.Click += new System.Windows.RoutedEventHandler(this.btniade_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnparayatırma = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\AnaMenu_.xaml"
            this.btnparayatırma.Click += new System.Windows.RoutedEventHandler(this.btnparayatırma_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnbakiye = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\AnaMenu_.xaml"
            this.btnbakiye.Click += new System.Windows.RoutedEventHandler(this.btnbakiye_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

