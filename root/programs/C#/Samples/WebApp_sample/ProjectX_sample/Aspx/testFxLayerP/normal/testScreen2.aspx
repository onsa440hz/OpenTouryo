﻿<%@ Page Language="C#" MasterPageFile="~/Aspx/Common/TestScreen2.master" AutoEventWireup="true" Inherits="ProjectX_sample.Aspx.TestFxLayerP.Normal.testScreen2" Codebehind="testScreen2.aspx.cs" %>
<%@ Register Assembly="CustomControl" Namespace="Touryo.Infrastructure.CustomControl" TagPrefix="cc1" %>

<asp:Content ID="cphHeaderScripts" ContentPlaceHolderID="cphHeaderScripts" Runat="Server">
    <!-- Head 部の ContentPlaceHolder -->
</asp:Content>

<asp:Content ID="ContentPlaceHolder_A" ContentPlaceHolderID="ContentPlaceHolder_A" Runat="Server">
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label><br />

    Content Page１（個別）<br />
    <table border="1">
        <tr>
            <th colspan="2">
                追加イベント
            </th>
            <th>
                アイコン違い（外部パラメータ）
            </th>
            <th>
                クライアントからの業務Modal画面起動
            </th>
            <th>
                クライアントからの業務Modeless画面起動
            </th>
        </tr>
        <tr>
            <td>
                ・DropDownList<br />
                <cc1:WebCustomDropDownList ID="ddlDropDownList1" runat="server" AutoPostBack="True"
                    Width="150px">
                    <asp:ListItem>あああ</asp:ListItem>
                    <asp:ListItem>いいい</asp:ListItem>
                    <asp:ListItem>ううう</asp:ListItem>
                    <asp:ListItem>えええ</asp:ListItem>
                    <asp:ListItem>おおお</asp:ListItem>
                </cc1:WebCustomDropDownList>
                <br />
                ※ AutoPostBack = True<br />
                <br />
                ・RadioButton<br />
                <cc1:WebCustomRadioButton ID="rbnRadioButton1" runat="server" AutoPostBack="True" GroupName="Group1" Text="CRB１" />
                <cc1:WebCustomRadioButton ID="rbnRadioButton2" runat="server" AutoPostBack="True" GroupName="Group1" Text="CRB２" />
                <br />
                ※ AutoPostBack = True<br />
                <br />
                ・CheckBox<br />
                <cc1:WebCustomCheckBox ID="cbxCheckBox1" runat="server" AutoPostBack="True" Text="CCB１" />
                <cc1:WebCustomCheckBox ID="cbxCheckBox2" runat="server" AutoPostBack="True" Text="CCB２" />
                <br />
                ※ AutoPostBack = True<br />
                <br />
                ・RadioButtonList<br />
                <cc1:WebCustomRadioButtonList ID="rblRadioButtonList1" runat="server" AutoPostBack="True"
                    Width="150px">
                    <asp:ListItem>あああ</asp:ListItem>
                    <asp:ListItem>いいい</asp:ListItem>
                    <asp:ListItem>ううう</asp:ListItem>
                    <asp:ListItem>えええ</asp:ListItem>
                    <asp:ListItem>おおお</asp:ListItem>
                </cc1:WebCustomRadioButtonList>
                <br />
                ※ AutoPostBack = True<br />
                <br />
                <br />
                ・CheckboxList<br />
                <cc1:WebCustomCheckBoxList ID="cblCheckBoxList1" runat="server" AutoPostBack="True"
                    Width="150px">
                    <asp:ListItem>あああ</asp:ListItem>
                    <asp:ListItem>いいい</asp:ListItem>
                    <asp:ListItem>ううう</asp:ListItem>
                    <asp:ListItem>えええ</asp:ListItem>
                    <asp:ListItem>おおお</asp:ListItem>
                </cc1:WebCustomCheckBoxList>
                <br />
                ※ AutoPostBack = True<br />
                <br />
            </td>
            <td>
                ・ListBox<br />
                <cc1:WebCustomListBox ID="lbxListBox1" runat="server" AutoPostBack="True" Width="150px">
                    <asp:ListItem>あああ</asp:ListItem>
                    <asp:ListItem>いいい</asp:ListItem>
                    <asp:ListItem>ううう</asp:ListItem>
                    <asp:ListItem>えええ</asp:ListItem>
                    <asp:ListItem>おおお</asp:ListItem>
                </cc1:WebCustomListBox>
                <br />
                ※ AutoPostBack = True<br />
            </td>
            <td>
                <cc1:WebCustomButton ID="btnButton1" runat="server" Text="YES・NO" Width="220px" /><br />
                <cc1:WebCustomLinkButton ID="lbnLinkButton1" runat="server" Width="220px">OK（ｉ）</cc1:WebCustomLinkButton><br />
                <cc1:WebCustomImageButton ID="ibnImageButton1" runat="server" ToolTip="OK（！）" /><br />
                <cc1:WebCustomImageMap ID="impImageMap1" runat="server" ToolTip="OK（×）">
                    <asp:CircleHotSpot HotSpotMode="PostBack" PostBackValue="spot1" X="100" Y="50" Radius="30" />
                    <asp:RectangleHotSpot Bottom="180" HotSpotMode="PostBack" Left="120" PostBackValue="spot2"
                        Right="180" Top="120" />
                    <asp:PolygonHotSpot Coordinates="25,110,10,190,90,190" HotSpotMode="PostBack" PostBackValue="spot3" />
                </cc1:WebCustomImageMap>
            </td>
            <td>
                クライアントからの業務Modal画面起動<br />
                デフォルトのスタイル<br />
                <cc1:WebCustomButton ID="btnButton2" runat="server" Text="QueryString無し" Width="220px" /><br />
                <cc1:WebCustomButton ID="btnButton3" runat="server" Text="QueryString有り" Width="220px" /><br />
                空のスタイル<br />
                <cc1:WebCustomButton ID="btnButton4" runat="server" Text="QueryString無し" Width="220px" /><br />
                <cc1:WebCustomButton ID="btnButton5" runat="server" Text="QueryString有り" Width="220px" /><br />
                <br />
                業務Modal画面のI/F<br />
                （親画面別セッション領域）<br />
                （画面GUIDを使用して識別する）<br />
                <cc1:WebCustomTextBox ID="TextBox1" runat="server"></cc1:WebCustomTextBox><br />
                <cc1:WebCustomButton ID="btnButton6" runat="server" Text="設定" Width="50px" />
                <cc1:WebCustomButton ID="btnButton7" runat="server" Text="取得" Width="50px" />
                <cc1:WebCustomButton ID="btnButton8" runat="server" Text="削除" Width="50px" /><br />
                <cc1:WebCustomTextBox ID="txtTextBox2" runat="server" AutoPostBack="true"></cc1:WebCustomTextBox>
            </td>
            <td>
                クライアントからの業務Modeless画面起動<br />
                デフォルトのスタイル、空のターゲット<br />
                <cc1:WebCustomButton ID="btnButton9" runat="server" Text="QueryString無し" Width="220px" /><br />
                空のスタイル、空のターゲット<br />
                <cc1:WebCustomButton ID="btnButton10" runat="server" Text="QueryString有り" Width="220px" /><br />
                空のスタイル、ターゲット（t）<br />
                <cc1:WebCustomButton ID="btnButton11" runat="server" Text="QueryString有り" Width="220px" /><br />
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="cphFooterScripts" ContentPlaceHolderID="cphFooterScripts" Runat="Server">
    <!-- Footer 部の ContentPlaceHolder -->
</asp:Content>
