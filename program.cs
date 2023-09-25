/*
 * Created by SharpDevelop.
 * User: Mng
 * Date: 09/22/2023
 * Time: 18:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;


namespace snip6
{
	class Program
	{
		public static void Main(string[] args)
		{
			string path2;
			if (args.Length > 0) {
        		 path2 = args[0];
			}
			else 
			{
				 path2 ="c:\\temp\\wood.jpg"; 
			}
			;
			Console.Write(path2);
			LaunchUri(path2);
		}
		 private static async void LaunchUri( string ppath )  
    {  
        string sPath = @ppath ;
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
    }  	

	}
}
