﻿#pragma checksum "..\..\..\BakiyeGosterme.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ACAAAC4FDAD80F846F738861D7BADD6D5492365"
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
    /// BakiyeGosterme
    /// </summary>
    public partial class BakiyeGosterme : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\BakiyeGosterme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridBakiye;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\BakiyeGosterme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblbakiye;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\BakiyeGosterme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnKartiade;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\BakiyeGosterme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAnaMenu;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ClientWPF;V1.0.0.0;component/bakiyegosterme.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\BakiyeGosterme.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GridBakiye = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.lblbakiye = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btnKartiade = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\BakiyeGosterme.xaml"
            this.btnKartiade.Click += new System.Windows.RoutedEventHandler(this.btnKartiade_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAnaMenu = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\BakiyeGosterme.xaml"
            this.btnAnaMenu.Click += new System.Windows.RoutedEventHandler(this.btnAnaMenu_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

