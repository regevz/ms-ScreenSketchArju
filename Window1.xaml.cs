/*
 * Created by SharpDevelop.
 * User: Mng
 * Date: 21/09/2023
 * Time: 23:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace SNIPP
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{

		public Window1(  )
		{
			InitializeComponent();
			string[] args2 = Environment.GetCommandLineArgs();
			//MessageBox.Show (args2[1]);
			LaunchUri(args2[1]);
		}

    private async void LaunchUri( string ppath)  
    {  
        string sPath = @ppath;
        
        var file = await Windows.Storage.StorageFile.GetFileFromPathAsync(sPath);  
        var sToken = Windows.ApplicationModel.DataTransfer.SharedStorageAccessManager.AddFile(file);  
  
        var sUri = String.Format("ms-screensketch:edit?source=MyApp&isTemporary=false&sharedAccessToken={0}", sToken);  
        bool bResult = await Windows.System.Launcher.LaunchUriAsync(new Uri(sUri));  
	
        if (bResult)  
        {  
            // URI launched  
        }  
        else  
        {  
            // URI launch failed  
        }
            System.Environment.Exit(1);
    }  	
		
		
		}
	}
