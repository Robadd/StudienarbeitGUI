﻿#pragma checksum "..\..\..\Eigenschaftsfenster\SprayerEigWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "944B1ACA2F02534873C61B5BB09968E6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.18408
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Studienarbeit;
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


namespace Studienarbeit {
    
    
    /// <summary>
    /// SprayerEigWindow
    /// </summary>
    public partial class SprayerEigWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Eigenschaftsfenster\SprayerEigWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle color;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Eigenschaftsfenster\SprayerEigWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FarbAusw;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Eigenschaftsfenster\SprayerEigWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ok;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Eigenschaftsfenster\SprayerEigWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Abbruch;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Eigenschaftsfenster\SprayerEigWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Studienarbeit.ScrollProp WidthValue;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Eigenschaftsfenster\SprayerEigWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Studienarbeit.ScrollProp HeightValue;
        
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
            System.Uri resourceLocater = new System.Uri("/Studienarbeit;component/eigenschaftsfenster/sprayereigwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Eigenschaftsfenster\SprayerEigWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.color = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 2:
            this.FarbAusw = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Eigenschaftsfenster\SprayerEigWindow.xaml"
            this.FarbAusw.Click += new System.Windows.RoutedEventHandler(this.FarbAusw_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Ok = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Eigenschaftsfenster\SprayerEigWindow.xaml"
            this.Ok.Click += new System.Windows.RoutedEventHandler(this.Ok_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Abbruch = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Eigenschaftsfenster\SprayerEigWindow.xaml"
            this.Abbruch.Click += new System.Windows.RoutedEventHandler(this.Abbruch_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.WidthValue = ((Studienarbeit.ScrollProp)(target));
            return;
            case 6:
            this.HeightValue = ((Studienarbeit.ScrollProp)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

