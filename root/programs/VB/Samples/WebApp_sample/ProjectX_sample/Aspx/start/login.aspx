﻿<%@ Page Language="VB" MasterPageFile="~/Aspx/Common/testBlankScreen.master" AutoEventWireup="true" Inherits="ProjectX_sample.Aspx.Start.login" Codebehind="login.aspx.vb" %>
<%@ Register Assembly="CustomControl" Namespace="Touryo.Infrastructure.CustomControl" TagPrefix="cc1" %>

<asp:Content ID="cphHeaderScripts" ContentPlaceHolderID="cphHeaderScripts" Runat="Server">
    <!-- Head 部の ContentPlaceHolder -->
</asp:Content>

<asp:Content ID="ContentPlaceHolder_A" ContentPlaceHolderID="ContentPlaceHolder_A" Runat="Server">    
    <div>
        <table id="Table1" border="1">
            <tr>
		        <td>ユーザID</td>
		        <td>
		            <cc1:WebCustomTextBox id="txtUserID" runat="server"></cc1:WebCustomTextBox>
                </td>
		    </tr>
		    <tr>
		        <td>パスワード</td>
		        <td>
		            <cc1:WebCustomTextBox id="txtPassword" runat="server" TextMode="Password"></cc1:WebCustomTextBox>
    		    </td>
		    </tr>
		    <tr>
	    	    <td colspan="2" align="right">
                    <cc1:WebCustomButton ID="btnButton1" runat="server" Text="ログイン" Width="150px" />
                    <!--<cc1:WebCustomButton ID="btnButton2" runat="server" Text="ログイン" Width="150px" />-->
                </td>
		    </tr>
	    </table>
	    <cc1:WebCustomLabel id="lblMessage" runat="server" Width="250px">Label</cc1:WebCustomLabel>    
    </div>
</asp:Content>

<asp:Content ID="cphFooterScripts" ContentPlaceHolderID="cphFooterScripts" Runat="Server">
    <!-- Footer 部の ContentPlaceHolder -->
</asp:Content>
