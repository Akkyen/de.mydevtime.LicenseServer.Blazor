﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace de.mydevtime.LicenseServer.Blazor.Resources.Pages {
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Layout {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Layout() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("de.mydevtime.LicenseServer.Blazor.Resources.Pages.Layout", typeof(Layout).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string Menu_Licenses {
            get {
                return ResourceManager.GetString("Menu.Licenses", resourceCulture);
            }
        }
        
        internal static string Menu_Settings {
            get {
                return ResourceManager.GetString("Menu.Settings", resourceCulture);
            }
        }
        
        internal static string Menu_Users {
            get {
                return ResourceManager.GetString("Menu.Users", resourceCulture);
            }
        }
        
        internal static string Menu_Dashboard {
            get {
                return ResourceManager.GetString("Menu.Dashboard", resourceCulture);
            }
        }
    }
}
