﻿'**********************************************************************************
'* サンプル画面（Ｐ層）
'**********************************************************************************

' サンプル画面なので、必要に応じて流用 or 削除して下さい。

'**********************************************************************************
'* クラス名        ：login
'* クラス日本語名  ：ログイン画面（Forms認証対応）
'*
'* 作成日時        ：－
'* 作成者          ：－
'* 更新履歴        ：－
'*
'*  日時        更新者            内容
'*  ----------  ----------------  -------------------------------------------------
'*  20xx/xx/xx  ＸＸ ＸＸ         ＸＸＸＸ
'**********************************************************************************

Imports Touryo.Infrastructure.Business.Presentation
Imports Touryo.Infrastructure.Business.Util
Imports Touryo.Infrastructure.Framework.Presentation
Imports Touryo.Infrastructure.Framework.Util

Namespace Aspx.Start
    ''' <summary>ログイン画面（Forms認証対応）</summary>
    Partial Public Class login
        Inherits MyBaseController
        Public Sub New()
            Me.IsNoSession = True
        End Sub

#Region "Page LoadのUOCメソッド"

        ''' <summary>
        ''' Page LoadのUOCメソッド（個別：初回Load）
        ''' </summary>
        ''' <remarks>
        ''' 実装必須
        ''' </remarks>
        Protected Overrides Sub UOC_FormInit()
            ' Form初期化（初回Load）時に実行する処理を実装する

            ' TODO:
            ' ここでは何もしない

            ' Session消去
            Me.FxSessionAbandon()

        End Sub

        ''' <summary>
        ''' Page LoadのUOCメソッド（個別：Post Back）
        ''' </summary>
        ''' <remarks>
        ''' 実装必須
        ''' </remarks>
        Protected Overrides Sub UOC_FormInit_PostBack()
            ' Form初期化（Post Back）時に実行する処理を実装する

            ' TODO:
            ' ここでは何もしない

            ' btnButton1のイベントであれば、Session消去しない
            If Request.Form("ctl00$ContentPlaceHolder_A$btnButton1") Is Nothing Then
                ' Session消去
                Me.FxSessionAbandon()
            End If
        End Sub

#End Region

#Region "Event Handler"

        ''' <summary>ログイン</summary>
        ''' <param name="fxEventArgs">Event Handlerの共通引数</param>
        ''' <returns>URL</returns>
        Protected Function UOC_btnButton1_Click(fxEventArgs As FxEventArgs) As String
            ' ここで、入力されたユーザIDと、パスワードをチェックし、ユーザ認証する。

            If Not String.IsNullOrEmpty(Me.txtUserID.Text) Then
                ' 現時点では、全て(空文字以外)認証する。
                ' 認証か完了した場合、認証チケットを生成し、元のページにRedirectする。
                ' 第２引数は、「クライアントがCookieを永続化（ファイルとして保存）するかどうか。」
                ' を設定する引数であるが、セキュリティを考慮して、falseの設定を勧める。
                FormsAuthentication.RedirectFromLoginPage(Me.txtUserID.Text, False)

                ' 認証情報を保存する。
                Dim ui As New MyUserInfo(Me.txtUserID.Text, Request.UserHostAddress)
                UserInfoHandle.SetUserInformation(ui)
            Else
                ' 認証に失敗した場合は、Messageを表示する
                Me.lblMessage.Text = "認証に失敗しました。ユーザIDか、パスワードが間違っています。"

                ' Session消去
                Me.FxSessionAbandon()
            End If

            ' 画面遷移はしない（基盤に任せるため）。
            Return String.Empty
        End Function

#End Region
    End Class
End Namespace
