﻿#pragma checksum "..\..\..\CustomerQuotationDetails.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B41865F7F06ACFF9B44BDD164108102D78AC9F23"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace iab251_at2 {
    
    
    /// <summary>
    /// CustomerQuotationDetails
    /// </summary>
    public partial class CustomerQuotationDetails : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\CustomerQuotationDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CustomerNameTextBlock;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\CustomerQuotationDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock QuotationNumberTextBlock;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\CustomerQuotationDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DateIssuedTextBlock;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\CustomerQuotationDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ContainerTypeTextBlock;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\CustomerQuotationDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ScopeTextBlock;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\CustomerQuotationDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DepotChargesTextBlock;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\CustomerQuotationDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LCLChargesTextBlock;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/iab251_at2;component/customerquotationdetails.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CustomerQuotationDetails.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CustomerNameTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.QuotationNumberTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.DateIssuedTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.ContainerTypeTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.ScopeTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.DepotChargesTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.LCLChargesTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            
            #line 43 "..\..\..\CustomerQuotationDetails.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AcceptButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 44 "..\..\..\CustomerQuotationDetails.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RejectButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

