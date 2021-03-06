﻿# Open Touryo
*Open Touryo* is an application framework based on .NET Framework.  
The programs of Open Touryo are available in the following repositories:
- OpenTouryoTemplates repository
    - Summary  
    The programs in this repository are the *development infrastructure (project template)* of the programs using Open Touryo.  
    Default DBMS is *SQL Server*, and the programs are partitioned into the folders for each version of Visual Studio.
    - Intended User  
    The *application developers* using Open Touryo.
- OpenTouryo repository (*Current repository*)
    - Summary  
    The programs in this repository are the *matrix* of OpenTouryoTemplates repository.  
    (First, the features of Open Touryo are implemented in this repository. And then, the features are introduced into OpenTouryoTemplates repository.)
    - Intended User  
    *Open source developers*.

Therefore, the users who use Open Touryo in a system development project need to use [OpenTouryoTemplates repository](https://github.com/OpenTouryoProject/OpenTouryoTemplates).  
The following contents are the usage of Open Touryo for *open source developers*.

Click [here](Readme.ja.md) for Japanese version of this file.

## Running sample application tasks
You can run the sample application bundled with Open Touryo according to the following steps.

### Install prerequisites
Install Visual Studio 2015 beforehand.

Further, when implementing or testing the *data access class*, install the DBMS(s) to be used.  
Open Touryo supports the following DBMSs:
- SQL Server  
(You can use an arbitrary version of SQL Server. And you can use different editions than Express Edition.)
- Oracle Database (including Express Edition)
- IBM DB2
- MySQL
- PostgreSQL

### Deploy Open Touryo
Copy root folder to C drive.

### Deploy data providers
Obtain the data providers of DBMSs which are supported by Open Touryo, and deploy the data providers to the following folder.
```txt
C:\root\programs\C#\Frameworks\Infrastructure\Public\Dll
```

The correspondence between the DBMSs and the data providers is as follows:
- Oracle (Oracle.DataAccess.dll)
- DB2 (IBM.Data.DB2.dll)
- MySQL (MySql.Data.dll)
- PostgreSQL (Npgsql.dll)

**Note:**  
Open Touryo supports SQL Server, but it is not necessary to deploy System.Data.SqlClient.dll, which is the data provider of SQL Server, to the above folder because System.Data.SqlClient.dll is contained in .NET Framework.  
And, it might be necessary to re-add the reference of each data provider to DamXXX.csproj, that is, the Visual Studio project for data access in Open Touryo.

### Set up sample database
#### SQL Server  
Sample application requires *Northwind* database.  
So, download the setup script installer of *Northwind* database from the following Microsoft site and install.

  - Download: NorthWind and pubs Sample Databases for SQL Server 2000 - Microsoft Download Center  
    http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=23654

When completing the installation, *SQL Server 2000 Sample Databases* folder is created in C drive.
When using SQL Server 2012 or later, open *instnwnd.sql* file in an editor and comment out the following code.  
**Note**:  
Because *sp_option* system stored procedure does not exist in SQL Server 2012 or later, this step is required.

```sql
exec sp_dboption 'Northwind','trunc. log on chkpt.','true'
exec sp_dboption 'Northwind','select into/bulkcopy','true'
```

Execute the following command at a command prompt.  
**Note**:  
In the following command, the path of the folder that contains *SQLCMD.EXE* changes according to the version of SQL Server.  
Execute command after confirming the path of folder in your environment. 
```bat
"C:\Program Files\Microsoft SQL Server\100\Tools\Binn\SQLCMD.EXE" -S localhost\SQLExpress -E -i "C:\SQL Server 2000 Sample Databases\instnwnd.sql"
```

#### DBMSs except for SQL Server
- Create an empty database in each DBMSs.
- Create test table in the database by running C:\root\files\resource\Sql\[DBMS Name]\TestTable.txt.

### Build program
When using Open Touryo, it is necessary to build programs **by running the batch files using MSBuild only at the first time**.  
**Note**:  
Open Touryo Template Base contains two parts:
- Framework (Base class 1 and base class 2)
- Sample application (Subclass)

It is necessary to copy the *deliverables generated by building*, that is, *dll files* to the default folder of Open Touryo.  
Therefore, it is necessary to run the batch files which execute a series of build processes.

The batch files are stored in the following folder:
- C:\root\programs\C#  
- C:\root\programs\VB

The following figure shows the batch files which should be run.

Legend:
- ○: Need to run always
- △: Depend on the application architecture
- Empty: Not need to run

<table>
  <thead>
    <tr>
      <th rowspan="2">Folder Name</th><th rowspan="2">Batch File Name</th><th rowspan="2">Description</th><th colspan="2">File to be run</th>
    </tr>
    <tr>
      <th>C#</th><th>VB</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td rowspan="16" style="vertical-align: top">C:\root\programs\C#</td><td>1_DeleteDir.bat</td><td>Delete (Clean) the folders that are generated by building.</td><td>○</td><td>○</td>
    </tr>
    <tr>
      <td>2_DeleteFile.bat</td><td>Delete (Clean) the temporary files.</td><td>○</td><td>○</td>
    </tr>
    <tr>
      <td>3_Build_Framework.bat</td><td>Build the framework. (Base class 1 and base class 2)</td><td>○</td><td>○</td>
    </tr>
    <tr>
      <td>3_Build_PortableClassLibrary.bat</td><td>Build the portable class library.</td><td>△<span style="color: red"><sup>*1</sup></span></td><td></td>
    </tr>
    <tr>
      <td>3_Build_RichClientCustomControl.bat</td><td>Build the custom controls for rich client application.</td><td>△<span style="color: red"><sup>*2</sup></span></td><td></td>
    </tr>
    <tr>
      <td>4_Build_Framework_Tool.bat</td><td>Build the tools bundled with Open Touryo.</td><td>○</td><td>○</td>
    </tr>
    <tr>
      <td>5_Build_2CS_sample.bat</td><td>Build the sample application. (Two-tier client server application)</td><td rowspan="8" style="vertical-align: top">△<span style="color: red"><sup>*3</sup></span></td><td></td>
    </tr>
    <tr>
      <td>5_Build_Bat_sample.bat</td><td>Build the sample application. (Batch application)</td><td></td>
    </tr>
    <tr>
      <td>6_Build_WSSrv_sample.bat</td><td>Build the sample application. (Web services (Server-side logic))</td><td></td>
    </tr>
    <tr>
      <td>7_Build_Framework_WS.bat</td><td>Build the framework. (Service interface)</td><td></td>
    </tr>
    <tr>
      <td>8_Build_WSClnt_sample.bat</td><td>Build the sample application. (Web service client (Windows forms))</td><td></td>
    </tr>
    <tr>
      <td>9_Build_WSClnt_sample.bat</td><td>Build the sample application. (Web service client (WPF))</td><td></td>
    </tr>
    <tr>
      <td>10_Build_WebApp_sample.bat</td><td>Build the sample application. (ASP.NET)</td><td></td>
    </tr>
    <tr>
      <td>11_Build_UWP_sample.bat</td><td>Build the sample application. (UWP)</td><td></td>
    </tr>
    <tr>
      <td>z_Common.bat</td><td>Set common settings to build using MSBuild.</td><td></td><td></td>
    </tr>
    <tr>
      <td>z_Common2.bat</td><td>Set common settings to build using Visual Studio.</td><td></td><td></td>
    </tr>
    <tr>
      <td rowspan="12" style="vertical-align: top">C:\root\programs\VB</td><td>1_DeleteDir.bat</td><td>Delete (Clean) the folders that are generated by building.</td><td></td><td>○</td>
    </tr>
    <tr>
      <td>2_DeleteFile.bat</td><td>Delete (Clean) the temporary files.</td><td></td><td>○</td>
    </tr>
    <tr>
      <td>3_Build_Framework.bat</td><td>Build the framework. (Base class 2)</td><td></td><td>○</td>
    </tr>
    <tr>
      <td>3_Build_RichClientCustomControl.bat</td><td>Build the custom controls for rich client application.</td><td></td><td>△<span style="color: red"><sup>*2</sup></span></td>
    </tr>
    <tr>
      <td>5_Build_2CS_sample.bat</td><td>Build the sample application. (Two-tier client server application)</td><td></td><td rowspan="6" style="vertical-align: top">△<span style="color: red"><sup>*3</sup></span></td>
    </tr>
    <tr>
      <td>5_Build_Bat_sample.bat</td><td>Build the sample application. (Batch application)</td><td></td>
    </tr>
    <tr>
      <td>6_Build_WSSrv_sample.bat</td><td>Build the sample application. (Web services (Server-side logic))</td><td></td>
    </tr>
    <tr>
      <td>7_Build_Framework_WS.bat</td><td>Build the framework. (Service interface)</td><td></td>
    </tr>
    <tr>
      <td>8_Build_WSClnt_sample.bat</td><td>Build the sample application. (Web service client (Windows forms))</td><td></td>
    </tr>
    <tr>
      <td>10_Build_WebApp_sample.bat</td><td>Build the sample application. (ASP.NET)</td><td></td>
    </tr>
    <tr>
      <td>z_Common.bat</td><td>Set common settings to build using MSBuild.</td><td></td><td></td>
    </tr>
    <tr>
      <td>z_Common2.bat</td><td>Set common settings to build using Visual Studio.</td><td></td><td></td>
    </tr>
  </tbody>
</table>
<div style="font-size: small">
  <span style="color: red;">*1</span>　Need to run when using portable class library.<br />
  <span style="color: red;">*2</span>　Need to run when creating rich client application.<br />
  <span style="color: red;">*3</span>　Select according to the actual architecture.
</div>

Refer to the above table and build programs by running the batch files in numerical order.

- If necessary, revise the environment variable *BUILDFILEPATH* in z_Common.bat according to the build environment.

- The libraries which are used by Open Touryo Template Base for Visual Studio 2015 are downloaded by NuGet. NuGet libraries might not be downloaded normally under proxy environment. So, when using proxy environment, create environment variable *http_proxy* as follows:
    - Open *C:\root\programs\C#\z_Common.bat* and *C:\root\programs\VB\z_Common.bat* in an editor.
    - By default, the code which creates environment variable *http_proxy* is commented.  
    So, uncomment this code by removing '@rem'.
    - Set your proxy information in environment variable *http_proxy*.

- When the following error occurred at build time, install *Windows SDK for Windows 8*. (Refer to [issue of Open Touryo](https://github.com/OpenTouryoProject/OpenTouryoTemplates/issues/48#issuecomment-241349223).)
```
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\Microsoft.Common.targets(2863,5): error MSB3086: Task could not find "AL.exe" using the SdkToolsPath "" or the registry key "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft SDKs\Windows\v8.0A\WinSDK-NetFx40Tools-x86". Make sure the SdkToolsPath is set and the tool exists in the correct processor specific location under the SdkToolsPath and that the Microsoft Windows SDK is installed
```
  
### Start ASP.NET state service
Open a command prompt as an administrator and execute the following commands.
```bat
   sc config aspnet_state start= auto
   net start aspnet_state
```

### Run the sample application
- Open the following file.
- Open web.config or app.config and revise the values in *connectionStrings* section according to the actual database environment.
- Run the sample application.  
At the login screen, enter the arbitrary alphanumeric characters. (By default, the password authentication is not executed.)
   
#### Web application:
- ASP.NET Web Forms  
  - C:\root\programs\C#\Samples\WebApp_sample\ProjectX_sample\ProjectX_sample.sln
  - C:\root\programs\VB\Samples\WebApp_sample\ProjectX_sample\ProjectX_sample.sln
- ASP.NET MVC  
  - C:\root\programs\C#\Samples\WebApp_sample\MVC_Sample\MVC_Sample.sln
  - C:\root\programs\VB\Samples\WebApp_sample\MVC_Sample\MVC_Sample.sln
- ASP.NET Single Page Application  
C:\root\programs\C#\Samples\WebApp_sample\SPA_Sample\SPA_Sample.sln
 
#### Two-tier client server application:
- Windows Forms  
  - C:\root\programs\C#\Samples\2CS_sample\2CSClientWin_sample\2CSClientWin_sample.sln
  - C:\root\programs\VB\Samples\2CS_sample\2CSClientWin_sample\2CSClientWin_sample.sln
- WPF  
  - C:\root\programs\C#\Samples\2CS_sample\2CSClientWPF_sample\2CSClientWPF_sample.sln
  - C:\root\programs\VB\Samples\2CS_sample\2CSClientWPF_sample\2CSClientWPF_sample.sln

#### Three-tier client server application:
- Windows Forms  
  - Windows forms application
    - C:\root\programs\C#\Samples\WS_sample\WSClient_sample\WSClientWin_sample\WSClientWin_sample.sln
    - C:\root\programs\VB\Samples\WS_sample\WSClient_sample\WSClientWin_sample\WSClientWin_sample.sln
  - ClickOnce application  
C:\root\programs\C#\Samples\WS_sample\WSClient_sample\WSClientWinCone_sample\WSClientWinCone_sample.sln
- WPF
  - C:\root\programs\C#\Samples\WS_sample\WSClient_sample\WSClientWPF_sample\WSClientWPF_sample.sln
  - C:\root\programs\VB\Samples\WS_sample\WSClient_sample\WSClientWPF_sample\WSClientWPF_sample.sln
- UWP  
C:\root\programs\C#\Samples\UWP_sample\UWP_sample.sln

### Reference
The documents in *OpenTouryoDocument repository* are useful when using Open Touryo.  
- [Introduction](https://github.com/OpenTouryoProject/OpenTouryoDocuments/tree/master/documents/0_Introduction)  
You can see the introduction materials, such as PowerPoint slides.
- [User Guide](https://github.com/OpenTouryoProject/OpenTouryoDocuments/tree/master/documents/1_User_Guide)  
You can confirm the structure of Open Touryo and the specification of each feature.
- [Tutorial](https://github.com/OpenTouryoProject/OpenTouryoDocuments/tree/master/documents/2_Tutorial)  
You can see the *first step guide* of Open Touryo.

### Copyright and license
Refer to [License](https://github.com/OpenTouryoProject/OpenTouryo/tree/master/license) directory.

### Bug fix
If you find the bug while you are using Open Touryo, create an new [issue](https://github.com/OpenTouryoProject/OpenTouryo/issues).  
Open Touryo community confirms the issue and takes appropriate actions.  

### Obtaining data provider, Exporting prodedures, Attaching to license
Obtain and export the data provider, which Open Touryo supports, on your own.
