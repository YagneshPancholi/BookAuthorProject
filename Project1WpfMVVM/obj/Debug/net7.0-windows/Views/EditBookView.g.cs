﻿#pragma checksum "..\..\..\..\Views\EditBookView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "29778975F0A83E0F3B11ACC024F2264FE2B229DD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Project1WpfMVVM.State.Navigators;
using Sdl.MultiSelectComboBox.API;
using Sdl.MultiSelectComboBox.Behaviours;
using Sdl.MultiSelectComboBox.Controls;
using Sdl.MultiSelectComboBox.EventArgs;
using Sdl.MultiSelectComboBox.Services;
using Sdl.MultiSelectComboBox.Themes.Generic;
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


namespace Project1WpfMVVM.Views {
    
    
    /// <summary>
    /// EditBookView
    /// </summary>
    public partial class EditBookView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 13 "..\..\..\..\Views\EditBookView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BookName;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Views\EditBookView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Price;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Views\EditBookView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox box1;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Views\EditBookView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox selectedAuthorNamesBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Views\EditBookView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox box2;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Views\EditBookView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox selectedGenreNamesBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Views\EditBookView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox box3;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Views\EditBookView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox selectedPublisherNamesBox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Views\EditBookView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubmitBtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Views\EditBookView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.15.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Project1WpfMVVM;component/views/editbookview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\EditBookView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.15.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BookName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Price = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.box1 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 15 "..\..\..\..\Views\EditBookView.xaml"
            this.box1.DropDownOpened += new System.EventHandler(this.box1_DropDownOpened);
            
            #line default
            #line hidden
            return;
            case 5:
            this.selectedAuthorNamesBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.box2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.selectedGenreNamesBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.box3 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.selectedPublisherNamesBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.SubmitBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            this.CancelBtn = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.15.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            
            #line 18 "..\..\..\..\Views\EditBookView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.SelectAuthor);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\..\Views\EditBookView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.UnselectAuthor);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 27 "..\..\..\..\Views\EditBookView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.SelectAuthor);
            
            #line default
            #line hidden
            
            #line 27 "..\..\..\..\Views\EditBookView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.UnselectAuthor);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 36 "..\..\..\..\Views\EditBookView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.SelectAuthor);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\..\Views\EditBookView.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.UnselectAuthor);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

