﻿#pragma checksum "C:\Users\MrGamble\Downloads\klienshazi\MovieWorld\Cookbook\Views\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "53E9552B213184DCA15BB27493737892"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieWorld.Views
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // Views\MainPage.xaml line 14
                {
                    this.ViewModel = (global::MovieWorld.ViewModels.MainPageViewModel)(target);
                }
                break;
            case 2: // Views\MainPage.xaml line 41
                {
                    this.MediaInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // Views\MainPage.xaml line 43
                {
                    this.LanguageInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // Views\MainPage.xaml line 45
                {
                    global::Windows.UI.Xaml.Controls.CheckBox element4 = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                    ((global::Windows.UI.Xaml.Controls.CheckBox)element4).Checked += this. CheckBoxCheckDecreasing;
                    ((global::Windows.UI.Xaml.Controls.CheckBox)element4).Unchecked += this.CheckBoxCheckIncreasing;
                }
                break;
            case 5: // Views\MainPage.xaml line 47
                {
                    global::Windows.UI.Xaml.Controls.CheckBox element5 = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                    ((global::Windows.UI.Xaml.Controls.CheckBox)element5).Checked += this.CheckBoxCheckAdult;
                    ((global::Windows.UI.Xaml.Controls.CheckBox)element5).Unchecked += this.CheckBoxCheckChildren;
                }
                break;
            case 6: // Views\MainPage.xaml line 54
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.Discover_Button_Click;
                }
                break;
            case 7: // Views\MainPage.xaml line 56
                {
                    this.MediaTV = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.MediaTV).Checked += this.SetMedia;
                }
                break;
            case 8: // Views\MainPage.xaml line 57
                {
                    this.MediaMovie = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.MediaMovie).Checked += this.SetMedia;
                }
                break;
            case 9: // Views\MainPage.xaml line 59
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element9 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element9).Checked += this.SetTiming;
                }
                break;
            case 10: // Views\MainPage.xaml line 60
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element10 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element10).Checked += this.SetTiming;
                }
                break;
            case 11: // Views\MainPage.xaml line 61
                {
                    global::Windows.UI.Xaml.Controls.Button element11 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element11).Click += this.Item_Button_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

